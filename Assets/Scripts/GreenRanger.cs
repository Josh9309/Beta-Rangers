using UnityEngine;
using System.Collections;
using System;

public class GreenRanger : Player {
	[SerializeField] GameObject earthwave;
	[SerializeField] GameObject vines;
	[SerializeField] public float vinesStayTime;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = Color.green;

		//use the alternate attack using the hitboxes
		vines.GetComponent<vines>().scale = transform.Find("GroundCheck").transform.localScale;
		vines.GetComponent<vines> ().Detach ();

		vines.SetActive (false);
		earthwave.SetActive (false);
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

		if (canMove) {
			Attack2 ();
			SuperAttack ();
		}

        //reset btn inputs
        input.ResetBtns();
    }

	protected override void Attack2()//earthwave
	{
		if (input.attack2 && attack2Available && grounded)
		{
			if(playerNum == 1){Debug.Log("att2");}

			canMove=false;
			vines.GetComponent<vines>().Attach();

			earthwave.SetActive(true);
			StartCoroutine(Attack2Cooldown()); //starts attack 2 cooldown timer
		}
	}
	
	protected override void SuperAttack()//vines
	{
		if (input.attack3 && SuperCurrent >= SuperCost) {
			
			if (playerNum == 1) {Debug.Log ("att3");}

			vines.SetActive(true);
			vines.GetComponent<vines>().Attach();

			vines.transform.parent=null;
			vines.GetComponent<vines>().Detach();
			SuperCurrent -= SuperCost;
		}
	}
}
