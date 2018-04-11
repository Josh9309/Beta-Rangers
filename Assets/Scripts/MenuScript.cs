using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

    [SerializeField] private CanvasGroup optionGroup;
    [SerializeField] private CanvasGroup creditsGroup;
    [SerializeField] private CanvasGroup controlsGroup;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchOptions()
    {
        //turn off other canvas groups
        creditsGroup.alpha = 0;
        creditsGroup.interactable = false;
        controlsGroup.alpha = 0;
        controlsGroup.interactable = false;

        //turn on options group
        optionGroup.alpha = 1;
        optionGroup.interactable = true;

        //make controls btn the current selected 
        EventSystem.current.SetSelectedGameObject(optionGroup.transform.Find("ControlsBtn").gameObject);
    }

    public void SwitchControls()
    {
        //turns off other canvas group
        creditsGroup.alpha = 0;
        creditsGroup.interactable = false;
        optionGroup.alpha = 0;
        optionGroup.interactable = false;

        //turn on controls group
        controlsGroup.alpha = 1;
        controlsGroup.interactable = true;

        //make controls back button the current selected
        EventSystem.current.SetSelectedGameObject(controlsGroup.transform.Find("BackBtn").gameObject);
    }

    public void SwitchCredits()
    {
        //turns off other canvas group
        controlsGroup.alpha = 0;
        controlsGroup.interactable = false;
        optionGroup.alpha = 0;
        optionGroup.interactable = false;

        //turn on controls group
        creditsGroup.alpha = 1;
        creditsGroup.interactable = true;

        //make controls back button the current selected
        EventSystem.current.SetSelectedGameObject(creditsGroup.transform.Find("BackBtn").gameObject);
    }

    public void LoadScene(string scene)
    {
        switch (scene)
        {
            case "MainScene":
                Destroy(GameObject.FindGameObjectWithTag("Game Manager"));
                break;

            case "Stage 1":
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>().CurrentMenu = WorldController.cMenu.BATTLE;
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>().CurrentLevel = WorldController.cLevel.STAGE1;
                break;

            case "Options":
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>().CurrentMenu = WorldController.cMenu.OPTIONS;
                break;

            case "Loading Splash Screen":
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>().CurrentMenu = WorldController.cMenu.LOADING;
                break;
        }
        
        Application.LoadLevel(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
