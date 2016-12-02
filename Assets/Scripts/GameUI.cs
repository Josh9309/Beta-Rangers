using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GameUI : MonoBehaviour {
    #region Attribute
    private WorldController worldControl;
    [SerializeField] private Color superAvailableColor;
    [SerializeField] private Color normalSuperBarColor;
    private Sprite p1RangerDead;
    private Sprite p2RangerDead;
    private Sprite p3RangerDead;
    private Sprite p4RangerDead;

    //Ranger Profiles
    [SerializeField] private Sprite redRangerProfile;
    [SerializeField] private Sprite blueRangerProfile;
    [SerializeField] private Sprite greenRangerProfile;
    [SerializeField] private Sprite yellowRangerProfile;
    [SerializeField] private Sprite blackRangerProfile;
    [SerializeField] private Sprite pinkRangerProfile;

    //Dead Ranger Profiles
    [SerializeField] private Sprite redDeadRangerProfile;
    [SerializeField] private Sprite blueDeadRangerProfile;
    [SerializeField] private Sprite greenDeadRangerProfile;
    [SerializeField] private Sprite yellowDeadRangerProfile;
    [SerializeField] private Sprite blackDeadRangerProfile;
    [SerializeField] private Sprite pinkDeadRangerProfile;

    //p1 Hud
    private Image p1Profile;
    private Slider p1HealthBar;
    private Slider p1SuperBar;

    //p2 Hud
    private Image p2Profile;
    private Slider p2HealthBar;
    private Slider p2SuperBar;

    //p3 Hud
    private Image p3Profile;
    private Slider p3HealthBar;
    private Slider p3SuperBar;

    //p4 Hud
    private Image p4Profile;
    private Slider p4HealthBar;
    private Slider p4SuperBar;
    #endregion
    // Use this for initialization
    void Start () {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();

        //get p1 hud
        p1Profile = GameObject.Find("P1 Profile").GetComponent<Image>();
        p1HealthBar = GameObject.Find("P1 Health Bar").GetComponent<Slider>();
        p1SuperBar = GameObject.Find("P1 Super Bar").GetComponent<Slider>();

        //get p2 hud
        p2Profile = GameObject.Find("P2 Profile").GetComponent<Image>();
        p2HealthBar = GameObject.Find("P2 Health Bar").GetComponent<Slider>();
        p2SuperBar = GameObject.Find("P2 Super Bar").GetComponent<Slider>();

        //get p3 hud
        p3Profile = GameObject.Find("P3 Profile").GetComponent<Image>();
        p3HealthBar = GameObject.Find("P3 Health Bar").GetComponent<Slider>();
        p3SuperBar = GameObject.Find("P3 Super Bar").GetComponent<Slider>();

        //get p4 hud
        p4Profile = GameObject.Find("P4 Profile").GetComponent<Image>();
        p4HealthBar = GameObject.Find("P4 Health Bar").GetComponent<Slider>();
        p4SuperBar = GameObject.Find("P4 Super Bar").GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update () {
        UpdateHealthBars();
        UpdateSuperBars();
	}

    public void SetupUI()
    {
        //worldControl.AssignPlayers();

        if (worldControl.P1Active)
        {
            //setup the correct ranger profile for player 1
            switch (worldControl.Player1.Ranger)
            {
                case Player.RangerType.BlackRanger:
                    p1Profile.sprite = blackRangerProfile;
                    p1RangerDead = blackDeadRangerProfile;
                    break;

                case Player.RangerType.BlueRanger:
                    p1Profile.sprite = blueRangerProfile;
                    p1RangerDead = blueDeadRangerProfile;
                    break;

                case Player.RangerType.GreenRanger:
                    p1Profile.sprite = greenRangerProfile;
                    p1RangerDead = greenDeadRangerProfile;
                    break;

                case Player.RangerType.PinkRanger:
                    p1Profile.sprite = pinkRangerProfile;
                    p1RangerDead = pinkDeadRangerProfile;
                    break;

                case Player.RangerType.RedRanger:
                    p1Profile.sprite = redRangerProfile;
                    p1RangerDead = redDeadRangerProfile;
                    break;

                case Player.RangerType.YellowRanger:
                    p1Profile.sprite = yellowRangerProfile;
                    p1RangerDead = yellowDeadRangerProfile;
                    break;
            }
            //setup player 1 health bar
            p1HealthBar.maxValue = worldControl.Player1.Health;
            p1HealthBar.value = worldControl.Player1.Health;
            //setup player 1 super bar
            p1SuperBar.maxValue = worldControl.Player1.SuperMax;
            p1SuperBar.value = worldControl.Player1.SuperCurrent;
        }
        else
        {
            p1HealthBar.gameObject.SetActive(false);
            p1Profile.gameObject.SetActive(false);
            p1SuperBar.gameObject.SetActive(false);
        }

        if (worldControl.P2Active)
        {
            //setup the correct ranger profile for player 2
            switch (worldControl.Player2.Ranger)
            {
                case Player.RangerType.BlackRanger:
                    p2Profile.sprite = blackRangerProfile;
                    p2RangerDead = blackDeadRangerProfile;
                    break;

                case Player.RangerType.BlueRanger:
                    p2Profile.sprite = blueRangerProfile;
                    p2RangerDead = blueDeadRangerProfile;
                    break;

                case Player.RangerType.GreenRanger:
                    p2Profile.sprite = greenRangerProfile;
                    p2RangerDead = greenDeadRangerProfile;
                    break;

                case Player.RangerType.PinkRanger:
                    p2Profile.sprite = pinkRangerProfile;
                    p2RangerDead = pinkDeadRangerProfile;
                    break;

                case Player.RangerType.RedRanger:
                    p2Profile.sprite = redRangerProfile;
                    p2RangerDead = redDeadRangerProfile;
                    break;

                case Player.RangerType.YellowRanger:
                    p2Profile.sprite = yellowRangerProfile;
                    p2RangerDead = yellowDeadRangerProfile;
                    break;
            }
            //setup player 2 health bar
            p2HealthBar.maxValue = worldControl.Player2.Health;
            p2HealthBar.value = worldControl.Player2.Health;
            //setup player 1 super bar
            p2SuperBar.maxValue = worldControl.Player2.SuperMax;
            p2SuperBar.value = worldControl.Player2.SuperCurrent;
        }
        else
        {
            p2HealthBar.gameObject.SetActive(false);
            p2Profile.gameObject.SetActive(false);
            p2SuperBar.gameObject.SetActive(false);
        }

        if (worldControl.P3Active)
        {
            //setup the correct ranger profile for player 3
            switch (worldControl.Player3.Ranger)
            {
                case Player.RangerType.BlackRanger:
                    p3Profile.sprite = blackRangerProfile;
                    p3RangerDead = blackDeadRangerProfile;
                    break;

                case Player.RangerType.BlueRanger:
                    p3Profile.sprite = blueRangerProfile;
                    p3RangerDead = blueDeadRangerProfile;
                    break;

                case Player.RangerType.GreenRanger:
                    p3Profile.sprite = greenRangerProfile;
                    p3RangerDead = greenDeadRangerProfile;
                    break;

                case Player.RangerType.PinkRanger:
                    p3Profile.sprite = pinkRangerProfile;
                    p3RangerDead = pinkDeadRangerProfile;
                    break;

                case Player.RangerType.RedRanger:
                    p3Profile.sprite = redRangerProfile;
                    p3RangerDead = redDeadRangerProfile;
                    break;

                case Player.RangerType.YellowRanger:
                    p3Profile.sprite = yellowRangerProfile;
                    p3RangerDead = yellowDeadRangerProfile;
                    break;
            }
            //setup player 3 health bar
            p3HealthBar.maxValue = worldControl.Player3.Health;
            p3HealthBar.value = worldControl.Player3.Health;
            //setup player 3 super bar
            p3SuperBar.maxValue = worldControl.Player3.SuperMax;
            p3SuperBar.value = worldControl.Player3.SuperCurrent;
        }
        else
        {
            p3HealthBar.gameObject.SetActive(false);
            p3Profile.gameObject.SetActive(false);
            p3SuperBar.gameObject.SetActive(false);
        }

        if (worldControl.P4Active)
        {
            //setup the correct ranger profile for player 4
            switch (worldControl.Player4.Ranger)
            {
                case Player.RangerType.BlackRanger:
                    p4Profile.sprite = blackRangerProfile;
                    p4RangerDead = blackDeadRangerProfile;
                    break;

                case Player.RangerType.BlueRanger:
                    p4Profile.sprite = blueRangerProfile;
                    p4RangerDead = blueDeadRangerProfile;
                    break;

                case Player.RangerType.GreenRanger:
                    p4Profile.sprite = greenRangerProfile;
                    p4RangerDead = greenDeadRangerProfile;
                    break;

                case Player.RangerType.PinkRanger:
                    p4Profile.sprite = pinkRangerProfile;
                    p4RangerDead = pinkDeadRangerProfile;
                    break;

                case Player.RangerType.RedRanger:
                    p4Profile.sprite = redRangerProfile;
                    p4RangerDead = redDeadRangerProfile;
                    break;

                case Player.RangerType.YellowRanger:
                    p4Profile.sprite = yellowRangerProfile;
                    p4RangerDead = yellowDeadRangerProfile;
                    break;
            }
            //setup player 4 health bar
            p4HealthBar.maxValue = worldControl.Player4.Health;
            p4HealthBar.value = worldControl.Player4.Health;
            //setup player 4 super bar
            p4SuperBar.maxValue = worldControl.Player4.SuperMax;
            p4SuperBar.value = worldControl.Player4.SuperCurrent;
        }
        else
        {
            p4HealthBar.gameObject.SetActive(false);
            p4Profile.gameObject.SetActive(false);
            p4SuperBar.gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBars()
    {
        if (worldControl.P1Active)
        {
            //update p1 health bar
            p1HealthBar.value = worldControl.Player1.Health;
            if (worldControl.Player1.Health <= 0 || worldControl.Player1 == null)
            {
                p1Profile.sprite = p1RangerDead;
                p1HealthBar.value = 0;
            }
        }

        if (worldControl.P2Active)
        {
            //update p2 health bar
            p2HealthBar.value = worldControl.Player2.Health;
            if (worldControl.Player2.Health <= 0 || worldControl.Player2 == null)
            {
                p2Profile.sprite = p2RangerDead;
                p2HealthBar.value = 0;
            }
        }

        if (worldControl.P3Active)
        {
            //update p3 health bar
            p3HealthBar.value = worldControl.Player3.Health;
            if (worldControl.Player3.Health <= 0 || worldControl.Player3 == null)
            {
                p3Profile.sprite = p3RangerDead;
                p3HealthBar.value = 0;
            }
        }

        if (worldControl.P4Active)
        {
            //update p4 health bar
            p4HealthBar.value = worldControl.Player4.Health;
            if (worldControl.Player4.Health <= 0 || worldControl.Player4 == null)
            {
                p4Profile.sprite = p4RangerDead;
                p4HealthBar.value = 0;
            }
        }
    }

    public void UpdateSuperBars()
    {
        if (worldControl.P1Active)
        {
            //update p1 super bar
            p1SuperBar.value = worldControl.Player1.SuperCurrent;

            if (worldControl.Player1.SuperCurrent >= worldControl.Player1.SuperCost) //if the super is available 
            {
                p1SuperBar.GetComponentInChildren<Image>().color = superAvailableColor; //changes super bar color to show super is ready
            }
            else
            {
                p1SuperBar.GetComponentInChildren<Image>().color = normalSuperBarColor; //reverts super bar back to normal color
            }
        }

        if (worldControl.P2Active)
        {
            //update p2 super bar
            p2SuperBar.value = worldControl.Player2.SuperCurrent;

            if (worldControl.Player2.SuperCurrent >= worldControl.Player2.SuperCost) //if the super is available 
            {
                p2SuperBar.GetComponentInChildren<Image>().color = superAvailableColor; //changes super bar color to show super is ready
            }
            else
            {
                p2SuperBar.GetComponentInChildren<Image>().color = normalSuperBarColor; //reverts super bar back to normal color
            }
        }

        if (worldControl.P3Active)
        {
            //update p3 super bar
            p3SuperBar.value = worldControl.Player3.SuperCurrent;

            if (worldControl.Player3.SuperCurrent >= worldControl.Player3.SuperCost) //if the super is available 
            {
                p3SuperBar.GetComponentInChildren<Image>().color = superAvailableColor; //changes super bar color to show super is ready
            }
            else
            {
                p3SuperBar.GetComponentInChildren<Image>().color = normalSuperBarColor; //reverts super bar back to normal color
            }
        }

        if (worldControl.P4Active)
        {
            //update p4 super bar
            p4SuperBar.value = worldControl.Player4.SuperCurrent;

            if (worldControl.Player4.SuperCurrent >= worldControl.Player4.SuperCost) //if the super is available 
            {
                p4SuperBar.GetComponentInChildren<Image>().color = superAvailableColor; //changes super bar color to show super is ready
            }
            else
            {
                p4SuperBar.GetComponentInChildren<Image>().color = normalSuperBarColor; //reverts super bar back to normal color
            }
        }
    }
}
