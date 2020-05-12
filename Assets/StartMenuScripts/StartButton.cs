using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string lvlname = "scene";

    public void StartGame()
    {
        SceneManager.LoadScene(lvlname);
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
