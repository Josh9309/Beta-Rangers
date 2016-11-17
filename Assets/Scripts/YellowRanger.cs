using UnityEngine;
using System.Collections;
using System;

public class YellowRanger : Player {
    #region Attributes
    [SerializeField] private GameObject electricBallPrefab;
    private int electricBallCount = 0;
    private int electricBallMax = 3;

    #endregion

    #region Properties
    public int ElectricBallCount
    {
        get { return electricBallCount; }
        set
        {
            if (value < 0)
            {
                electricBallCount = 0;
            }
            else
            {
                electricBallCount = value;
            }
        }
    }
    #endregion

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = Color.yellow;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!frozen)
        {
            Attack2();
        }

        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
        if (input.attack2 && electricBallCount < electricBallMax && attack2Available) //checks to make sure button has been pressed and that we have not hit max shurikens on the screen
        {
            GameObject electricBall;

            //makes the ice shuriken depending on the direction player is facing
            if (facingLeft)
            {
                electricBall = Instantiate(electricBallPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                electricBallCount++;
            }
            else
            {
                electricBall = Instantiate(electricBallPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                electricBallCount++;
            }

            StartCoroutine(Attack2Cooldown());
        }
    }

    protected override void SuperAttack()
    {
        throw new NotImplementedException();
    }
}
