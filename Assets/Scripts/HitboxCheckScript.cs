using UnityEngine;
using System.Collections;

public class HitboxCheckScript : MonoBehaviour {

	bool colliding=false;
	public GameObject parent;
	
	public bool IsCollliding{get{return colliding;}}
	
	// Use this for initialization
	void Start () {
		parent= transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//calls the parents child collider method
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != parent.name) {

			if (name == "GroundCheck") {
				//Debug.Log (gameObject.name+" collision enter: " + other.gameObject.name);
				if (other.gameObject.name != parent.name) {
					parent.SendMessage ("groundCollideEnter", other.gameObject);
				}
			}
			if (name == "Attack_1_HitRange") {
				//Debug.Log (gameObject.name+"collision enter: " + other.gameObject.name);
				parent.SendMessage ("hitCollideEnter", other.gameObject);
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name != parent.name) {
			if (name == "GroundCheck") {
				//Debug.Log (gameObject.name+"collision stay:  " + other.gameObject.name);
				parent.SendMessage ("groundCollideStay", other.gameObject);
			}
			if (name == "Attack_1_HitRange") {
				//Debug.Log (gameObject.name+"collision stay: " + other.gameObject.name);
				parent.SendMessage ("hitCollideStay", other.gameObject);
			}
		}
	}
	
	//calls the parents child collider method
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name != parent.name) {
			if (name == "GroundCheck") {
				//Debug.Log (gameObject.name+"collision exit: " + other.gameObject.name);
				parent.SendMessage ("groundCollideExit", other.gameObject);
			}
			if (name == "Attack_1_HitRange") {
				//Debug.Log (gameObject.name+"collision exit: " + other.gameObject.name);
				parent.SendMessage ("hitCollideExit", other.gameObject);
			}

		}
	}
}
