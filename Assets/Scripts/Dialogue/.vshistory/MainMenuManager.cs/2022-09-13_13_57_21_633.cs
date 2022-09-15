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

    }

    public void Advanced()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
