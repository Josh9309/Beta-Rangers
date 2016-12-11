using UnityEngine;
using System.Collections;

public class earthwave : MonoBehaviour {

	[SerializeField] private GameObject ranger;
	private Player player;
	private GameObject root;
	
	private Animator animator;
	[SerializeField] private int superValue;
	
	// Use this for initialization
	void Start () {
		player = ranger.GetComponent<Player> ();
		animator = transform.parent.GetComponent<Animator> ();
		root = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("done")) {
			root.SetActive(false);
			player.canMove=true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {
			
			if (other.tag == "Player") {
				Start();
				Player otherRanger;
				otherRanger = other.GetComponent<Player>();
				otherRanger.ModHealth(-player.Attack2Power); //decrease enemy ranger health by attack1Power damage
				Debug.Log(gameObject.name + " has hit " + other.name + " for " + player.Attack2Power + " damage");// debugs what ranger hit and for how much damage.
			}
		}
	}
}