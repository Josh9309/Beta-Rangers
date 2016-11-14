using UnityEngine;
using System.Collections;
using System;

public class BlackRanger : Player {

    [SerializeField] private GameObject WarpPrefab;
    [SerializeField] private GameObject BlackHolePrefab;
    [SerializeField] private float BlackHoleStrength; //how strong the pull of the black hole is
    [SerializeField] private float BlackHolePullRange; //how far the black hole will pull other players
    [SerializeField] private float BlackHoleSpeed; //How fast the black hole moves to point
    [SerializeField] private float BlackHoleMoveTime; //the amount of time the black hole moves for
    [SerializeField] private float BlackHoleStillTime; //the amount of time the black hole stays still for

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = Color.black;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Attack2();
        SuperAttack();

        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()//Warp
    {
        if (input.attack2 && attack2Available)
        {
            Debug.Log("Warp");
        }
    }

    protected override void SuperAttack()//Black Hole
    {
        if (input.attack3 && SuperCurrent >= SuperCost)
        {
            Debug.Log("BLACK HOLE!");
            GameObject b = GameObject.Instantiate(BlackHolePrefab) as GameObject;
            if (facingLeft) {
                b.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            }
            else
            {
                b.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            }
            b.GetComponent<BlackHoleScript>().startUp(playerNum, facingLeft, BlackHoleStrength, BlackHolePullRange, BlackHoleSpeed, BlackHoleMoveTime, BlackHoleStillTime);
            SuperCurrent -= SuperCost;
        }
    }
}
