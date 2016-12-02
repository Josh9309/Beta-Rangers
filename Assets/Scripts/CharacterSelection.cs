using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {
    #region Attributes
    //input controller
    Player.InputSettings p1Input = new Player.InputSettings();
    Player.InputSettings p2Input = new Player.InputSettings();
    Player.InputSettings p3Input = new Player.InputSettings();
    Player.InputSettings p4Input = new Player.InputSettings();

    //keeps track of which players have joined the game
    private bool p1Active = false;
    private bool p2Active = false;
    private bool p3Active = false;
    private bool p4Active = false;

    //keeps track of which players have confirmed their rangers
    private bool p1Confirmed = false;
    private bool p2Confirmed = false;
    private bool p3Confirmed = false;
    private bool p4Confirmed = false;

    //holds gameobject group with all the player's character selection stuff as childs under it.
    [SerializeField] private GameObject p1Group;
    [SerializeField] private GameObject p2Group;
    [SerializeField] private GameObject p3Group;
    [SerializeField] private GameObject p4Group;

    //Ranger array that holds the possible ranger options for players
    [SerializeField] private RangerChoice[] p1RangerArray = new RangerChoice[6];
    [SerializeField] private RangerChoice[] p2RangerArray = new RangerChoice[6];
    [SerializeField] private RangerChoice[] p3RangerArray = new RangerChoice[6];
    [SerializeField] private RangerChoice[] p4RangerArray = new RangerChoice[6];

    //holds player current ranger choice position
    private int p1Current = 0;
    private int p2Current = 0;
    private int p3Current = 0;
    private int p4Current = 0;

    //holds the Spriterenders for each player's Ranger
    private SpriteRenderer p1Ranger;
    private SpriteRenderer p2Ranger;
    private SpriteRenderer p3Ranger;
    private SpriteRenderer p4Ranger;

    //General Character Selection Attributes
    private int playersConfirmed = 0; //keeps track of # of players that have confirmed
    [SerializeField] private Sprite inactiveRanger;
    private bool canStart = false;
    [SerializeField] private GameObject start;
    private WorldController worldControl;
    #endregion

    #region Properties
    public int P1Current
    {
        get { return p1Current; }
    }

    public int P2Current
    {
        get { return p2Current; }
    }

    public int P3Current
    {
        get { return p3Current; }
    }

    public int P4Current
    {
        get { return p4Current; }
    }
    #endregion


    // Use this for initialization
    void Start () {
        //configures for player inputs
        p1Input.ConfigureInput(1);
        p2Input.ConfigureInput(2);
        p3Input.ConfigureInput(3);
        p4Input.ConfigureInput(4);

        //finds each players ranger renders
        p1Ranger = GameObject.Find("P1_Betaranger").GetComponent<SpriteRenderer>();
        p2Ranger = GameObject.Find("P2_Betaranger").GetComponent<SpriteRenderer>();
        p3Ranger = GameObject.Find("P3_Betaranger").GetComponent<SpriteRenderer>();
        p4Ranger = GameObject.Find("P4_Betaranger").GetComponent<SpriteRenderer>();

        //gets world Controller
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
    }
	
	// Update is called once per frame
	void Update () {
        //check to see if players are allowed to start game
        CheckCanStart();

        if (p1Active) //if the player is active
        {
            if (!p1Confirmed) //and the player has not confirmed a ranger
            {
                CheckCharacterSelector(1); //allow the player to move selector
                ConfirmCharacter(1); //allow player to confirm character
                PlayerQuit(1); //allow player to quit game
            }
            else //if player is active and has confirmed
            {
                UnconfirmCharacter(1); //allow player to unconfirm character
            }
        }
        else // player is not in game
        {
            //check to see if p1 is joining
            CheckPlayerJoined(1);
        }

        if (p2Active)
        {
            if (!p2Confirmed) //and the player has not confirmed a ranger
            {
                CheckCharacterSelector(2); //allow the player to move selector
                ConfirmCharacter(2); //allow player to confirm character
                PlayerQuit(2); //allow player to quit game
            }
            else //if player is active and has confirmed
            {
                UnconfirmCharacter(2); //allow player to unconfirm character
            }
        }
        else
        {
            CheckPlayerJoined(2);
        }

        if (p3Active)
        {
            if (!p3Confirmed) //and the player has not confirmed a ranger
            {
                CheckCharacterSelector(3); //allow the player to move selector
                ConfirmCharacter(3); //allow player to confirm character
                PlayerQuit(3); //allow player to quit game
            }
            else //if player is active and has confirmed
            {
                UnconfirmCharacter(3); //allow player to unconfirm character
            }
        }
        else
        {
            //check to see if p3 is joining
            CheckPlayerJoined(3);
        }

        if (p4Active)
        {
            if (!p4Confirmed) //and the player has not confirmed a ranger
            {
                CheckCharacterSelector(4); //allow the player to move selector
                ConfirmCharacter(4); //allow player to confirm character
                PlayerQuit(4); //allow player to quit game
            }
            else //if player is active and has confirmed
            {
                UnconfirmCharacter(4); //allow player to unconfirm character
            }
        }
        else
        {
            //check to see if p4 is joining
            CheckPlayerJoined(4);
        }
    }

    #region Methods
    /// <summary>
    /// This Method checks for input that will cause a certain player to join the game
    /// </summary>
    /// <param name="playerNum"></param>
    private void CheckPlayerJoined(int playerNum) 
    {
        switch (playerNum)
        {
            case 1:
                if(Input.GetButtonDown(p1Input.SUBMIT_AXIS)) //gets input for p1 from the A Button on Xbox Controller
                {
                    p1Active = true; //joins p1 to the game

                    //removes p1 Join game banner
                    p1Group.transform.FindChild("Join Game").gameObject.SetActive(false);

                    //sets the current ranger choice as selected.
                    p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                }
                break;

            case 2:
                if (Input.GetButtonDown(p2Input.SUBMIT_AXIS)) //gets input for p2 from the A Button on Xbox Controller
                {
                    p2Active = true; //joins p2 to the game

                    //removes p2 Join game banner
                    p2Group.transform.FindChild("Join Game").gameObject.SetActive(false);

                    //sets the current ranger choice as selected.
                    p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                }
                break;

            case 3:
                if (Input.GetButtonDown(p3Input.SUBMIT_AXIS)) //gets input for p3 from the A Button on Xbox Controller
                {
                    p3Active = true; //joins p3 to the game

                    //removes p3 Join game banner
                    p3Group.transform.FindChild("Join Game").gameObject.SetActive(false);

                    //sets the current ranger choice as selected.
                    p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                }
                break;

            case 4:
                if (Input.GetButtonDown(p4Input.SUBMIT_AXIS)) //gets input for p4 from the A Button on Xbox Controller
                {
                    p4Active = true; //joins p4 to the game

                    //removes p4 Join game banner
                    p4Group.transform.FindChild("Join Game").gameObject.SetActive(false);

                    //sets the current ranger choice as selected.
                    p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                }
                break;
        }
    }

    /// <summary>
    /// This method gets the input for the character selector and moves the selector appropriately.
    /// </summary>
    /// <param name="playerNum"></param>
    private void CheckCharacterSelector(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                //get input for p1 RB and LB
                p1Input.dodgeInput = Input.GetAxis(p1Input.DODGE_AXIS);
                p1Input.dodge = Input.GetButtonDown(p1Input.DODGE_AXIS);

                if (p1Input.dodgeInput > 0 && p1Input.dodge) //if RB was pressed
                {
                    p1Current++; //move selector to the right

                    //does not let the selector go past the end of the ranger choices
                    if(p1Current > 5) 
                    {
                        p1Current = 5;
                    }

                    p1RangerArray[p1Current].Selected(p1Ranger, p1Group); // set the current ranger choice as selected
                    p1RangerArray[p1Current-1].Unselected(p1Group); //set the previous ranger choice as unselected
                }
                else if(p1Input.dodgeInput < 0 && p1Input.dodge) //if LB was pressed
                {
                    p1Current--; //move selector to the left

                    //does not let the selector go past the beginning of the ranger choices
                    if(p1Current < 0)
                    {
                        p1Current = 0;
                    }

                    p1RangerArray[p1Current].Selected(p1Ranger, p1Group); //set the current ranger choice as selected
                    p1RangerArray[p1Current + 1].Unselected(p1Group); //set the previous ranger choice as unselected
                }
                break;

            case 2:
                //get input for p2 RB and LB
                p2Input.dodgeInput = Input.GetAxis(p2Input.DODGE_AXIS);
                p2Input.dodge = Input.GetButtonDown(p2Input.DODGE_AXIS);

                if (p2Input.dodgeInput > 0 && p2Input.dodge) //if RB was pressed
                {
                    p2Current++; //move selector to the right

                    //does not let the selector go past the end of the ranger choices
                    if (p2Current > 5)
                    {
                        p2Current = 5;
                    }

                    p2RangerArray[p2Current].Selected(p2Ranger, p2Group); // set the current ranger choice as selected
                    p2RangerArray[p2Current - 1].Unselected(p2Group); //set the previous ranger choice as unselected
                }
                else if (p2Input.dodgeInput < 0 && p2Input.dodge) //if LB was pressed
                {
                    p2Current--; //move selector to the left

                    //does not let the selector go past the beginning of the ranger choices
                    if (p2Current < 0)
                    {
                        p2Current = 0;
                    }

                    p2RangerArray[p2Current].Selected(p2Ranger, p2Group); //set the current ranger choice as selected
                    p2RangerArray[p2Current + 1].Unselected(p2Group); //set the previous ranger choice as unselected
                }
                break;

            case 3:
                //get input for p3 RB and LB
                p3Input.dodgeInput = Input.GetAxis(p3Input.DODGE_AXIS);
                p3Input.dodge = Input.GetButtonDown(p3Input.DODGE_AXIS);

                if (p3Input.dodgeInput > 0 && p3Input.dodge) //if RB was pressed
                {
                    p3Current++; //move selector to the right

                    //does not let the selector go past the end of the ranger choices
                    if (p3Current > 5)
                    {
                        p3Current = 5;
                    }

                    p3RangerArray[p3Current].Selected(p3Ranger, p3Group); // set the current ranger choice as selected
                    p3RangerArray[p3Current - 1].Unselected(p3Group); //set the previous ranger choice as unselected
                }
                else if (p3Input.dodgeInput < 0 && p3Input.dodge) //if LB was pressed
                {
                    p3Current--; //move selector to the left

                    //does not let the selector go past the beginning of the ranger choices
                    if (p3Current < 0)
                    {
                        p3Current = 0;
                    }

                    p3RangerArray[p3Current].Selected(p3Ranger, p3Group); //set the current ranger choice as selected
                    p3RangerArray[p3Current + 1].Unselected(p3Group); //set the previous ranger choice as unselected
                }
                break;

            case 4:
                //get input for p4 RB and LB
                p4Input.dodgeInput = Input.GetAxis(p4Input.DODGE_AXIS);
                p4Input.dodge = Input.GetButtonDown(p4Input.DODGE_AXIS);

                if (p4Input.dodgeInput > 0 && p4Input.dodge) //if RB was pressed
                {
                    p4Current++; //move selector to the right

                    //does not let the selector go past the end of the ranger choices
                    if (p4Current > 5)
                    {
                        p4Current = 5;
                    }

                    p4RangerArray[p4Current].Selected(p4Ranger, p4Group); // set the current ranger choice as selected
                    p4RangerArray[p4Current - 1].Unselected(p4Group); //set the previous ranger choice as unselected
                }
                else if (p4Input.dodgeInput < 0 && p4Input.dodge) //if LB was pressed
                {
                    p1Current--; //move selector to the left

                    //does not let the selector go past the beginning of the ranger choices
                    if (p4Current < 0)
                    {
                        p4Current = 0;
                    }

                    p4RangerArray[p4Current].Selected(p4Ranger, p4Group); //set the current ranger choice as selected
                    p4RangerArray[p4Current + 1].Unselected(p4Group); //set the previous ranger choice as unselected
                }
                break;
        }
    }

    /// <summary>
    /// This method confirms a player choice of character and makes that character unavailable to other players 
    /// </summary>
    /// <param name="playerNum"></param>
    private void ConfirmCharacter(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                if (Input.GetButtonDown(p1Input.SUBMIT_AXIS)) //check to see if the confirm button was pressed
                {
                    //check that this ranger is available
                    if (p1RangerArray[p1Current].Available)
                    {
                        //set this ranger option as unavailable to other players
                        p2RangerArray[p1Current].SetUnavailable();
                        p3RangerArray[p1Current].SetUnavailable();
                        p4RangerArray[p1Current].SetUnavailable();

                        //update current players options
                        if (p2Active)
                        {
                            p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                        }
                        if (p3Active)
                        {
                            p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                        }
                        if (p4Active)
                        {
                            p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                        }

                        //display player as ready
                        p1Group.transform.FindChild("Ready").gameObject.SetActive(true);

                        //increase # of players confirmed by 1
                        playersConfirmed += 1;

                        //locks it so that player has confirmed a choice
                        p1Confirmed = true;
                    }
                }
                break;

            case 2:
                if (Input.GetButtonDown(p2Input.SUBMIT_AXIS)) //check to see if the confirm button was pressed
                {
                    //check that this ranger is available
                    if (p2RangerArray[p2Current].Available)
                    {
                        //set this ranger option as unavailable to other players
                        p1RangerArray[p2Current].SetUnavailable();
                        p3RangerArray[p2Current].SetUnavailable();
                        p4RangerArray[p2Current].SetUnavailable();

                        //update current players options
                        if (p1Active)
                        {
                            p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                        }
                        if (p3Active)
                        {
                            p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                        }
                        if (p4Active)
                        {
                            p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                        }

                        //display player as ready
                        p2Group.transform.FindChild("Ready").gameObject.SetActive(true);

                        //increase # of players confirmed by 1
                        playersConfirmed += 1;

                        //locks it so that player has confirmed a choice
                        p2Confirmed = true;
                    }
                }
                break;

            case 3:
                if (Input.GetButtonDown(p3Input.SUBMIT_AXIS)) //check to see if the confirm button was pressed
                {
                    //check that this ranger is available
                    if (p3RangerArray[p3Current].Available)
                    {
                        //set this ranger option as unavailable to other players
                        p2RangerArray[p3Current].SetUnavailable();
                        p1RangerArray[p3Current].SetUnavailable();
                        p4RangerArray[p3Current].SetUnavailable();

                        //update current players options
                        if (p2Active)
                        {
                            p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                        }
                        if (p1Active)
                        {
                            p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                        }
                        if (p4Active)
                        {
                            p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                        }

                        //display player as ready
                        p3Group.transform.FindChild("Ready").gameObject.SetActive(true);

                        //increase # of players confirmed by 1
                        playersConfirmed += 1;

                        //locks it so that player has confirmed a choice
                        p3Confirmed = true;
                    }
                }
                break;

            case 4:
                if (Input.GetButtonDown(p4Input.SUBMIT_AXIS)) //check to see if the confirm button was pressed
                {
                    //check that this ranger is available
                    if (p4RangerArray[p4Current].Available)
                    {
                        //set this ranger option as unavailable to other players
                        p2RangerArray[p4Current].SetUnavailable();
                        p3RangerArray[p4Current].SetUnavailable();
                        p1RangerArray[p4Current].SetUnavailable();

                        //update current players options
                        if (p2Active)
                        {
                            p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                        }
                        if (p3Active)
                        {
                            p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                        }
                        if (p1Active)
                        {
                            p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                        }

                        //display player as ready
                        p4Group.transform.FindChild("Ready").gameObject.SetActive(true);

                        //increase # of players confirmed by 1
                        playersConfirmed += 1;

                        //locks it so that player has confirmed a choice
                        p4Confirmed = true;
                    }
                }
                break;
        }
    }

    /// <summary>
    /// This method allows a player unconfirm their character if they choose to pick a different character instead
    /// </summary>
    /// <param name="playerNum"></param>
    private void UnconfirmCharacter(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                if (Input.GetButtonDown(p1Input.CANCEL_AXIS))
                {
                    //set this ranger option to available
                    p2RangerArray[p1Current].SetAvailable();
                    p3RangerArray[p1Current].SetAvailable();
                    p4RangerArray[p1Current].SetAvailable();

                    //update current players options
                    if (p2Active)
                    {
                        p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                    }
                    if (p3Active)
                    {
                        p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                    }
                    if (p4Active)
                    {
                        p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                    }

                    //remove player ready banner
                    p1Group.transform.FindChild("Ready").gameObject.SetActive(false);

                    //decrease # of players confirmed
                    playersConfirmed--;

                    //set this player as unconfirmed
                    p1Confirmed = false;
                }
                break;

            case 2:
                if (Input.GetButtonDown(p2Input.CANCEL_AXIS))
                {
                    //set this ranger option to available
                    p1RangerArray[p2Current].SetAvailable();
                    p3RangerArray[p2Current].SetAvailable();
                    p4RangerArray[p2Current].SetAvailable();

                    //update current players options
                    if (p1Active)
                    {
                        p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                    }
                    if (p3Active)
                    {
                        p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                    }
                    if (p4Active)
                    {
                        p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                    }

                    //remove player ready banner
                    p2Group.transform.FindChild("Ready").gameObject.SetActive(false);

                    //decrease # of players confirmed
                    playersConfirmed--;

                    //set this player as unconfirmed
                    p2Confirmed = false;
                }
                break;

            case 3:
                if (Input.GetButtonDown(p3Input.CANCEL_AXIS))
                {
                    //set this ranger option to available
                    p2RangerArray[p3Current].SetAvailable();
                    p1RangerArray[p3Current].SetAvailable();
                    p4RangerArray[p3Current].SetAvailable();

                    //update current players options
                    if (p2Active)
                    {
                        p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                    }
                    if (p1Active)
                    {
                        p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                    }
                    if (p4Active)
                    {
                        p4RangerArray[p4Current].Selected(p4Ranger, p4Group);
                    }

                    //remove player ready banner
                    p3Group.transform.FindChild("Ready").gameObject.SetActive(false);

                    //decrease # of players confirmed
                    playersConfirmed--;

                    //set this player as unconfirmed
                    p3Confirmed = false;
                }
                break;

            case 4:
                if (Input.GetButtonDown(p4Input.CANCEL_AXIS))
                {
                    //set this ranger option to available
                    p2RangerArray[p4Current].SetAvailable();
                    p3RangerArray[p4Current].SetAvailable();
                    p1RangerArray[p4Current].SetAvailable();

                    //update current players options
                    if (p2Active)
                    {
                        p2RangerArray[p2Current].Selected(p2Ranger, p2Group);
                    }
                    if (p3Active)
                    {
                        p3RangerArray[p3Current].Selected(p3Ranger, p3Group);
                    }
                    if (p1Active)
                    {
                        p1RangerArray[p1Current].Selected(p1Ranger, p1Group);
                    }

                    //remove player ready banner
                    p4Group.transform.FindChild("Ready").gameObject.SetActive(false);

                    //decrease # of players confirmed
                    playersConfirmed--;

                    //set this player as unconfirmed
                    p4Confirmed = false;
                }
                break;
        }
    }

    /// <summary>
    /// this method will allow a player to quit the game after they joined in the character selection menu
    /// </summary>
    /// <param name="playerNum"></param>
    private void PlayerQuit(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
                if (Input.GetButtonDown(p1Input.CANCEL_AXIS)) //player hits cancel button
                {
                    //turn off selector
                    p1RangerArray[p1Current].Unselected(p1Group);

                    //set ranger sprite to the inactive ranger
                    p1Ranger.sprite = inactiveRanger;

                    //reset the p1current
                    p1Current = 0;

                    //turn Join game banner back on
                    p1Group.transform.FindChild("Join Game").gameObject.SetActive(true);

                    //make sure taken banner is off
                    p1Group.transform.FindChild("Taken").gameObject.SetActive(false);

                    //set player to inactive
                    p1Active = false;
                }
                break;

            case 2:
                if (Input.GetButtonDown(p2Input.CANCEL_AXIS)) //player hits cancel button
                {
                    //turn off selector
                    p2RangerArray[p2Current].Unselected(p2Group);

                    //set ranger sprite to the inactive ranger
                    p2Ranger.sprite = inactiveRanger;

                    //reset the p1current
                    p2Current = 0;

                    //turn Join game banner back on
                    p2Group.transform.FindChild("Join Game").gameObject.SetActive(true);

                    //make sure taken banner is off
                    p2Group.transform.FindChild("Taken").gameObject.SetActive(false);

                    //set player to inactive
                    p2Active = false;
                }
                break;

            case 3:
                if (Input.GetButtonDown(p3Input.CANCEL_AXIS)) //player hits cancel button
                {
                    //turn off selector
                    p3RangerArray[p3Current].Unselected(p3Group);

                    //set ranger sprite to the inactive ranger
                    p3Ranger.sprite = inactiveRanger;

                    //reset the p1current
                    p3Current = 0;

                    //turn Join game banner back on
                    p3Group.transform.FindChild("Join Game").gameObject.SetActive(true);

                    //make sure taken banner is off
                    p3Group.transform.FindChild("Taken").gameObject.SetActive(false);

                    //set player to inactive
                    p3Active = false;
                }
                break;

            case 4:
                if (Input.GetButtonDown(p4Input.CANCEL_AXIS)) //player hits cancel button
                {
                    //turn off selector
                    p4RangerArray[p4Current].Unselected(p4Group);

                    //set ranger sprite to the inactive ranger
                    p4Ranger.sprite = inactiveRanger;

                    //reset the p1current
                    p4Current = 0;

                    //turn Join game banner back on
                    p4Group.transform.FindChild("Join Game").gameObject.SetActive(true);

                    //make sure taken banner is off
                    p4Group.transform.FindChild("Taken").gameObject.SetActive(false);

                    //set player to inactive
                    p4Active = false;
                }
                break;
        }
    }

    /// <summary>
    /// This method will check for player input to start the game and if it can start the game it will transfer the correct data to the world controller 
    /// and move to the locading screen.
    /// </summary>
    private void StartGame()
    {
            if (Input.GetButtonDown("Pause"))
            {
                TransferPlayers();
                Application.LoadLevel("Loading Splash Screen");
            }
    }

    /// <summary>
    /// Used to check whether or not the game is allowed to be start and updates the canStart bool accordingly.
    /// It will also display the start game banner if game can be started.
    /// </summary>
    private void CheckCanStart()
    {
        //starts of by having the game be able to be started
        canStart = true;


        //Checks each active player and makes sure that they have confirmed a ranger.
        if (p1Active && !p1Confirmed)
        {
            canStart = false; //if they have not confirmed a ranger then game is no longer able to be started
        }

        if (p2Active && !p2Confirmed)
        {
            canStart = false;
        }

        if (p3Active && !p3Confirmed)
        {
            canStart = false;
        }

        if (p4Active && !p4Confirmed)
        {
            canStart = false;
        }

        //checks to make sure that more than 1 player is in the game and has confirmed
        if(playersConfirmed < 2)
        {
            //sets the game to no longer be able to start if there is not enough confirmed players.
            canStart = false;
        }

        if (canStart) //if game is allowed to start
        {
            start.SetActive(true); //displays the start game banner
            StartGame(); //launches the Start game method that will start the game when input is given.
        }
        else //game cannot be started
        {
            start.SetActive(false); //start game banner is not displayed
        }
    }

    private void TransferPlayers()
    {
        worldControl.SetPlayersActive(p1Active, p2Active, p3Active, p4Active);

        worldControl.SetRangerTypes(p1RangerArray[p1Current].RangerType, p2RangerArray[p2Current].RangerType, p3RangerArray[p3Current].RangerType, p4RangerArray[p4Current].RangerType);
    }
    #endregion
}
