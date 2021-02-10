using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("StartingArea");
    }

    public void ExitGame()
    {
        // maybe add a confirmation later
        Application.Quit();
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
