using UnityEngine;
using System.Collections;

public class BlackHoleScript : MonoBehaviour {


    private int playerNum;//owners player number
    private float maxRange; //the distance the black hole will move
    private float pullStrength;//how strong the black hole pulls
    private float pullRange;//how far around the balck hole will pull
    private Rigidbody2D rBody;
    protected WorldController worldControl;

    // Use this for initialization
    void Start () {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        rBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startUp(int pNum, bool direction, float strength, float pRange, float speed, float range)//called by black ranger and gives info needed for black hole
    {
        rBody = GetComponent<Rigidbody2D>();
        playerNum = pNum;
        pullStrength = strength;
        pullRange = pRange;
        maxRange = range;
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
