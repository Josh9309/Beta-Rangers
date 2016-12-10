using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    ///attributes
    [SerializeField] private Color rangerColor;
    [SerializeField] private int playerNum;
    private Player.RangerType playerRangerType;
    private Rigidbody2D rBody;
    [SerializeField] bool loaded;

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

    public Player.RangerType PlayerRangerType
    {
        get { return playerRangerType; }
        set { playerRangerType = value; }
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
                        part = "Head";
                        break;
                    case 2://torso
                        part = "Torso";
                        break;
                    case 3://right arm
                        part = "Arm";
                        break;
                    case 4://left arm
                        part = "Arm";
                        break;
                    default:
                        Debug.LogError("No player number for goal " + name);
                        break;
                }

                switch (playerRangerType)
                {
                    case Player.RangerType.BlackRanger:
                        color = "(black)";
                        break;
                    case Player.RangerType.BlueRanger:
                        color = "(blue)";
                        break;
                    case Player.RangerType.GreenRanger:
                        color = "(green)";
                        break;
                    case Player.RangerType.PinkRanger:
                        color = "(pink)";
                        break;
                    case Player.RangerType.RedRanger:
                        color = "(red)";
                        break;
                    case Player.RangerType.YellowRanger:
                        color = "(yellow)";
                        break;
                    default:
                        Debug.LogError("No color for goal" + name);
                        break;
                }
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                if(playerNum == 4)
                {
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                //Sprite s2 = Sprite.Create((part + color + ".png"), new Rect(), new Vector2(0, 0));
                //Sprite s = Resources.Load((part + color + ".png"), typeof(Sprite)) as Sprite;
                //Sprite s = Resources.Load<Sprite>((part + color + ".png"));
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/mech" + part + color));
                //GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "lightsC"));
                //GetComponent<SpriteRenderer>().sprite = ("Art Assets/mechParts/" + part + color);
                Debug.Log(name + " sprite updated");
                loaded = true;
            }
        }
	}    
}