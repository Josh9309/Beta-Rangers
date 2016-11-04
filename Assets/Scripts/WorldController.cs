using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
    
    ///attributes
    public enum cMenu { MAINMENU, OPTIONS, PAUSE, BATTLE};
    public enum cLevel { NULL };

    [SerializeField] private cMenu currentMenu;
    [SerializeField] private cLevel currentLevel;
    private Player player1;
    private Player player2;
    private Player player3;
    private Player player4;
    [SerializeField] private GameObject prefabRangerRed;
    [SerializeField] private GameObject prefabRangerBlue;
    [SerializeField] private GameObject prefabRangerYellow;
    [SerializeField] private GameObject prefabRangerGreen;
    [SerializeField] private GameObject prefabRangerBlack;
    [SerializeField] private GameObject prefabRangerPink;
    [SerializeField] private GameObject prefabGoal;
    private GameObject goalP1;
    private GameObject goalP2;
    private GameObject goalP3;
    private GameObject goalP4;
    [SerializeField] private int keyMaxTime;

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

    public int KeyMaxTime
    {
        get { return keyMaxTime; }
    }

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
	
	}

    void win(Player playerWhoWon)
    {

    }

    void levelSelect()
    {

    }
}
