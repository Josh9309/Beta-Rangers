using UnityEngine;
using System.Collections;

public class BlackHoleScript : MonoBehaviour {

    private bool moving = true;
    private int playerNum;//owners player number
    private float moveTimeCurrent; //current time has been moving
    private float moveTimeMax; //how long black hole moves for
    private float pullStrength;//how strong the black hole pulls
    private float pullRange;//how far around the balck hole will pull
    private float stillTimeCurrent;//current time has been still
    private float stillTimeMax;//max time the black hole can stay still for before deleting
    private Rigidbody2D rBody;
    protected WorldController worldControl;

    // Use this for initialization
    void Start () {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)//black hole is moving
        {
            if (moveTimeCurrent >= moveTimeMax)
            {
                rBody.velocity = new Vector2(0, 0);
                moving = false;
            }
            else { moveTimeCurrent += Time.deltaTime; }
        }
        else//black hole is still
        {
            stillTimeCurrent += Time.deltaTime;
        }
	}

    public void startUp(int pNum, bool direction, float strength, float pRange, float speed, float time, float stillTime)//called by black ranger and gives info needed for black hole
    {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
        pullStrength = strength;
        pullRange = pRange;
        moveTimeMax = time;
        stillTimeMax = stillTime;
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
