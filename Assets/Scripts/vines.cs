using UnityEngine;
using System.Collections;

public class vines : MonoBehaviour {

	private bool colliding = false;
	
	[SerializeField] private GameObject ranger;
	private Player player;
	private GameObject root;

	[SerializeField] private int superValue;
	public Vector3 scale;
	private float time=0;

	// Use this for initialization
	void Start () {
		player = ranger.GetComponent<Player> ();
		scale = transform.localScale;
		Attach ();
	}

	public void Attach(){
		transform.position = ranger.transform.FindChild("GroundCheck").transform.position;
		transform.localScale = scale;

	}
	
	public void Detach(){
		transform.parent = null;
		transform.localScale = scale;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > ranger.GetComponent<GreenRanger>().vinesStayTime){
			Debug.Log("time up");
			gameObject.SetActive(false);
			time=0;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {
			
			if (other.tag == "Player") {
				Player otherRanger;
				otherRanger= other.GetComponent<Player>();
				otherRanger.ModHealth(-player.Attack3Power); //decrease enemy ranger health by attack1Power damage
				Debug.Log(gameObject.name + " has hit " + other.name + " for " + player.Attack3Power + " damage");// debugs what ranger hit and for how much damage.
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name != ranger.name) {
			
			if (other.tag == "Player") {
				Player otherRanger;

				otherRanger = other.GetComponent<Player>();
				otherRanger.VinesTime += Time.deltaTime;
				if( otherRanger.VinesTime > 1.2){
					Debug.Log("vines damage");
					otherRanger.VinesTime=0;
					otherRanger.ModHealth(-player.Attack3Power); //decrease enemy ranger health by attack1Power damage
				}
			}
		}
	}

}
