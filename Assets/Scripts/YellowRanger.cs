using UnityEngine;
using System.Collections;
using System;

public class YellowRanger : Player {
    #region Attributes
    [SerializeField] private GameObject electricBallPrefab; //holds the electric ball prefab
    private int electricBallCount = 0; //# of electric balls active in scene
    private int electricBallMax = 3; //Max # of electric balls allowed to be active in scene

    [SerializeField] private GameObject chainLightingPrefab; //hold the chain lighting shot prefab
    [SerializeField] private int chainedLightningDamage; //the damage done by the chain lighting
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

    public int ChainedLightningDamage
    {
        get { return chainedLightningDamage; }
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
            SuperAttack();
        }

        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
        if (input.attack2 && electricBallCount < electricBallMax && attack2Available) //checks to make sure button has been pressed and that we have not hit max electric balls on the screen
        {
            GameObject electricBall;

            //makes the Electric ball depending on the direction player is facing
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
        if (input.attack3 && SuperCurrent >= SuperCost) //checks to make sure button has been pressed and that we have enough super power to use the super
        {
            GameObject electricBolt;

            //makes the chain lighting shot depending on the direction player is facing
            if (facingLeft)
            {
                electricBolt = Instantiate(chainLightingPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            }
            else
            {
                electricBolt = Instantiate(chainLightingPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            }
        }
    }
}
