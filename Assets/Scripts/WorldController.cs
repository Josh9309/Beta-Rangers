using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
    
    ///attributes
    public enum cMenu { MAINMENU, OPTIONS, PAUSE, BATTLE};
    public enum cLevel { NULL };

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
    [SerializeField] private GameObject prefabGoal;
    private GameObject goalP1;
    private GameObject goalP2;
    private GameObject goalP3;
    private GameObject goalP4;
    [SerializeField] private float keyMaxTime;

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

    public void win(Player playerWhoWon)
    {

    }

    void levelSelect()
    {

    }

    public IEnumerator Frozen(int playNum, float freezeTime, GameObject iceBlastShard)
    {
        Player enemyRanger;
        SpriteRenderer rangerRender;
        switch (playNum)
        {
            case 1:
                enemyRanger = player1;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true;
                rangerRender.color = Color.cyan;
                break;

            case 2:
                enemyRanger = player2;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true;
                rangerRender.color = Color.cyan;
                break;

            case 3:
                enemyRanger = player3;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true;
                rangerRender.color = Color.cyan;
                break;

            case 4:
                enemyRanger = player4;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true;
                rangerRender.color = Color.cyan;
                break;

            default:
                Debug.LogError("Player number passed into frozen corroutine was invalid");
                enemyRanger = null; //this should not trigger unless their is an error
                rangerRender = null;
                break;
        }

        yield return new WaitForSeconds(freezeTime);

        Debug.Log(enemyRanger.name + " is Unfrozen!");
        enemyRanger.frozen = false;
        rangerRender.color = Color.white;
        Destroy(iceBlastShard);
    }
}
