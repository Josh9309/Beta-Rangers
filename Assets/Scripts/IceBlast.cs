using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class IceBlast : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private float speed = 5.0f; //speed of ice blast
    public bool moveLeft = true; //direction of ice blast
    private int damage; //ice blast damage value
    [SerializeField] private float freezeTime = 2; //how many seconds enemy ranger will be frozen for
    [SerializeField] private int frozenDamage = 5; //this is the damage frozen ranger take while they are frozen
    [SerializeField] private float rotationSpeed = 150.0f; // how fast it rotates
    private BlueRanger blueRanger;
    private Rigidbody2D rBody2D;
    #endregion

    // Use this for initialization
    void Start () {
        blueRanger = GameObject.Find("Blue_BetaRanger").GetComponent<BlueRanger>();
        moveLeft = blueRanger.FacingLeft;
        damage = blueRanger.Attack3Power;
        rBody2D = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveLeft) //if ice blast is moving left
        {
            //moves ice blast left and rotates counter clockwise
            rBody2D.velocity = new Vector2(-speed, 0);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else //ice blast is moving right
        {
            //ice blast asset is flip to the correct direction and shuriken is moved right and rotates clockwise
            rBody2D.velocity = new Vector2(speed, 0);
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        Player enemyRanger;

        if (thing.tag == "Player" && thing.name != "Blue_BetaRanger") //if collision is with another ranger
        {
            enemyRanger = thing.gameObject.GetComponent<Player>();
            enemyRanger.ModHealth(-damage); //gets the base player script and inflicts the damage on the player

            Debug.Log(thing.name + "hit with ice blast for " + damage);

            //start frozen Corroutine
            StartCoroutine(blueRanger.WorldControl.Frozen(enemyRanger.PlayerNum, freezeTime, frozenDamage, gameObject));
            
            //turn off sprite render and Collider2D, then it makes rigidbody position frozen until frozen corroutine destroys ice blast shard.
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            rBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

        }
        else if (thing.name == "Blue_BetaRanger" || thing.tag == "Hitbox"|| thing.tag == "Goal")
        {
            //do nothing
        }
        else //if collison is not a ranger then destroys ice blast
        {
            Destroy(gameObject);
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
