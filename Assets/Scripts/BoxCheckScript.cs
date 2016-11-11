using UnityEngine;
using System.Collections;

public class BoxCheckScript : MonoBehaviour {
    private enum CheckType { ATTACKHITBOX, GROUNDCHECK };

    private bool colliding=false;
	private GameObject parent;
    private Player player;
    [SerializeField] private CheckType check;

    public bool IsCollliding{
        get {return colliding;}
    }
	
	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
        player = parent.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//calls the parents child collider method
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != parent.name) {
            switch (check)
            {
                case CheckType.GROUNDCHECK:
                    if (other.tag == "Platform")
                    {
                        player.Grounded = true;
                    }
                    break;

                case CheckType.ATTACKHITBOX:
                    if (other.gameObject.CompareTag("Player"))
                    {
                        Debug.Log("hitbox collision enter: " + other.name);
                        player.Attack1(other.gameObject);
                    }
                    break;
            }
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name != parent.name) {
            switch (check)
            {
                case CheckType.GROUNDCHECK:
                    if (other.tag == "Platform")
                    {
                        player.Grounded = true;
                    }
                    break;

                case CheckType.ATTACKHITBOX:
                    if (other.gameObject.CompareTag("Player"))
                    {
                        //Debug.Log ("hitbox collision stay: "+other.name);
                        player.Attack1(other.gameObject);
                    }
                    break;
            }
        }
	}
	
	//calls the parents child collider method
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name != parent.name) {
            switch (check)
            {
                case CheckType.GROUNDCHECK:
                    if (other.tag == "Platform")
                    {
                        player.Grounded = false;
                    }
                    break;

                case CheckType.ATTACKHITBOX:

                    break;
            }

		}
	}
}
