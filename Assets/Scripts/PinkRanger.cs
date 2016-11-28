using UnityEngine;
using System.Collections;
using System;

public class PinkRanger : Player {

    [SerializeField] private GameObject StatDartPrefab;
    [SerializeField] private GameObject PoisonPrefab;
    [SerializeField] private float StatDartVelocity;
    [SerializeField] private float statTimeMax;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = new Color(255, 105, 180);
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

    protected override void Attack2()
    {
        if (input.attack2 && attack2Available)
        {
            GameObject b = GameObject.Instantiate(StatDartPrefab) as GameObject;
            if (facingLeft)
            {
                b.transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
            }
            else
            {
                b.transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
            }
            b.GetComponent<statDartScript>().startUp(playerNum, facingLeft, StatDartVelocity, statTimeMax);
        }
    }

    protected override void SuperAttack()
    {
        
    }
}
