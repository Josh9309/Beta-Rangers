using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class IceShuriken : MonoBehaviour {
    #region Attributes
    [SerializeField] private float speed = 5.0f; //speed of shuriken
    public bool moveLeft = true; //direction of shuriken
    private int damage; //shurikens damage value
    [SerializeField] private float rotationSpeed = 150.0f; // how fast it rotates
    [SerializeField] private int superValue; //the value added to the super meter current
    private BlueRanger blueRanger;
    private Rigidbody2D rBody2D;
    #endregion

    // Use this for initialization
    void Start () {
        blueRanger = GameObject.Find("Blue_BetaRanger").GetComponent<BlueRanger>();
        moveLeft = blueRanger.FacingLeft;
        damage = blueRanger.Attack2Power;
        rBody2D = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveLeft) //if shuriken is moving left
        {
            //moves shuriken left and rotates counter clockwise
            rBody2D.velocity = new Vector2(-speed, 0);
            transform.Rotate(Vector3.forward, rotationSpeed*Time.deltaTime);
        }
        else //shuriken is moving right
        {
            //shuriken is asset is flip to the correct direction and shuriken is moved right and rotates clockwise
            rBody2D.velocity = new Vector2(speed, 0);
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            Flip();
        }
	}

    //this was an attempted code to make shuriken destruction less abrupt, 
    // I decided to put this on the back burner for polish.
    //private IEnumerator DestroyShurikenCoroutine()
    //{
    //    yield return new WaitForSeconds(0.3f);

    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Player" && thing.name != "Blue_BetaRanger") //if collision is with another ranger
        {
            thing.gameObject.GetComponent<Player>().ModHealth(-damage); //gets the base player script and inflicts the damage on the player
            blueRanger.SuperCurrent += superValue; //adds super value to current super meter value.
            Debug.Log(thing.name + "hit with ice shuriken for " + damage);
            Destroy(gameObject); //destroys the shuriken
            blueRanger.ShurikenCount--;
            
        }
        else if(thing.name == "Blue_BetaRanger")
        {
            //do nothing
        }
        else //if collison is not a ranger then destroys ice shuriken
        {
            Destroy(gameObject);
            blueRanger.ShurikenCount--;
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
}
