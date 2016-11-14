using UnityEngine;
using System.Collections;
using System;

public class RedRanger : Player {

	GameObject sword;
	GameObject punch;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        playerColor = Color.red;

		//use the alternate attack using the hitboxes
		sword = gameObject.transform.FindChild("Sword").gameObject;
		sword.SetActive (false);
		punch = gameObject.transform.FindChild ("Fist").gameObject;
		punch.SetActive (false);
	}
	
	// Update is called once per frame
	protected override void FixedUpdate () {
        base.FixedUpdate();

		if (canMove) {
			Attack2 ();
			SuperAttack ();
		}

        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
        if (input.attack2) {
			if(playerNum ==1){Debug.Log("att2");}

			punch.SetActive(true);
			punch.GetComponent<Animator>().Play("punch");
		}
    }

    protected override void SuperAttack()
    {
		if (input.attack3 && SuperCurrent >= SuperCost) {

			if (playerNum == 1) {Debug.Log ("att3");}

			canMove=false;
			canBeHit=false;
			sword.SetActive(true);
			sword.GetComponent<Animator>().Play("swordEnter");
			SuperCurrent -= SuperCost;
		}
	}
}
