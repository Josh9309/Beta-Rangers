﻿using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.tag == "Player")
        {
            thing.GetComponent<Player>().DestroyRanger();
        }
        if(thing.tag == "Key")
        {
            thing.GetComponent<Key>().droppedOffStage();
            thing.transform.position = GameObject.FindGameObjectWithTag("Key Spawn Point").transform.position;
        }
    }
}
