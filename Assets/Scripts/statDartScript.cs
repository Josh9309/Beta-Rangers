using UnityEngine;
using System.Collections;

public class statDartScript : MonoBehaviour {

    private int playerNum;//owners player number
    private float statTime;
    private int effect;
    private Rigidbody2D rBody;
    protected WorldController worldControl;

    public float PlayerNum
    {
        get { return playerNum; }
    }
    public float StatusTimeMax
    {
        get { return statTime; }
    }

    public int Effect
    {
        get { return effect; }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void startUp(int pNum, bool direction, float speed, float timeMax)//called by pink ranger and gives info needed for dart
    {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
        if (direction)//left
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            rBody.velocity = new Vector2(-speed, 0);
        }
        else//right
        {
            rBody.velocity = new Vector2(speed, 0);
        }
        effect = (int)(Random.Range(0, 3) + 1);
    }
}
