using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadScene(string scene)
    {
        switch (scene)
        {
            case "Main Menu":
                GameObject.FindGameObjectWithTag("Game Manager").GetComponent<WorldController>().CurrentMenu = WorldController.cMenu.MAINMENU;
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
