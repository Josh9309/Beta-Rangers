using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    ///attributes
    [SerializeField] private Color rangerColor;
    [SerializeField] private int playerNum;
    private Rigidbody2D rBody;
    bool loaded;

    ///Properties
    public Color RangerColor
    {
        get { return rangerColor; }
        set { rangerColor = value; }
    }

    public int PlayerNum
    {
        get { return playerNum; }
        set { playerNum = value; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //if(rangerColor != GetComponent<SpriteRenderer>().color)
     //   {
     //       GetComponent<SpriteRenderer>().color = new Color(rangerColor.r, rangerColor.g, rangerColor.b, 1f);
     //   }

        if(playerNum != 0 && rangerColor != Color.white)
        {
            if (!loaded)
            {
                string part = "";
                string color = "";

                switch (playerNum)
                {
                    case 1://head
                        part = "mechHead";
                        break;
                    case 2://torso
                        part = "torso";
                        break;
                    case 3://right arm
                        part = "arm";
                        break;
                    case 4://left arm
                        part = "arm";
                        gameObject.transform.localScale = -gameObject.transform.localScale;
                        break;
                    default:
                        Debug.LogError("No player number for goal " + name);
                        break;
                }


            }
        }
	}    
}