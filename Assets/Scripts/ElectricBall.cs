using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ElectricBall : MonoBehaviour {
    #region Attributes
    [SerializeField] private float speed = 5.0f; //speed of shuriken
    public bool moveLeft = true; //direction of shuriken
    private int damage; //shurikens damage value
    [SerializeField] private float rotationSpeed = 150.0f; // how fast it rotates
    [SerializeField] private int superValue; //the value added to the super meter current
    [SerializeField] private float ElectricBallLifetime = 2.0f; //how long the electric ball will last for
    private YellowRanger yellowRanger;
    private Rigidbody2D rBody2D;
    #endregion

    // Use this for initialization
    void Start () {
        yellowRanger = GameObject.Find("Yellow_BetaRanger(Clone)").GetComponent<YellowRanger>(); //gets the yellow ranger

        //assigns the values for move left,and damage based off of the yellow rangers data.
        moveLeft = yellowRanger.FacingLeft;
        damage = yellowRanger.Attack2Power;

        if (!moveLeft) //if not moving left then
        {
            Flip(); //flip asset
        }


        rBody2D = gameObject.GetComponent<Rigidbody2D>(); //get the electric ball rigidbody2D
        StartCoroutine(ElectricBallDuration()); //starts electric ball duration countdown
    }
	
	// Update is called once per frame
	void Update () {
        if (moveLeft) //if Electric Ball is moving left
        {
            //moves Electric Ball left and rotates counter clockwise
            rBody2D.velocity = new Vector2(-speed, 0);
            transform.Rotate(Vector3.forward, rotationSpeed*Time.deltaTime);
        }
        else //Electric Ball is moving right
        {
            //Electric Ball is asset is flip to the correct direction and Electric Ball is moved right and rotates clockwise
            rBody2D.velocity = new Vector2(speed, 0);
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            
        }
	}

    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Player" && thing.name != "Yellow_BetaRanger(Clone)") //if collision is with another ranger
        {
            Start();
            thing.gameObject.GetComponent<Player>().ModHealth(-damage); //gets the base player script and inflicts the damage on the player
            Debug.Log(thing.name + "hit with Electric Ball for " + damage);
            Destroy(gameObject); //destroys the Electric Ball
            yellowRanger.ElectricBallCount--;
            
        }
        else if(thing.name == "Yellow_BetaRanger(Clone)" || thing.tag == "Hitbox" || thing.tag == "Goal")
        {
            //do nothing
        }
        else //if collison is not a ranger then destroys Electric Ball
        {
            Destroy(gameObject);
            yellowRanger.ElectricBallCount--;
        }
    }

    void OnTriggerExit2D(Collider2D thing)
    {
    }

    void Flip()
    {
        //flips art asset horizontally.
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }

    private IEnumerator ElectricBallDuration()
    {
        yield return new WaitForSeconds(ElectricBallLifetime);
        yellowRanger.ElectricBallCount--;
        Destroy(gameObject);
    }
}
