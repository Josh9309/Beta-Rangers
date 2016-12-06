using UnityEngine;
using System.Collections;
using System;

public class BlackRanger : Player {

    [SerializeField] private GameObject WarpBallObj;
    [SerializeField] private GameObject BlackHolePrefab;
    [SerializeField] private float BlackHoleStrength; //how strong the pull of the black hole is
    [SerializeField] private float BlackHolePullRange; //how far the black hole will pull other players
    [SerializeField] private float BlackHoleSpeed; //How fast the black hole moves to point
    [SerializeField] private float BlackHoleMoveTime; //the amount of time the black hole moves for
    [SerializeField] private float BlackHoleStillTime; //the amount of time the black hole stays still for
    [SerializeField] private float warpTimeMax; //amount of time the warp ball has to move
    [SerializeField] private float warpSpeed; //how fast the warp ball can move
    private float warpTimeCurrent; //amount of time the warp ball has been active

    public float verInput = 0;
    public string VERTICAL_AXIS = "Warp_Vertical";

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        playerColor = Color.black;
        //WarpBallObj.GetComponent<WarpBallScript>().Damage = Attack2Power;
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        verInput = Input.GetAxis(VERTICAL_AXIS);
        if (WarpBallObj.activeInHierarchy == true)
        {
            Move();
            
            if (warpTimeCurrent >= warpTimeMax || !Input.GetButton(input.ATTACK2_AXIS))
            {
                StartCoroutine(Attack2Cooldown());
                transform.transform.position = WarpBallObj.transform.position;
                WarpBallObj.SetActive(false);
                canMove = true;
                warpTimeCurrent = 0;
                WarpBallObj.transform.localPosition = new Vector3(0, 0);
            }
            else
            {
                warpTimeCurrent += Time.deltaTime;
            }
        }
        Attack2();
        SuperAttack();

        //reset btn inputs
        input.ResetBtns();
        verInput = 0;
    }

    protected override void Move()
    {
        if (WarpBallObj.activeInHierarchy)
        {
            WarpBallObj.GetComponent<Rigidbody2D>().velocity = new Vector2(input.fwdInput * warpSpeed, -verInput * warpSpeed); // moves player based on input
        }
        else
        {
            base.Move();
        }

    }

    protected override void Attack2()//Warp
    {
        if (input.attack2 && attack2Available)
        {
            Debug.Log("Warp");
            WarpBallObj.SetActive(true);
            canMove = false;
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
