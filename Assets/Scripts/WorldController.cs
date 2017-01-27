using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
    #region Attributes
    ///attributes
    public enum cMenu { MAINMENU, OPTIONS, PAUSE, BATTLE, LOADING, WIN};
    public enum cLevel { STAGE1 };

    [SerializeField] private cMenu currentMenu;
    [SerializeField] private cLevel currentLevel;
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private Player player3;
    [SerializeField] private Player player4;
    [SerializeField] private GameObject prefabRangerRed;
    [SerializeField] private GameObject prefabRangerBlue;
    [SerializeField] private GameObject prefabRangerYellow;
    [SerializeField] private GameObject prefabRangerGreen;
    [SerializeField] private GameObject prefabRangerBlack;
    [SerializeField] private GameObject prefabRangerPink;
    [SerializeField] private Vector3 p1Location;
    [SerializeField] private Vector3 p2Location;
    [SerializeField] private Vector3 p3Location;
    [SerializeField] private Vector3 p4Location;
    private GameObject goalP1;
    private GameObject goalP2;
    private GameObject goalP3;
    private GameObject goalP4;
    private bool p1Active = false;
    private bool p2Active = false;
    private bool p3Active = false;
    private bool p4Active = false;
    private Player.RangerType p1RangerType;
    private Player.RangerType p2RangerType;
    private Player.RangerType p3RangerType;
    private Player.RangerType p4RangerType;
    private Player.RangerType winnerType;
    [SerializeField] private float keyMaxTime;
    public bool battleSetup = false;
    public bool winSetup = false;
    private GameUI gameUI;
    [SerializeField] private float respawnTime = 3.0f;
    #endregion

    #region Properties
    ///properties
    public cMenu CurrentMenu{
        get { return currentMenu; }
        set { currentMenu = value; }
    }
    public cLevel CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }
    public Player Player1
    {
        get { return player1; }
        set { player1 = value; }
    }
    public Player Player2
    {
        get { return player2; }
        set { player2 = value; }
    }
    public Player Player3
    {
        get { return player3; }
        set { player3 = value; }
    }
    public Player Player4
    {
        get { return player4; }
        set { player4 = value; }
    }

    public float KeyMaxTime
    {
        get { return keyMaxTime; }
    }

    public bool P1Active
    {
        get { return p1Active; }
    }

    public bool P2Active
    {
        get { return p2Active; }
    }

    public bool P3Active
    {
        get { return p3Active; }
    }

    public bool P4Active
    {
        get { return p4Active; }
    }

    public Player.RangerType WinnerType
    {
        get { return winnerType; }
    }
    #endregion

    #region Methods
    ///Methods

    //called when the script instance is being loaded.
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Application.loadedLevelName == "Stage 1")
        {
            if(battleSetup == false)
            {

                SetupPlayers();
                AssignPlayers();
                SetupGoals();
                gameUI = GameObject.Find("Game UI").GetComponent<GameUI>();
                gameUI.SetupUI();
                battleSetup = true;
            }
            
        }
        else
        {
            battleSetup = false;
        }
        if(Application.loadedLevelName == "Win Scene")
        {
            if (!winSetup)
            {
                setupWin();
                winSetup = true;
            }
        }
        else
        {
            winSetup = false;
        }
	}
    
    public void SetPlayersActive(bool p1, bool p2, bool p3, bool p4)
    {
        p1Active = p1;
        p2Active = p2;
        p3Active = p3;
        p4Active = p4;
    }

    public void SetRangerTypes(Player.RangerType p1, Player.RangerType p2, Player.RangerType p3, Player.RangerType p4)
    {
        p1RangerType = p1;
        p2RangerType = p2;
        p3RangerType = p3;
        p4RangerType = p4;
    }

    public void SetupPlayers()
    {
        if (p1Active)
        {
            GameObject player;

            switch (p1RangerType)
            {
                case Player.RangerType.BlackRanger:
                    player = Instantiate(prefabRangerBlack, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;

                case Player.RangerType.BlueRanger:
                    player = Instantiate(prefabRangerBlue, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;

                case Player.RangerType.GreenRanger:
                    player = Instantiate(prefabRangerGreen, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;

                case Player.RangerType.PinkRanger:
                    player = Instantiate(prefabRangerPink, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;

                case Player.RangerType.RedRanger:
                    player = Instantiate(prefabRangerRed, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;

                case Player.RangerType.YellowRanger:
                    player = Instantiate(prefabRangerYellow, p1Location, Quaternion.identity) as GameObject;
                    player1 = player.GetComponent<Player>();
                    player1.PlayerNum = 1;
                    break;
            }
            Player1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (p2Active)
        {
            GameObject player;

            switch (p2RangerType)
            {
                case Player.RangerType.BlackRanger:
                    player = Instantiate(prefabRangerBlack, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;

                case Player.RangerType.BlueRanger:
                    player = Instantiate(prefabRangerBlue, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;

                case Player.RangerType.GreenRanger:
                    player = Instantiate(prefabRangerGreen, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;

                case Player.RangerType.PinkRanger:
                    player = Instantiate(prefabRangerPink, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;

                case Player.RangerType.RedRanger:
                    player = Instantiate(prefabRangerRed, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;

                case Player.RangerType.YellowRanger:
                    player = Instantiate(prefabRangerYellow, p2Location, Quaternion.identity) as GameObject;
                    player2 = player.GetComponent<Player>();
                    player2.PlayerNum = 2;
                    break;
            }
            Player2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (p3Active)
        {
            GameObject player;

            switch (p3RangerType)
            {
                case Player.RangerType.BlackRanger:
                    player = Instantiate(prefabRangerBlack, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;

                case Player.RangerType.BlueRanger:
                    player = Instantiate(prefabRangerBlue, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;

                case Player.RangerType.GreenRanger:
                    player = Instantiate(prefabRangerGreen, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;

                case Player.RangerType.PinkRanger:
                    player = Instantiate(prefabRangerPink, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;

                case Player.RangerType.RedRanger:
                    player = Instantiate(prefabRangerRed, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;

                case Player.RangerType.YellowRanger:
                    player = Instantiate(prefabRangerYellow, p3Location, Quaternion.identity) as GameObject;
                    player3 = player.GetComponent<Player>();
                    player3.PlayerNum = 3;
                    break;
            }
            Player3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (p4Active)
        {
            GameObject player;

            switch (p4RangerType)
            {
                case Player.RangerType.BlackRanger:
                    player = Instantiate(prefabRangerBlack, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;

                case Player.RangerType.BlueRanger:
                    player = Instantiate(prefabRangerBlue, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;

                case Player.RangerType.GreenRanger:
                    player = Instantiate(prefabRangerGreen, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;

                case Player.RangerType.PinkRanger:
                    player = Instantiate(prefabRangerPink, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;

                case Player.RangerType.RedRanger:
                    player = Instantiate(prefabRangerRed, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;

                case Player.RangerType.YellowRanger:
                    player = Instantiate(prefabRangerYellow, p4Location, Quaternion.identity) as GameObject;
                    player4 = player.GetComponent<Player>();
                    player4.PlayerNum = 4;
                    break;
            }
            Player4.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

    }

    private void SetupGoals()
    {
        goalP1 = GameObject.Find("P1_Head_Goal");
        goalP2 = GameObject.Find("P2_Torso_Goal");
        goalP3 = GameObject.Find("P3_ArmR_Goal");
        goalP4 = GameObject.Find("P4_ArmL_Goal");

        if (p1Active)
        {
            goalP1.GetComponent<Goal>().PlayerNum = 1;
            goalP1.GetComponent<Goal>().RangerColor = Player1.RangerColor;
            goalP1.GetComponent<Goal>().PlayerRangerType = player1.Ranger;
        }
        else
        {
            goalP1.SetActive(false);
        }

        if (p2Active)
        {
            goalP2.GetComponent<Goal>().PlayerNum = 2;
            goalP2.GetComponent<Goal>().RangerColor = Player2.RangerColor;
            goalP2.GetComponent<Goal>().PlayerRangerType = player2.Ranger;
        }
        else
        {
            goalP2.SetActive(false);
        }

        if (p3Active)
        {
            goalP3.GetComponent<Goal>().PlayerNum = 3;
            goalP3.GetComponent<Goal>().RangerColor = Player3.RangerColor;
            goalP3.GetComponent<Goal>().PlayerRangerType = player3.Ranger;
        }
        else
        {
            goalP3.SetActive(false);
        }

        if (p4Active)
        {
            goalP4.GetComponent<Goal>().PlayerNum = 4;
            goalP4.GetComponent<Goal>().RangerColor = Player4.RangerColor;
            goalP4.GetComponent<Goal>().PlayerRangerType = player4.Ranger;
        }
        else
        {
            goalP4.SetActive(false);
        }
    }

    public void AssignPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for(int i =0; i < players.Length; i++)
        {
            Player ranger = players[i].GetComponent<Player>();

            if (ranger != null)
            {
                switch (ranger.PlayerNum)
                {
                    case 1:
                        player1 = ranger;
                        break;

                    case 2:
                        Player2 = ranger;
                        break;

                    case 3:
                        player3 = ranger;
                        break;

                    case 4:
                        player4 = ranger;
                        break;
                    default:
                        Debug.LogError("Assign Player Error");
                        break;
                }
            }
        }
    }

    public void win(Player.RangerType playerWhoWon)
    {
        Application.LoadLevel("Win Scene");
        currentMenu = cMenu.WIN;
        winnerType = playerWhoWon;
    }

    private void setupWin()
    {
        GameObject g;
        switch (winnerType)
        {
            case Player.RangerType.BlackRanger:
                g = Instantiate(prefabRangerBlack, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<BlackRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            case Player.RangerType.BlueRanger:
                g = Instantiate(prefabRangerBlue, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<BlueRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            case Player.RangerType.GreenRanger:
                g = Instantiate(prefabRangerGreen, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<GreenRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            case Player.RangerType.PinkRanger:
                g = Instantiate(prefabRangerPink, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<PinkRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            case Player.RangerType.RedRanger:
                g = Instantiate(prefabRangerRed, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<RedRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            case Player.RangerType.YellowRanger:
                g = Instantiate(prefabRangerYellow, new Vector3(0, 0), Quaternion.identity) as GameObject;
                g.GetComponent<YellowRanger>().enabled = false;
                g.GetComponent<Collider2D>().enabled = false;
                g.GetComponent<Rigidbody2D>().Sleep();
                break;
            default:
                break;
        }
    }

    void levelSelect()
    {

    }

    public IEnumerator Frozen(int playNum, float freezeTime, int frozenDamage, GameObject iceBlastShard)
    {
        Player enemyRanger;
        SpriteRenderer[] rangerRenders;
        Animator rangerAnimator;

        //determines which player is being frozen
        switch (playNum)
        {
            case 1:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player1;
                rangerRenders = enemyRanger.gameObject.GetComponentsInChildren<SpriteRenderer>();
                rangerAnimator = enemyRanger.RangerAnimator;
                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                for (int i = 0; i < rangerRenders.Length; i++)
                {
                    rangerRenders[i].color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                }
                break;

            case 2:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player2;
                rangerRenders = enemyRanger.gameObject.GetComponentsInChildren<SpriteRenderer>();
                rangerAnimator = enemyRanger.RangerAnimator;
                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                for (int i = 0; i < rangerRenders.Length; i++)
                {
                    rangerRenders[i].color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                }
                break;

            case 3:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player3; 
                rangerRenders = enemyRanger.gameObject.GetComponentsInChildren<SpriteRenderer>();
                rangerAnimator = enemyRanger.RangerAnimator;
                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                for (int i = 0; i < rangerRenders.Length; i++)
                {
                    rangerRenders[i].color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                }
                break;

            case 4:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player4;
                rangerRenders = enemyRanger.gameObject.GetComponentsInChildren<SpriteRenderer>();
                rangerAnimator = enemyRanger.RangerAnimator;
                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                for (int i = 0; i < rangerRenders.Length; i++)
                {
                    rangerRenders[i].color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                }
                break;

            default:
                Debug.LogError("Player number passed into frozen corroutine was invalid");
                enemyRanger = null; //this should not trigger unless there is an error
                rangerRenders = null;
                rangerAnimator = null;
                break;
        }
        if (enemyRanger != null)
        {
            rangerAnimator.Play("Frozen");
        }
        //waits for a third of the freeze time
        yield return new WaitForSeconds(freezeTime/ 3);
        if(enemyRanger != null)
        {
            Debug.Log(enemyRanger.name + " takes another 5 damage");
            enemyRanger.ModHealth(-5); //applies frozen damage
        }
        
        //waits for a third of the freeze time
        yield return new WaitForSeconds(freezeTime / 3);
        if (enemyRanger != null)
        {
            Debug.Log(enemyRanger.name + " takes another 5 damage");
            enemyRanger.ModHealth(-5);//applies frozen damage
        }

        //waits for a third of the freeze time
        yield return new WaitForSeconds(freezeTime / 3);
        if (enemyRanger != null)
        {
            Debug.Log(enemyRanger.name + " takes another 5 damage");
            enemyRanger.ModHealth(-5); //applies frozen damage


            Debug.Log(enemyRanger.name + " is Unfrozen!");
            //Unfreezes the ranger and removes tint, it also destroys ice blast shard gameobject
            enemyRanger.frozen = false;
            for (int i = 0; i < rangerRenders.Length; i++)
            {
                rangerRenders[i].color = Color.white;
            }
        }
        if (enemyRanger != null)
        {
            rangerAnimator.Play("Idle");
        }
        Destroy(iceBlastShard);
    }

    public IEnumerator Respawn(int playerNum, Player.RangerType rangeType)
    {
        //Wait for player respawn time
        yield return new WaitForSeconds(respawnTime);

        //Respawn the player
        GameObject player;
        //check which player to respawn
        switch (playerNum)
        {
            case 1: //Respawn player 1
                switch (p1RangerType)
                {
                    case Player.RangerType.BlackRanger:
                        player = Instantiate(prefabRangerBlack, p1Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.BlueRanger:
                        player = Instantiate(prefabRangerBlue, p1Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.GreenRanger:
                        player = Instantiate(prefabRangerGreen, p1Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.PinkRanger:
                        player = Instantiate(prefabRangerPink, p1Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.RedRanger:
                        player = Instantiate(prefabRangerRed, p1Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.YellowRanger:
                        player = Instantiate(prefabRangerYellow, p1Location, Quaternion.identity) as GameObject;
                        break;

                    default:
                        player = new GameObject();
                        Debug.LogError("Respawn Player 1 Error");
                        break;
                }
                player1 = player.GetComponent<Player>();
                Player1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player1.PlayerNum = 1;
                p1Active = true;
                break;

            case 2: //Respawn player 2
                switch (p2RangerType)
                {
                    case Player.RangerType.BlackRanger:
                        player = Instantiate(prefabRangerBlack, p2Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.BlueRanger:
                        player = Instantiate(prefabRangerBlue, p2Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.GreenRanger:
                        player = Instantiate(prefabRangerGreen, p2Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.PinkRanger:
                        player = Instantiate(prefabRangerPink, p2Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.RedRanger:
                        player = Instantiate(prefabRangerRed, p2Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.YellowRanger:
                        player = Instantiate(prefabRangerYellow, p2Location, Quaternion.identity) as GameObject;
                        break;

                    default:
                        player = new GameObject();
                        Debug.LogError("Respawn Player 2 Error");
                        break;
                }
                player2 = player.GetComponent<Player>();
                Player2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player2.PlayerNum = 2;
                p2Active = true;
                break;

            case 3: //Respawn player 3
                switch (p3RangerType)
                {
                    case Player.RangerType.BlackRanger:
                        player = Instantiate(prefabRangerBlack, p3Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.BlueRanger:
                        player = Instantiate(prefabRangerBlue, p3Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.GreenRanger:
                        player = Instantiate(prefabRangerGreen, p3Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.PinkRanger:
                        player = Instantiate(prefabRangerPink, p3Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.RedRanger:
                        player = Instantiate(prefabRangerRed, p3Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.YellowRanger:
                        player = Instantiate(prefabRangerYellow, p3Location, Quaternion.identity) as GameObject;
                        break;

                    default:
                        player = new GameObject();
                        Debug.LogError("Respawn Player 3 Error");
                        break;
                }
                player3 = player.GetComponent<Player>();
                Player3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player3.PlayerNum = 3;
                p3Active = true;
                break;

            case 4: //Respawn player 4
                switch (p4RangerType)
                {
                    case Player.RangerType.BlackRanger:
                        player = Instantiate(prefabRangerBlack, p4Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.BlueRanger:
                        player = Instantiate(prefabRangerBlue, p4Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.GreenRanger:
                        player = Instantiate(prefabRangerGreen, p4Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.PinkRanger:
                        player = Instantiate(prefabRangerPink, p4Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.RedRanger:
                        player = Instantiate(prefabRangerRed, p4Location, Quaternion.identity) as GameObject;
                        break;

                    case Player.RangerType.YellowRanger:
                        player = Instantiate(prefabRangerYellow, p4Location, Quaternion.identity) as GameObject;
                        break;

                    default:
                        player = new GameObject();
                        Debug.LogError("Respawn Player 4 Error");
                        break;
                }
                player4 = player.GetComponent<Player>();
                Player4.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                player4.PlayerNum = 4;
                p4Active = true;
                break;
        }
    }
    #endregion
}
