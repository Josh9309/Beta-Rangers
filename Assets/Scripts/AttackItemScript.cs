using UnityEngine;
using System.Collections;

public class AttackItemScript : MonoBehaviour {

	bool colliding = false;

	public GameObject ranger;
	private Player player;
	private GameObject root;

	public bool IsCollliding{get{return colliding;}}
	private Animator animator;

	// Use this for initialization
	void Start () {
		ranger = transform.parent.parent.gameObject;
		player = ranger.GetComponent<Player> ();
		animator = transform.parent.GetComponent<Animator> ();
		root = transform.parent.gameObject;
	}


	// Update is called once per frame
	void Update () {
		if (name == "Blade") {
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("swordExit")) {
				if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
					player.canMove=true;
					player.canBeHit=true;
					root.SetActive(false);
				}
			}
		}
		if (name == "Punch") {
			if (animator.GetCurrentAnimatorStateInfo (0).IsName ("punch")) {
				if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !animator.IsInTransition (0)) {
					root.SetActive(false);
				}
			}
		}
	}
	
	//calls the parents child collider method
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {

			if (other.tag == "Player") {
				if (name == "Blade") {
					if (player.PlayerNum == 1) {
						//Debug.Log ("sword enter " + other.gameObject.name);
						Player otherRanger = other.GetComponent<Player> ();
						otherRanger.ModHealth (-player.Attack3Power); //decrease enemy ranger health by attack1Power damage
						Debug.Log (gameObject.name + " has hit " + other.name + " for " + player.Attack3Power + " damage");// debugs what ranger hit and for how much damage.
					}
				}
				if (name == "Punch") {
					//Debug.Log ("punch enter " + other.gameObject.name);
					Player otherRanger = other.GetComponent<Player> ();
					otherRanger.ModHealth (-player.Attack2Power); //decrease enemy ranger health by attack1Power damage
					Debug.Log (gameObject.name + " has hit " + other.name + " for " + player.Attack2Power + " damage");// debugs what ranger hit and for how much damage.
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
				if (player.PlayerNum == 1) {Debug.Log (name+" exit " + other.gameObject.name);}
			}
		}
	}
}
