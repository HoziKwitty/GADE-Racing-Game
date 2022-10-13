using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Checkpoint()
    {
        SceneManager.UnloadSceneAsync("Main Menu");

    }

    public void Beginner()
    {
        SceneManager.UnloadSceneAsync("Main Menu");

    }

    public void Advanced()
    {
        SceneManager.UnloadSceneAsync("Main Menu");

    }

    public void Exit()
    {
        Application.Quit();
    }
}
