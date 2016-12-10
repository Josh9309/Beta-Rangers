using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    ///attributes
    [SerializeField] private Color rangerColor;
    [SerializeField] private int playerNum;
    [SerializeField] private GameObject lights;
    private Player.RangerType playerRangerType;
    private Rigidbody2D rBody;
    [SerializeField] bool loaded;
    private WorldController worldControl;
    private Player ranger;
    string part = "";
    int lightLevel = 0;

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
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
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
                string color = "";
                switch (playerNum)
                {
                    case 1://head
                        part = "Head";
                        ranger = worldControl.Player1;
                        break;
                    case 2://torso
                        part = "Torso";
                        ranger = worldControl.Player2;
                        break;
                    case 3://right arm
                        part = "Arm";
                        ranger = worldControl.Player3;
                        break;
                    case 4://left arm
                        part = "Arm";
                        ranger = worldControl.Player4;
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
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/mech" + part + color));
                //GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "lightsC"));
                //GetComponent<SpriteRenderer>().sprite = ("Art Assets/mechParts/" + part + color);
                loaded = true;
            }
        }

        updateLights();
	}

    private void updateLights()//updates the lights on the goals piece
    {
        float current = ranger.KeyCurrentTime;
        float max = worldControl.KeyMaxTime;
        if (current / max >= .9)//90%
        {
            if (lightLevel != 9)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights90"));
                lightLevel = 9;
            }
        }
        else if (current / max >= .8)//80%
        {
            if (lightLevel != 8)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights80"));
                lightLevel = 8;
            }
        }
        else if (current / max >= .7)//70%
        {
            if (lightLevel != 7)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights70"));
                lightLevel = 7;
            }
        }
        else if (current / max >= .6)//60%
        {
            if (lightLevel != 6)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights60"));
                lightLevel = 6;
            }
        }
        else if (current / max >= .5)//50%
        {
            if (lightLevel != 5)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights50"));
                lightLevel = 5;
            }
        }
        else if (current / max >= .4)//40%
        {
            if (lightLevel != 4)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights40"));
                lightLevel = 4;
            }
        }
        else if (current / max >= .3)//30%
        {
            if (lightLevel != 3)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights30"));
                lightLevel = 3;
            }
        }
        else if (current / max >= .2)//20%
        {
            if (lightLevel != 2)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights20"));
                lightLevel = 2;
            }
        }
        else if (current / max >= .1)//10%
        {
            if (lightLevel != 1)
            {
                lights.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("mechParts/" + part + "Lights/mech" + part + "lights10"));
                lightLevel = 1;
            }
        }
    }
}