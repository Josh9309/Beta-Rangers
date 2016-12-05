using UnityEngine;
using System.Collections;

public class PoisonCloud : MonoBehaviour {

    private int playerNum;//owners player number
    private bool moving = true;
    private float moveTimeCurrent; //current time has been moving
    private float moveTimeMax; //how long black hole moves for
    private float stillTimeCurrent;//current time has been still
    private float stillTimeMax;//max time the black hole can stay still for before deleting
    private float poisonTime;//how long a ranger can be in the cloud befor getting hurt
    private int cloudDamage;
    private Rigidbody2D rBody;
    protected WorldController worldControl;

    public float PlayerNum
    {
        get { return playerNum; }
    }

    public int CloudDamage
    {
        get { return cloudDamage; }
    }

    public float PoisonTime
    {
        get { return poisonTime; }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)//poison cloud is moving
        {
            if (moveTimeCurrent >= moveTimeMax)
            {
                rBody.velocity = new Vector2(0, 0);
                moving = false;
            }
            else { moveTimeCurrent += Time.deltaTime; }
        }
        else//poison cloud is still
        {
            if (stillTimeCurrent >= stillTimeMax)
            {
                DestroyObject(gameObject);
            }
            //if (stillTimeCurrent >= stillTimeMax + .5)
            //{
            //    DestroyObject(gameObject);
            //}
            stillTimeCurrent += Time.deltaTime;
        }
    }

    public void startUp(int pNum, bool direction, int dam, float speed, float time, float stillTime, float pTime)
    {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
        cloudDamage = dam;
        moveTimeCurrent = 0;
        moveTimeMax = time;
        stillTimeCurrent = 0;
        stillTimeMax = stillTime;
        poisonTime = pTime;
        if (direction)//left
        {
            rBody.velocity = new Vector2(-speed, 0);
        }
        else//right
        {
            rBody.velocity = new Vector2(speed, 0);
        }
    }
}
