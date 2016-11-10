using UnityEngine;
using System.Collections;
using System;

public class BlueRanger : Player {

    #region Attributes
    [SerializeField] private GameObject IceShurikenPrefab;
    [SerializeField] private GameObject IceBlastPrefab;
    private int shurikenMax = 5; //max amount of shurikens allowed to be thrown at once on screen
    private int shurikenCount = 0; //current shurikens on the screen
    #endregion

    #region Properties
    public int ShurikenCount
    {
        get { return shurikenCount; }
        set
        {
            if (value < 0)
            {
                shurikenCount = 0;
            }
            else
            {
                shurikenCount = value;
            }
        }
    }
    #endregion

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = Color.blue;
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

    //ICE SHURIKEN ATTACK
    protected override void Attack2()
    {
        if(input.attack2 && shurikenCount < shurikenMax) //checks to make sure button has been pressed and that we have not hit max shurikens on the screen
        {
            GameObject iceShuriken;

            //makes the ice shuriken depending on the direction player is facing
            if (facingLeft) 
            {
                iceShuriken = Instantiate(IceShurikenPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                shurikenCount++;
            }
            else
            {
                iceShuriken = Instantiate(IceShurikenPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                shurikenCount++;
            }
        }
    }

    //ICE FREEZE ATTACK
    protected override void SuperAttack()
    {
        if(input.attack3 && SuperCurrent >= SuperCost)
        {
            GameObject iceBlast;

            //makes the ice blast depending on the direction player is facing
            if (facingLeft)
            {
                iceBlast = Instantiate(IceBlastPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            }
            else
            {
                iceBlast = Instantiate(IceBlastPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            }

            SuperCurrent -= SuperCost;
        }
    }
}
