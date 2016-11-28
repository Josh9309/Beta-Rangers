using UnityEngine;
using System.Collections;

public class BlackHoleScript : MonoBehaviour {

    private bool moving = true;
    private int playerNum;//owners player number
    private float moveTimeCurrent; //current time has been moving
    private float moveTimeMax; //how long black hole moves for
    private bool pull;
    private float pullStrength;//how strong the black hole pulls
    private float pullRange;//how far around the balck hole will pull
    private float stillTimeCurrent;//current time has been still
    private float stillTimeMax;//max time the black hole can stay still for before deleting
    private Rigidbody2D rBody;
    private Animator anim;
    protected WorldController worldControl;

    public float PullRange
    {
        get { return pullRange; }
    }

    public float PlayerNum
    {
        get { return playerNum; }
    }

    // Use this for initialization
    void Start () {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (pull) {//pull people into the black hole
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in players)
            {
                if(player.GetComponent<Player>().PlayerNum != playerNum)//not the owner of the black hole
                {
                    Vector3 displacement = (transform.position - player.transform.position);
                    float dis = Mathf.Abs(displacement.magnitude);
                    if (dis <= pullRange)//within range
                    {
                        float percentDis = 1 - (dis/pullRange);
                        displacement.Normalize();
                        displacement *= percentDis * pullStrength;
                        player.GetComponent<Player>().RBody.velocity += new Vector2(displacement.x, displacement.y);
                        //Debug.Log("Pulling " + player.name + ", (" + displacement.x + ", " + displacement.y + ")");
                    }
                }
            }
        }
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
            if(stillTimeCurrent >= stillTimeMax)
            {
                anim.Play("blackHoleExit");
                pull = false;
            }
            if(stillTimeCurrent >= stillTimeMax + .5)
            {
                DestroyObject(gameObject);
            }
            stillTimeCurrent += Time.deltaTime;
        }
	}

    public void startUp(int pNum, bool direction, float strength, float pRange, float speed, float time, float stillTime)//called by black ranger and gives info needed for black hole
    {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
        pull = true;
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
