using UnityEngine;
using System.Collections;

public class PoisonCloud : MonoBehaviour {

    private int playerNum;//owners player number
    private bool moving = true;
    private float moveTimeCurrent; //current time has been moving
    private float moveTimeMax; //how long black hole moves for
    private float stillTimeCurrent;//current time has been still
    private float stillTimeMax;//max time the black hole can stay still for before deleting
    private Rigidbody2D rBody;
    protected WorldController worldControl;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startUp(int pNum, bool direction, float speed, float time, float stillTime)
    {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
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
