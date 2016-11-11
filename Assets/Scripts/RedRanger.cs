using UnityEngine;
using System.Collections;
using System;

public class RedRanger : Player {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        playerColor = Color.red;

		//use the alternate attack using the hitboxes
		altAtt = true;
	}
	
	// Update is called once per frame
	protected override void FixedUpdate () {
        base.FixedUpdate();


        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
        if (input.attack2)
        {
            //Debug.Log("att1");

            //Player ranger = other.GetComponent<Player>();

            //ranger.ModHealth(-attack1Power); //decrease enemy ranger health by attack1Power damage
            //SuperCurrent += attack1SuperValue; //increase super meter by attack 1 super value

            //Debug.Log(gameObject.name + " has hit " + other.name + " for " + attack1Power + " damage");// debugs what ranger hit and for how much damage.
        }
    }

    protected override void SuperAttack()
    {
		if(playerNum ==1){Debug.Log("att3");}
	}
}
