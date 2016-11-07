using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    //Attributes
    private Player holder;
    private Rigidbody2D rBody;

    //properties
    public Player Holder
    {
        get { return holder; }
        set { holder = value; }
    }

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
