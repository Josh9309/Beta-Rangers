using UnityEngine;
using System.Collections;
using System;

public class RedRanger : Player {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        playerColor = Color.red;
	}
	
	// Update is called once per frame
	protected override void FixedUpdate () {
        base.FixedUpdate();


        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
		if(playerNum ==1){Debug.Log("att2");}
	}

    protected override void SuperAttack()
    {
		if(playerNum ==1){Debug.Log("att3");}
	}
}
