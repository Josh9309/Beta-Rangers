using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Player : MonoBehaviour {
    //sets up a finite state to identify what type of ranger the player is.
    public enum RangerType {BlueRanger, RedRanger, GreenRanger, YellowRanger, BlackRanger, PinkRanger};

    #region InputSettings
    //this will setup the public inputSetting class
    [System.Serializable]
    public class InputSettings
    {
        public float delay = 0.3f; //delay for movement inputs
        public float fwdInput = 0, jumpInput = 0, attack1Input = 0, attack2Input = 0, attack3Input = 0, dodgeInput =0; //sets up variables to hold inputs
        public string JUMP_AXIS, HORIZONTAL_AXIS, ATTACK1_AXIS, ATTACK2_AXIS, ATTACK3_AXIS, DODGE_AXIS; //sets up variable to hold input_axis
        public string PAUSE_AXIS = "Pause"; //sets the pause input Axis
        
        //sets up booleans for btn_input and sets them to false
        public bool jump = false;
        public bool attack1 = false;
        public bool attack2 = false;
        public bool attack3 = false;
        public bool dodge = false;
        public bool pause = false;

        public void ConfigureInput(int playerNum)
        {
            //sets up the input axes based on the players number
            switch (playerNum)
            {
                case 1:
                    HORIZONTAL_AXIS = "P1_Horizontal";
                    JUMP_AXIS = "P1_Jump";
                    ATTACK1_AXIS = "P1_Attack1";
                    ATTACK2_AXIS = "P1_Attack2";
                    ATTACK3_AXIS = "P1_Attack3";
                    DODGE_AXIS = "P1_Dodge";
                    break;

                case 2:
                    HORIZONTAL_AXIS = "P2_Horizontal";
                    JUMP_AXIS = "P2_Jump";
                    ATTACK1_AXIS = "P2_Attack1";
                    ATTACK2_AXIS = "P2_Attack2";
                    ATTACK3_AXIS = "P2_Attack3";
                    DODGE_AXIS = "P2_Dodge";
                    break;

                case 3:
                    HORIZONTAL_AXIS = "P3_Horizontal";
                    JUMP_AXIS = "P3_Jump";
                    ATTACK1_AXIS = "P3_Attack1";
                    ATTACK2_AXIS = "P3_Attack2";
                    ATTACK3_AXIS = "P3_Attack3";
                    DODGE_AXIS = "P3_Dodge";
                    break;

                case 4:
                    HORIZONTAL_AXIS = "P4_Horizontal";
                    JUMP_AXIS = "P4_Jump";
                    ATTACK1_AXIS = "P4_Attack1";
                    ATTACK2_AXIS = "P4_Attack2";
                    ATTACK3_AXIS = "P4_Attack3";
                    DODGE_AXIS = "P4_Dodge";
                    break;
            }
        }

        public void ResetBtns()
        {
            //resets booleans for btn_input to false
            jump = false;
            attack1 = false;
            attack2 = false;
            attack3 = false;
            dodge = false;
            pause = false;
        }
    }
    #endregion

    #region Attributes
    //basic ranger stats attributes
    [SerializeField] protected int health;
    [SerializeField] protected float attack1Power, attack2Power, attack3Power;
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpPower;
    [SerializeField] protected int superCost;
    [SerializeField] protected int superMax;

    //basic player stats attributes
    [SerializeField] protected RangerType ranger; //this will hold what type of ranger this player is
    [SerializeField] protected int playerNum;
    private int superCurrent;
    private Color playerColor;
    private Key key;

    //basic ranger physic attributes
    [SerializeField] protected bool facingLeft;
    protected Vector3 postition;
    protected Vector2 velocity;
    [SerializeField] protected bool grounded;
    [SerializeField] protected Transform groundCheck;
    protected Rigidbody2D rBody;
    private bool airControl;
    [SerializeField] private LayerMask ground;

    //other attributes
    protected InputSettings input = new InputSettings();
    protected WorldController worldControl;
    #endregion

    #region Properties
    public int Health
    {
        get { return health; }
        set
        {
            if(value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }
        }
    }

    public Vector3 Position
    {
        get { return postition; }
        set { postition = value; }
    }

    public int PlayerNum
    {
        get { return playerNum; }
        set
        {
            if(value < 1 || value > 4)
            {
                Debug.LogError("Tried to set playerNum to an invalid value");
            }
            else { playerNum = value; }
        }
    }

    public RangerType Ranger
    {
        get { return ranger; }
    }

    public int SuperCurrent
    {
        get { return superCurrent; }
        set
        {
            if(value < 0)
            {
                superCurrent = 0;
            }
            else if(value > superMax)
            {
                superCurrent = superMax;
            }
            else
            {
                superCurrent = value;
            }
        }
    }

    public int SuperCost
    {
        get { return superCost; }
    }
    #endregion

    #region Methods
    
    // Use this for initialization
    protected virtual void Start () {
        //get the world Controller
        //worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();

        //setup input
        input.ConfigureInput(PlayerNum);

        //get physic stuff for ranger
        groundCheck = transform.FindChild("GroundCheck");
        postition = transform.position;
        rBody = GetComponent<Rigidbody2D>();
        rBody.mass = 1.0f;
	}
	
    protected virtual void FixedUpdate()
    {
        GetInput();//gets all the input from the player
        IsGrounded(); //checks if the ranger is grounded
        Move(); // moves the ranger based on player input
        Jump(); // makes the ranger jump based on player input

        //stop ranger velocity if there is no input and ranger is grounded
        if (input.fwdInput == 0 && input.jumpInput == 0 && grounded) //if there is no input and the character is on the ground
        {
            rBody.velocity = Vector2.zero; // stops character 
        }

        if (grounded) //if ranger is grounded it turns air control back on
        {
            airControl = true;
        }
    }

    protected void GetInput()
    {
        //gets all value based input checks
        input.fwdInput = Input.GetAxis(input.HORIZONTAL_AXIS);
        input.jumpInput = Input.GetAxis(input.JUMP_AXIS);
        input.dodgeInput = Input.GetAxis(input.DODGE_AXIS);
        input.attack1Input = Input.GetAxis(input.ATTACK1_AXIS);
        input.attack2Input = Input.GetAxis(input.ATTACK2_AXIS);
        input.attack3Input = Input.GetAxis(input.ATTACK3_AXIS);

        //button input checks
        if (!input.jump)
        {
            input.jump = Input.GetButtonDown(input.JUMP_AXIS);
        }
        if (!input.dodge)
        {
            input.dodge = Input.GetButtonDown(input.DODGE_AXIS);
        }
        if (!input.attack1)
        {
            input.attack1 = Input.GetButtonDown(input.ATTACK1_AXIS);
        }
        if (!input.attack2)
        {
            input.attack2 = Input.GetButtonDown(input.ATTACK2_AXIS);
        }
        if (!input.attack2)
        {
            input.attack2 = Input.GetButtonDown(input.ATTACK2_AXIS);
        }

    }

    protected void IsGrounded() //used to see whether or not the ranger is grounded
    {
        //start off by assuming ranger is not grounded
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.3f, ground); //gets all colliders the are within the radius of the ground check
        for (int i = 0; i < colliders.Length; i++) 
        {
            if (colliders[i].gameObject != gameObject) //checks each collider to make sure it is not the player's own collider
            {
                grounded = true; //sets grounded to true if it detects a collider that is not the player's colliders.
            }
        }
    }

    protected void Flip() //used to flip the ranger asset
    {
        facingLeft = !facingLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    protected void CheckIsAlive() //used to check if player is still alive
    {

    }

    #region GameMechanic/Movement Methods
    protected void Move() //this method controls how the ranger moves
    {
        if(Mathf.Abs(input.fwdInput)> input.delay) //make sure the input is greater than the input.delay
        {
            if(airControl || grounded) //if aircontrol or grounded is true
            {
                rBody.velocity = new Vector2(input.fwdInput * speed, rBody.velocity.y); // moves player based on input
            }
            if(input.fwdInput < 0) //ranger moving left
            {
                if(facingLeft == false) 
                {
                    Flip(); //flips ranger if the asset is not facing correct direction
                }
            }
            else if(input.fwdInput > 0)// ranger moving right
            {
                if(facingLeft == true)
                {
                    Flip(); //flips ranger if the asset is not facing correct direction
                }
            }
        }
    }

    protected void Jump() //used to make the player jump
    {
        if(input.jump && grounded) // if jump button is pressed and player is grounded
        {
            grounded = false;
            rBody.AddForce(new Vector2(0f, jumpPower));//add a force to cause the player to jump
        }
    }

    protected void Dodge()
    {

    }

    protected virtual void Attack1()
    {

    }

    abstract protected void Attack2();


    abstract protected void SuperAttack();

    #endregion
    public virtual void DestroyRanger()
    {
        Destroy(gameObject);
        Debug.Log("Ranger has been destroyed");

    }

    public int ModHealth(int mod) //adds/subtracts from health
    {
        throw new System.Exception("Method not implemented yet");
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (!grounded)
        {
            airControl = false;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D coll)
    {
        airControl = true;
    }

    protected virtual void OnDrawGizmos() //used to draw gizmos for debugging
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, 0.3f);
    }
    #endregion
}
