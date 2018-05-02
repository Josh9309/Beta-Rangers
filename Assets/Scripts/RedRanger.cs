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
		sword = gameObject.transform.Find("Sword").gameObject;
		sword.SetActive (false);
		punch = gameObject.transform.Find ("Fist").gameObject;
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

    protected override void Attack2()//Super Punch
    {
        if (input.attack2 && attack2Available)
        {
			if(playerNum ==1){Debug.Log("att2");}

			punch.SetActive(true);
			punch.GetComponent<Animator>().Play("punch");
            StartCoroutine(Attack2Cooldown()); //starts attack 2 cooldown timer
		}
    }

    protected override void SuperAttack()//blazing sword
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

    public void PlaySwordSounds(int swordStage) //0 = swordEnter, 1 = swordSwing, 2 = swordSheath
    {
        switch (swordStage)
        {
            case 0:
                SoundManager.Instance.PlaySound(rangerAudio, "RedSwordEnter");
                break;

            case 1:
                SoundManager.Instance.PlaySound(rangerAudio, "RedSwordSwing");
                break;

            case 2:
                SoundManager.Instance.PlaySound(rangerAudio, "RedSwordExit");
                break;
        }
    }
}
