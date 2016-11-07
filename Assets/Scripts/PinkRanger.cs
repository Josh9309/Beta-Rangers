using UnityEngine;
using System.Collections;
using System;

public class PinkRanger : Player {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();


        //reset btn inputs
        input.ResetBtns();
    }

    protected override void Attack2()
    {
        throw new NotImplementedException();
    }

    protected override void SuperAttack()
    {
        throw new NotImplementedException();
    }
}
