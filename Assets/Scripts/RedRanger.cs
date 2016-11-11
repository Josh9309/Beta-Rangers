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

	protected override void Attack(GameObject other)
	{
		if (Input.GetButtonDown(input.ATTACK1_AXIS) && !frozen) {
			if (playerNum == 1) { Debug.Log ("att1"); }
			
			Player ranger = other.GetComponent<Player> ();
			
			other.GetComponent<Player>().ModHealth (-attack1Power); //decrease enemy ranger health by attack1Power damage
			SuperCurrent += attack1SuperValue; //increase super meter by attack 1 super value
			
			Debug.Log (gameObject.name + " has hit " + other.name + " for " + attack1Power + " damage");// debugs what ranger hit and for how much damage.
			return; //to prevent multiple attacks at once
		}
		
		if (Input.GetButtonDown(input.ATTACK2_AXIS) && !frozen) {
			Attack2();
		}
		if (Input.GetButtonDown(input.ATTACK3_AXIS) && !frozen) {
			SuperAttack();
		}
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
