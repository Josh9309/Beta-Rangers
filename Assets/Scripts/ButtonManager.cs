using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public void NewGameButton(string newGameLevel)
    {
        Application.LoadLevel(newGameLevel);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}