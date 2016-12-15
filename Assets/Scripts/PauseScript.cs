using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public Transform pauseScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {

            if(pauseScreen.gameObject.activeInHierarchy == false)
            {
                pauseScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                pauseScreen.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
    }

    public void Exit()
    {
        Application.LoadLevel("MainScene");
    }
}
