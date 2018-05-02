using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Player : MonoBehaviour {
    //sets up a finite state to identify what type of ranger the player is.
    public enum RangerType {BlueRanger, RedRanger, GreenRanger, YellowRanger, BlackRanger, PinkRanger};
    private enum StatusEffect { None, AttackPower, Speed, Jump};

    #region InputSettings
    //this will setup the public inputSetting class
    [System.Serializable]
    public class InputSettings
    {
        public float delay = 0.3f; //delay for movement inputs
        public float fwdInput = 0, jumpInput = 0, attack1Input = 0, attack2Input = 0, attack3Input = 0, dodgeInput =0; //sets up variables to hold inputs
        public string JUMP_AXIS, HORIZONTAL_AXIS, ATTACK1_AXIS, ATTACK2_AXIS, ATTACK3_AXIS, DODGE_AXIS, SUBMIT_AXIS, CANCEL_AXIS; //sets up variable to hold input_axis
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
                    SUBMIT_AXIS = "P1_Submit";
                    CANCEL_AXIS = "P1_Cancel";
                    PAUSE_AXIS = "P1_Pause";
                    break;

                case 2:
                    HORIZONTAL_AXIS = "P2_Horizontal";
                    JUMP_AXIS = "P2_Jump";
                    ATTACK1_AXIS = "P2_Attack1";
                    ATTACK2_AXIS = "P2_Attack2";
                    ATTACK3_AXIS = "P2_Attack3";
                    DODGE_AXIS = "P2_Dodge";
                    SUBMIT_AXIS = "P2_Submit";
                    CANCEL_AXIS = "P2_Cancel";
                    PAUSE_AXIS = "P2_Pause";
                    break;

                case 3:
                    HORIZONTAL_AXIS = "P3_Horizontal";
                    JUMP_AXIS = "P3_Jump";
                    ATTACK1_AXIS = "P3_Attack1";
                    ATTACK2_AXIS = "P3_Attack2";
                    ATTACK3_AXIS = "P3_Attack3";
                    DODGE_AXIS = "P3_Dodge";
                    SUBMIT_AXIS = "P3_Submit";
                    CANCEL_AXIS = "P3_Cancel";
                    PAUSE_AXIS = "P3_Pause";
                    break;

                case 4:
                    HORIZONTAL_AXIS = "P4_Horizontal";
                    JUMP_AXIS = "P4_Jump";
                    ATTACK1_AXIS = "P4_Attack1";
                    ATTACK2_AXIS = "P4_Attack2";
                    ATTACK3_AXIS = "P4_Attack3";
                    DODGE_AXIS = "P4_Dodge";
                    SUBMIT_AXIS = "P4_Submit";
                    CANCEL_AXIS = "P4_Cancel";
                    PAUSE_AXIS = "P4_Pause";
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
    [SerializeField] protected int attack1Power, attack2Power, attack3Power;
    [SerializeField] protected float speed;
    [SerializeField] protected float jumpPower;
    [SerializeField] protected int superCost;
    [SerializeField] protected int superMax;
    [SerializeField] protected int attack1SuperValue;
    [SerializeField]
    protected float attack1CooldownTime = 1, attack2CooldownTime = 2;
    protected bool attack1Available = true, attack2Available = true;


    //basic player stats attributes
    [SerializeField] protected RangerType ranger; //this will hold what type of ranger this player is
    [SerializeField] protected int playerNum;
    protected int superCurrent;
    [SerializeField] protected Color playerColor;
    private Key key;
    private int keyDamage; //current amount of damage taken while holding key
    [SerializeField] private int keyDamageMax; //the max amount of damage player can take before lossing key
    [SerializeField] private bool keyPickup;//if player can pick up key
    private float keyPickupTime = 0; //after drop, how long before can pick up again
    [SerializeField] private float keyPickupTimeMax; //amount of time before player can pick key up again
    private float keyCurrentTime = 0; //amount of time player has before winning

    //basic ranger physic attributes
    [SerializeField] protected bool facingLeft;
    protected Vector3 postition;
    protected Vector2 velocity;
    [SerializeField] protected bool grounded;
    protected Rigidbody2D rBody;
    private bool airControl; //controls whether player is allow to be moved while in the air.
    [SerializeField] private LayerMask ground;

    //other attributes
    protected InputSettings input = new InputSettings();
    protected WorldController worldControl;

	public bool canMove = true;
	public bool canBeHit=true;

    //Status effects attributes
    public bool frozen = false;
    private StatusEffect dartEffect = StatusEffect.None;
    private float dartCurrentTime;
    private float dartMaxTime;
    private bool poisoned = false;
    private int cloudDamage;
    private float poisonedCurrentTime = 0;
    private float poisonedMaxTime;
	private float vinesTime = 0;
	private string colorString;
	private GameObject damageSpawn;

    //animation Attributes
    [SerializeField]
    private Animator rangerAnimator;
    private bool startedMoving = false;
    private bool startedStill = false;

    //Sounds Attributes
    protected AudioSource rangerAudio;
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

    public Rigidbody2D RBody
    {
        get { return rBody; }
    }

    public bool KeyPickup
    {
        get { return keyPickup; }
        set { keyPickup = value; }
    }

    public float KeyCurrentTime
    {
        get { return keyCurrentTime; }
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

    public int SuperMax
    {
        get { return superMax; }
    }

    public bool FacingLeft
    {
        get { return facingLeft; }
    }

    public int Attack2Power
    {
        get { return attack2Power; }
    }

    public int Attack3Power
    {
        get { return attack3Power; }
    }

    public WorldController WorldControl
    {
        get { return worldControl; }
    }

    public bool Grounded
    {
        get { return grounded; }
        set { grounded = value; }
    }

    public bool Poisoned
    {
        set { poisoned = value; }
    }

    public Color RangerColor
    {
        get { return playerColor; }
    }

	public float VinesTime{
		get{return vinesTime;}
		set{vinesTime=value;}
	}

    public Animator RangerAnimator
    {
        get { return rangerAnimator; }
    }

    public AudioSource RangerAudio
    {
        get { return rangerAudio; }
    }
    #endregion

    #region Methods
    
    // Use this for initialization
    protected virtual void Start () {
        //get the world Controller
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();

        //setup input
        input.ConfigureInput(PlayerNum);

        //get physic stuff for ranger
        postition = transform.position;
        rBody = GetComponent<Rigidbody2D>();
        rBody.mass = 1.0f;
        keyDamage = 0;

		damageSpawn = transform.Find ("damageSpawnPoint").gameObject;
		if (ranger == RangerType.RedRanger) { colorString="red"; }
		if (ranger == RangerType.YellowRanger) { colorString="yellow"; }
		if (ranger == RangerType.GreenRanger) { colorString="green"; }
		if (ranger == RangerType.BlueRanger) { colorString="blue"; }
		if (ranger == RangerType.PinkRanger) { colorString="pink"; }
		if (ranger == RangerType.BlackRanger) { colorString="black"; }

        rangerAudio = GetComponent<AudioSource>();
	}
	
    protected virtual void FixedUpdate()
    {
        CheckIsAlive(); //Checks to make sure the player is in fact alive
        CheckHasWon();
        GetInput(); //gets all the input from the player

        if (!frozen && canMove)
        {
            Move(); // moves the ranger based on player input
            Jump();
            Dodge();
            Attack1();
        }

        //stop ranger velocity if there is no input and ranger is grounded
        if (input.fwdInput == 0 && grounded) //if there is no input and the character is on the ground
        {
            if (GameObject.FindGameObjectWithTag("Black Hole") != null)//black hole
            {
                GameObject hole = GameObject.FindGameObjectWithTag("Black Hole");
                //player is within range of black hole and not caster of black hole
                if (Mathf.Abs((transform.position - hole.transform.position).magnitude) <= hole.GetComponent<BlackHoleScript>().PullRange || playerNum != hole.GetComponent<BlackHoleScript>().PlayerNum) {
                    //nothing happens
                    //do not change this, is blank piece is on purpose
                }
                else if (rBody.velocity != Vector2.zero)
                {
                    if (playerNum == 1) { Debug.Log("stop slide(grounded)"); }
                    rBody.velocity = rBody.velocity.x * Vector2.zero; // stops character 
                }
            }
			else if(rBody.velocity!=Vector2.zero){
				if(playerNum ==1){Debug.Log("stop slide(grounded)");}
            	rBody.velocity = rBody.velocity.x * Vector2.zero; // stops character 
			}
        }

        //status effect
        if(dartEffect != StatusEffect.None)
        {
            dartCurrentTime += Time.deltaTime;

            if(dartCurrentTime >= dartMaxTime)
            {
                dartCurrentTime = 0;
                dartEffect = StatusEffect.None;
                setColorOfRanger(Color.white);
            }
        }

        if (grounded) //if ranger is grounded it turns air control back on
        {
            airControl = true;
		}

        if (!keyPickup)//keypickup is false
        {
            if(keyPickupTime >= keyPickupTimeMax)
            {
                keyPickup = true;
                keyPickupTime = 0;
                Debug.Log(name + " can pickup key again");
            }
            keyPickupTime += Time.deltaTime;
        }

        ///Remove Later After First Build
        if (input.pause)
        {
            worldControl.battleSetup = false; 
            Destroy(worldControl.gameObject);
            Application.LoadLevel(0);
        }
        if(Input.GetButtonDown("Back"))
        {
            Application.Quit();
        }
        ///////////////////////////////
    }

    protected void GetInput()
    {
        //gets all value based input checks
        input.fwdInput = Input.GetAxis(input.HORIZONTAL_AXIS);
        input.dodgeInput = Input.GetAxis(input.DODGE_AXIS);

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
        if (!input.attack3)
        {
            input.attack3 = Input.GetButtonDown(input.ATTACK3_AXIS);
        }
        if (!input.pause)
        {
            input.pause = Input.GetButtonDown(input.PAUSE_AXIS);
        }
    }

    protected void Flip() //used to flip the ranger asset
    {
        facingLeft = !facingLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    protected void CheckIsAlive() //used to check if player is still alive
    {
        if(health <= 0)
        {
            DestroyRanger();
        }
    }

    protected void CheckHasWon()
    {
        if(keyCurrentTime >= worldControl.KeyMaxTime)
        {
            worldControl.win(ranger);
            Debug.Log("Player " + gameObject + " has won");
        }
    }

    #region GameMechanic/Movement Methods
    protected virtual void Move() //this method controls how the ranger moves
    {
        if(Mathf.Abs(input.fwdInput)> input.delay) //make sure the input is greater than the input.delay
        {
            if (!startedMoving)
            {
                rangerAnimator.Play("Run");
            }
            startedMoving = true;
            startedStill = false;
            if(airControl || grounded) //if aircontrol or grounded is true
            {
                if (dartEffect == StatusEffect.Speed)
                {
                    rBody.velocity = new Vector2(input.fwdInput * (speed/2), rBody.velocity.y); // moves player based on input
                }
                else
                {
                    rBody.velocity = new Vector2(input.fwdInput * speed, rBody.velocity.y); // moves player based on input
                }
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
        else
        {
            if (!startedStill) {
                rangerAnimator.Play("Idle");
                startedStill = true;
            }
            startedMoving = false;
        }
    }

    protected void Jump() //used to make the player jump
    {
		if(input.jump && grounded) // if jump button is pressed and player is grounded
        {
            SoundManager.Instance.PlaySound(rangerAudio, "Jump", 1.0f);
            rangerAnimator.Play("Jump");
            if (dartEffect == StatusEffect.Jump)
            {
                rBody.AddForce(new Vector2(0f, jumpPower/2));//add a force to cause the player to jump
            }
            else
            {
                rBody.AddForce(new Vector2(0f, jumpPower));//add a force to cause the player to jump
            }
        }
    }

    protected void Dodge()
    {
        if (input.dodge && grounded) //a dodge button has been pressed
        {
            rangerAnimator.Play("Dodge");
            if(input.dodgeInput > 0)
            {
		        Debug.Log("dodgeA");
                rBody.AddForce(new Vector2(5000f, 0f));
                rBody.MovePosition(rBody.position + new Vector2(5, 0));
            }
            else
            {
		        Debug.Log("dodgeB");
                rBody.AddForce(new Vector2(-5000f, 0f));
		        rBody.MovePosition(rBody.position + new Vector2(-5, 0));
                //rBody.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 10, transform.position.y), 20 * Time.deltaTime);
            }
        }
    }

    protected virtual void Attack1()
    {
        if (input.attack1 && attack1Available)
        {
            if (Mathf.Abs(input.fwdInput) > input.delay) //make sure the input is greater than the input.delay
            {
               
                rangerAnimator.Play("MeleeMelee");
            }
            else {
                //Debug.Log("att1");
                rangerAnimator.Play("Melee");
                //rangerAnimator.layer
            }

            int attack1Range = 3; //the range of the melee attack for the ranger
            Collider2D[] cols; //holds the colliders of the gameobjects the ranger punches

            if (facingLeft)
            {
                cols = Physics2D.OverlapAreaAll(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - attack1Range, transform.position.y + 1));  // gets all colliders within attack range
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - attack1Range, transform.position.y), playerColor, 2, false); //draws the debug line for attack
            }
            else
            {
                cols = Physics2D.OverlapAreaAll(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + attack1Range, transform.position.y + 1));  // gets all colliders within attack range
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + attack1Range, transform.position.y), playerColor, 2, false); //draws the debug line for attack
            }

            for(int i = 0; i< cols.Length; i++)
            {
                if (cols[i].tag == "Player" && cols[i] != gameObject.GetComponent<Collider2D>()) //checks to make sure the thing is another ranger and not yourself
                {
                    Player ranger = cols[i].GetComponent<Player>();

					if(canBeHit){
                        if (dartEffect == StatusEffect.AttackPower)
                        {
                            rangerAudio.clip = SoundManager.Instance.GetPunch();
                            rangerAudio.Play();
                            ranger.ModHealth(-(attack1Power / 2));
                        }
                        else
                        {
                            rangerAudio.clip = SoundManager.Instance.GetPunch();
                            rangerAudio.Play();
                            ranger.ModHealth(-attack1Power); //decrease enemy ranger health by attack1Power damage
                        }
                    SuperCurrent += attack1SuperValue; //increase super meter by attack 1 super value
                    
					//Debug.Log(gameObject.name + " has hit " + cols[i].name + "for " + attack1Power + "damage");// debugs what ranger hit and for how much damage.
					}
				}
            }

            StartCoroutine(Attack1Cooldown()); //starts the attack 1 cooldown coroutine
           // rangerAnimator.SetInteger("State", 0);
        }
    }

    abstract protected void Attack2();

    abstract protected void SuperAttack();

    #endregion

    #region Cooldown Methods
    //Attack 1 Cooldown
    protected virtual IEnumerator Attack1Cooldown()
    {
        attack1Available = false; //set attack 1 to unavailable

        yield return new WaitForSeconds(attack1CooldownTime); //wait for cooldown time

        attack1Available = true; //makes attack 1 available again
    }
    //Attack 2 Cooldown
    protected virtual IEnumerator Attack2Cooldown()
    {
        attack2Available = false; //set attack 1 to unavailable

        yield return new WaitForSeconds(attack2CooldownTime); //wait for cooldown time

        attack2Available = true; //makes attack 1 available again
    }
    #endregion

    public virtual void DestroyRanger()
    {
        if(key != null)
        {
            key.GetComponent<Key>().drop();
        }
        SoundManager.Instance.PlayDeath();
        rangerAnimator.Play("Dead");
        worldControl.StartCoroutine(worldControl.Respawn(playerNum, ranger));
        Destroy(gameObject);
        Debug.Log("Ranger has been destroyed");

    }

    public void ModHealth(int mod) //adds/subtracts from health
    {
		if (canBeHit) {
			Health += mod;
			//if there is a damage spawner, spawn damage marker
			if(GameObject.Find ("damageSpawner") != null){ 
				GameObject.Find("damageSpawner").GetComponent<damageScript>().takeDamage(mod,colorString,damageSpawn.transform.position); 
			}
			if (key != null) {
				keyDamage -= mod;
				if (keyDamage >= keyDamageMax) {
					key.GetComponent<Key> ().drop ();
					key = null;
					//keyDamage = 0;
				}
			}
		}
    }

	protected virtual void OnCollisionEnter2D(Collision2D other){
		//if player hits an object while in the air then air control is turned off so that players cant hang on to obstacle.
		if (!grounded)
		{
			airControl = false;
		}
		//key pick up
		if(other.gameObject.tag == "Key")//colliding with the key
		{
			if(other.gameObject.GetComponent<Key>().Holder == null && keyPickup)//no one is holding the key & ranger can pick it up
			{
				other.gameObject.GetComponent<Key>().Holder = gameObject;
				key = other.gameObject.GetComponent<Key>();
				keyDamage = 0;
				key.pickedUp();
				
			}
		}
	}

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {   
        //key pick up
        if(other.gameObject.tag == "Key")//colliding with the key
        {
            if(other.gameObject.GetComponent<Key>().Holder == null && keyPickup)//no one is holding the key & ranger can pick it up
            {
                other.gameObject.GetComponent<Key>().Holder = gameObject;
                key = other.gameObject.GetComponent<Key>();
                keyDamage = 0;
                key.pickedUp();
            }
        }
        if (other.gameObject.tag == "Goal")//colliding with their goal
        {
            if (key != null && playerNum == other.gameObject.GetComponent<Goal>().PlayerNum)//has the key and same color
            {
                key.BatteryAudioSource.Play();
                key.GetComponent<Animator>().Play("BatteryUp");
            }
        }
        if (other.gameObject.tag == "Poison Cloud")
        {
            cloudDamage = other.gameObject.GetComponent<PoisonCloud>().CloudDamage;
            poisonedMaxTime = other.gameObject.GetComponent<PoisonCloud>().PoisonTime;
        }
        if(other.gameObject.tag == "Warp")
        {
            if(ranger != RangerType.BlackRanger)
            {
                //ModHealth(other.gameObject.GetComponent<>().Damage);
                ModHealth(-2);
            }
        }
        if (other.gameObject.tag == "Stat Dart")
        {
            if (other.gameObject.GetComponent<statDartScript>().PlayerNum != playerNum)
            {
                switch (other.gameObject.GetComponent<statDartScript>().Effect)
                {
                    case 1:
                        dartEffect = StatusEffect.AttackPower;
                        setColorOfRanger(Color.red);
                        break;
                    case 2:
                        dartEffect = StatusEffect.Speed;
                        setColorOfRanger(Color.yellow);
                        break;
                    case 3:
                        dartEffect = StatusEffect.Jump;
                        setColorOfRanger(Color.green);
                        break;
                    default:
                        dartEffect = StatusEffect.None;
                        setColorOfRanger(Color.white);
                        break;
                }
                dartCurrentTime = 0;
                dartMaxTime = other.gameObject.GetComponent<statDartScript>().StatusTimeMax;
                ModHealth(-other.gameObject.GetComponent<statDartScript>().DamageAmount);
                Destroy(other.gameObject);
            }
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")//colliding with their goal
		{
            if (key != null && playerNum == other.gameObject.GetComponent<Goal>().PlayerNum)//has the key and same color
			{
				keyCurrentTime += Time.deltaTime;
            }
		}
        //poisoned
        if (other.gameObject.tag == "Poison Cloud")
        {
            if (playerNum != other.gameObject.GetComponent<PoisonCloud>().PlayerNum) {
                poisonedCurrentTime += Time.deltaTime;
                Debug.Log("Poisoned " + name + " : " + poisonedCurrentTime + " : " + poisonedMaxTime);
                if (poisonedCurrentTime >= poisonedMaxTime)
                {
                    Debug.Log("Poisoned damage " + name);
                    poisonedCurrentTime = 0;
                    ModHealth(-cloudDamage);
                }
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")//colliding with their goal
        {
            if (key != null && playerNum == other.gameObject.GetComponent<Goal>().PlayerNum)//has the key and same color
            {
                key.BatteryAudioSource.Stop();
                key.GetComponent<Animator>().Play("BatteryDown");
            }
        }
    }

	//enable air control
	protected virtual void OnCollisionExit2D(Collision2D coll)
	{
		if (!grounded)
		{
			airControl= true;
		}
	}

    protected virtual void setColorOfRanger(Color choiceColor)
    {
        SpriteRenderer[] sra = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sr in sra)
        {
            sr.color = choiceColor;
        }
    }

    protected virtual void OnDrawGizmos() //used to draw gizmos for debugging
    {
        Gizmos.color = Color.yellow;
	}
    #endregion
}
