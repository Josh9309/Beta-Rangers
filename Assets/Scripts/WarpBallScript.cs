using UnityEngine;
using System.Collections;
using System;

public class WarpBallScript : MonoBehaviour {

    int damage = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

}
