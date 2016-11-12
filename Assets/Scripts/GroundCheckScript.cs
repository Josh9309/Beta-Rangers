﻿using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour {
    private bool colliding=false;
	private GameObject parent;
    private Player player;

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" || other.tag == "Player")
        {
            player.Grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Platform" || other.tag == "Player")
        {
            player.Grounded = true;
        }
    }

    //calls the parents child collider method
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            player.Grounded = false;
        }
    }
}
