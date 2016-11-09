using UnityEngine;
using System.Collections;
using System;

public class BlueRanger : Player {

    #region Attributes
    [SerializeField] private GameObject IceShurikenPrefab;
    private int shurikenMax; //max amount of shurikens allowed to be thrown at once on screen
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


        //reset btn inputs
        input.ResetBtns();
    }

    //ICE SHURIKEN ATTACK
    protected override void Attack2()
    {
        if(input.attack2 && shurikenCount < shurikenMax) //checks to make sure button has been pressed and that we have not hit max shurikens on the screen
        {
            IceShuriken shurikenScript;
            GameObject iceShuriken;

            if (facingLeft)
            {
                iceShuriken = Instantiate(IceShurikenPrefab, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                shurikenScript = iceShuriken.GetComponent<IceShuriken>();

            }
            else
            {
                iceShuriken = Instantiate(IceShurikenPrefab, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                shurikenScript = iceShuriken.GetComponent<IceShuriken>();
            }
        }
    }

    //ICE FREEZE ATTACK
    protected override void SuperAttack()
    {
        throw new NotImplementedException();
    }
}
