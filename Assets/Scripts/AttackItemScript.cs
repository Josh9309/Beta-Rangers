using UnityEngine;
using System.Collections;

public class AttackItemScript : MonoBehaviour {
    private enum AttackItem { FLAMESWORD, FLAMEPUNCH};
	private bool colliding = false;

	[SerializeField] private GameObject ranger;
	private Player player;
	private GameObject root;
    [SerializeField] private AttackItem itemType;

	
	private Animator animator;
    [SerializeField] private int superValue;

    public bool Collliding {
        get { return colliding; }
    }

    // Use this for initialization
    void Start () {
		player = ranger.GetComponent<Player> ();
		animator = transform.parent.GetComponent<Animator> ();
		root = transform.parent.gameObject;
	}


	// Update is called once per frame
	void Update () {
        switch (itemType)
        {
            case AttackItem.FLAMESWORD: //flame sword update code
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("swordExit"))
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
                    {
                        player.canMove = true;
                        player.canBeHit = true;
                        root.SetActive(false);
                    }
                }
                break;

            case AttackItem.FLAMEPUNCH: //flame punch update code
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("punch"))
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
                    {
                        root.SetActive(false);
                    }
                }
                break;
        }
	}
	
	//calls the parents child collider method
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {

			if (other.tag == "Player") {
                Start();
                Player otherRanger;
                switch (itemType)
                {
                    case AttackItem.FLAMESWORD: //flame sword update code  
                        //Debug.Log ("sword enter " + other.gameObject.name);
                        otherRanger = other.GetComponent<Player>();
                        otherRanger.ModHealth(-player.Attack3Power); //decrease enemy ranger health by attack1Power damage
                        Debug.Log(gameObject.name + " has hit " + other.name + " for " + player.Attack3Power + " damage");// debugs what ranger hit and for how much damage.

                        break;

                    case AttackItem.FLAMEPUNCH: //flame punch update code
                        //Debug.Log ("punch enter " + other.gameObject.name);
                        otherRanger = other.GetComponent<Player>();
                        otherRanger.ModHealth(-player.Attack2Power); //decrease enemy ranger health by attack1Power damage
                        player.SuperCurrent += superValue;
                        Debug.Log(gameObject.name + " has hit " + other.name + " for " + player.Attack2Power + " damage");// debugs what ranger hit and for how much damage.
                        break;
                }
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {

		}
	}
	
	//calls the parents child collider method
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {

			if (other.tag == "Player") {
				//if (player.PlayerNum == 1) {Debug.Log (name+" exit " + other.gameObject.name);}
			}
		}
	}
}
