using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameButton (string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
