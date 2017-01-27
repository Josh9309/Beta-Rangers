using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour {
    //head sprites
    [SerializeField] Sprite redHead;
    [SerializeField] Sprite blackHead;
    [SerializeField] Sprite yellowHead;
    [SerializeField] Sprite pinkHead;
    [SerializeField] Sprite greenHead;
    [SerializeField] Sprite blueHead;

    //Arm sprites
    [SerializeField]
    Sprite redArm;
    [SerializeField]
    Sprite blackArm;
    [SerializeField]
    Sprite yellowArm;
    [SerializeField]
    Sprite pinkArm;
    [SerializeField]
    Sprite greenArm;
    [SerializeField]
    Sprite blueArm;

    //Torso sprites
    [SerializeField]
    Sprite redTorso;
    [SerializeField]
    Sprite blackTorso;
    [SerializeField]
    Sprite yellowTorso;
    [SerializeField]
    Sprite pinkTorso;
    [SerializeField]
    Sprite greenTorso;
    [SerializeField]
    Sprite blueTorso;

    //mech parts
    [SerializeField] SpriteRenderer torso;
    [SerializeField] SpriteRenderer armL;
    [SerializeField] SpriteRenderer armR;
    [SerializeField] SpriteRenderer head;

    //player
    WorldController worldControl;

    // Use this for initialization
    void Start () {
        worldControl = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>();
        UpdateHead();
        UpdateArmR();
        UpdateArmL();
        UpdateTorso();
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    private void UpdateHead()
    {
        switch (worldControl.WinnerType)
        {
            case Player.RangerType.RedRanger:
                head.sprite = redHead;
                break;

            case Player.RangerType.BlueRanger:
                head.sprite = blueHead;
                break;

            case Player.RangerType.GreenRanger:
                head.sprite = greenHead;
                break;

            case Player.RangerType.YellowRanger:
                head.sprite = yellowHead;
                break;

            case Player.RangerType.BlackRanger:
                head.sprite = blackHead;
                break;

            case Player.RangerType.PinkRanger:
                head.sprite = pinkHead;
                break;
        }
    }

    private void UpdateArmR()
    {
        switch (worldControl.WinnerType)
        {
            case Player.RangerType.RedRanger:
                armR.sprite = redArm;
                break;

            case Player.RangerType.BlueRanger:
                armR.sprite = blueArm;
                break;

            case Player.RangerType.GreenRanger:
                armR.sprite = greenArm;
                break;

            case Player.RangerType.YellowRanger:
                armR.sprite = yellowArm;
                break;

            case Player.RangerType.BlackRanger:
                armR.sprite = blackArm;
                break;

            case Player.RangerType.PinkRanger:
                armR.sprite = pinkArm;
                break;
        }
    }

    private void UpdateArmL()
    {
        switch (worldControl.WinnerType)
        {
            case Player.RangerType.RedRanger:
                armL.sprite = redArm;
                break;

            case Player.RangerType.BlueRanger:
                armL.sprite = blueArm;
                break;

            case Player.RangerType.GreenRanger:
                armL.sprite = greenArm;
                break;

            case Player.RangerType.YellowRanger:
                armL.sprite = yellowArm;
                break;

            case Player.RangerType.BlackRanger:
                armL.sprite = blackArm;
                break;

            case Player.RangerType.PinkRanger:
                armL.sprite = pinkArm;
                break;
        }
    }

    private void UpdateTorso()
    {
        switch (worldControl.WinnerType)
        {
            case Player.RangerType.RedRanger:
                torso.sprite = redTorso;
                break;

            case Player.RangerType.BlueRanger:
                torso.sprite = blueTorso;
                break;

            case Player.RangerType.GreenRanger:
                torso.sprite = greenTorso;
                break;

            case Player.RangerType.YellowRanger:
                torso.sprite = yellowTorso;
                break;

            case Player.RangerType.BlackRanger:
                torso.sprite = blackTorso;
                break;

            case Player.RangerType.PinkRanger:
                torso.sprite = pinkTorso;
                break;
        }
    }
}
