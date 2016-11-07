using UnityEngine;
using System.Collections;

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
