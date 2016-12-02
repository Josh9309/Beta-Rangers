using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ChainLighting : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private float speed = 5.0f; //speed of lighting shot
    public bool moveLeft = true; //direction of lighting shot
    private int lightningShotDamage; //lighting shot damage value
    private int chainDamage; //chain lighting damage
    private YellowRanger yellowRanger; 
    private Rigidbody2D rBody2D;
    private SpriteRenderer sprite; //lightning shot spritereneder
    private Collider2D lightningShotCollider; //lightning shot collider
    [SerializeField] private float chainRadius = 5.0f; //radius that the chain lighting can reach
    [SerializeField] private GameObject ChainLightingAsset; //holds the asset for chain lightning
    private int lightningActive = 0; //keeps a count of how many chains of lightning were made and are still active
    #endregion

    // Use this for initialization
    void Start () {

        yellowRanger = GameObject.Find("Yellow_BetaRanger(Clone)").GetComponent<YellowRanger>();  //gets the yellow ranger

        //assigns the values for move left,and damages based off of the yellow rangers data.
        moveLeft = yellowRanger.FacingLeft;
        lightningShotDamage = yellowRanger.Attack2Power;
        chainDamage = yellowRanger.ChainedLightningDamage;

        if (!moveLeft) //if not moving left then
        {
            Flip(); //flip the asset
        }

        //gets the rigid body, sprite renderer, and collider 2D that is attached to the lighting shot.
        rBody2D = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        lightningShotCollider = gameObject.GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveLeft) //if Lighting shot is moving left
        {
            //moves Lighting shot left
            rBody2D.velocity = new Vector2(-speed, 0);
        }
        else //Lighting shot is moving right
        {
            //lighting shot asset is flip to the correct direction and Lighting Shot is moved right
            rBody2D.velocity = new Vector2(speed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.tag == "Player" && thing.name != "Yellow_BetaRanger(Clone)") //if collision is with another ranger
        {
            Start(); //makes sure the start has been run before this method

            //deals lightning shot damage
            thing.gameObject.GetComponent<Player>().ModHealth(-lightningShotDamage); //gets the base player script and inflicts the damage on the player
            Debug.Log(thing.name + "hit with lighting shot for " + lightningShotDamage);

            //get all colliders within the chainRadius of the the hit ranger
            Collider2D[] objectColliders = Physics2D.OverlapCircleAll(thing.transform.position, chainRadius);

            //disables the lightning shot so that it is still active in scene but can not be seen or interact with scene.
            sprite.enabled = false;
            lightningShotCollider.enabled = false;

            //check to see if a player was hit
            for(int i = 0; i < objectColliders.Length; i++)
            {
                if (objectColliders[i].tag == "Player" && objectColliders[i].name != "Yellow_BetaRanger(Clone)") //if a player that is not yellow ranger is in chain radius
                {
                    lightningActive++;// increaments the # of chain lightning active

                    //deals chain lighting Damage
                    objectColliders[i].gameObject.GetComponent<Player>().ModHealth(-chainDamage);

                    ///creates the chain lighting and scales + orients the lighting properly
                    //gets the length between hit Ranger and the chained hit Ranger then divides that value by the chain radius to get the transform.x scale
                    float lightningScale = (objectColliders[i].transform.position - thing.transform.position).magnitude / chainRadius;

                    GameObject lightning = Instantiate(ChainLightingAsset, thing.transform.position, Quaternion.identity) as GameObject; //creates the chain lightning in scene

                    //orients the lightning
                    lightning.transform.right = (objectColliders[i].transform.position - thing.transform.position); //this sets the right vector of the lightning to be directed at the Chained Ranger
                    lightning.transform.localScale= new Vector3(lightningScale, 1, 1); //adjust x scaling of the lightning

                    StartCoroutine(LightningDuration(lightning)); //starts the corrutine that controls how long chain lighting is shown.

                    ///Debug Stuff (May be usefull later)
                    //Debug.Log(objectColliders[i].name + "gets hit by chain lighting");
                    // Debug.DrawLine(thing.transform.position, objectColliders[i].transform.position, Color.yellow, 1);
                }
            }

            
        }
        else if (thing.name == "Yellow_BetaRanger(Clone)" || thing.tag == "Hitbox" || thing.tag == "Goal")
        {
            //do nothing
        }
        else //if collison is not a ranger then destroys Electric Ball
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

     IEnumerator LightningDuration(GameObject lightningBolt)
    {
        yield return new WaitForSeconds(.2f);

        Destroy(lightningBolt); //destroys the chain lightning
        lightningActive--; //decreaments the chain lighting active by 1

        if (lightningActive == 0) //if there are no more chain lightning active 
        {
            Destroy(gameObject); //then destroy the lightning shot
        }

    }
}
