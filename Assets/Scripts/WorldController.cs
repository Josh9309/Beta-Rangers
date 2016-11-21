using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
    
    ///attributes
    public enum cMenu { MAINMENU, OPTIONS, PAUSE, BATTLE, LOADING};
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
    [SerializeField] private GameObject prefabGoal;
    private GameObject goalP1;
    private GameObject goalP2;
    private GameObject goalP3;
    private GameObject goalP4;
    [SerializeField] private float keyMaxTime;
    private bool battleSetup = false;

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
        if(currentMenu == cMenu.BATTLE)
        {
            if(battleSetup = false)
            {
                AssignPlayers();
                battleSetup = true;
            }
            
        }
	}

    public void AssignPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for(int i =0; i < players.Length; i++)
        {
            Player ranger = players[i].GetComponent<Player>();

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
            }
        }
    }

    public void win(Player playerWhoWon)
    {

    }

    void levelSelect()
    {

    }

    public IEnumerator Frozen(int playNum, float freezeTime, int frozenDamage, GameObject iceBlastShard)
    {
        Player enemyRanger;
        SpriteRenderer rangerRender;

        //determines which player is being frozen
        switch (playNum)
        {
            case 1:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player1;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                rangerRender.color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                break;

            case 2:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player2;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                rangerRender.color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                break;

            case 3:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player3; 
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>(); 

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                rangerRender.color = Color.cyan; //adds a cyan tint to ranger to show that the ranger is frozen
                break;

            case 4:
                //gets the ranger and the sprite renderer for the ranger
                enemyRanger = player4;
                rangerRender = enemyRanger.gameObject.GetComponent<SpriteRenderer>();

                Debug.Log(enemyRanger.name + " is Frozen!");
                enemyRanger.frozen = true; //sets frozen status effect to true
                rangerRender.color = Color.cyan;//adds a cyan tint to ranger to show that the ranger is frozen
                break;

            default:
                Debug.LogError("Player number passed into frozen corroutine was invalid");
                enemyRanger = null; //this should not trigger unless there is an error
                rangerRender = null; 
                break;
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
            rangerRender.color = Color.white;
        }
        Destroy(iceBlastShard);
    }
}
