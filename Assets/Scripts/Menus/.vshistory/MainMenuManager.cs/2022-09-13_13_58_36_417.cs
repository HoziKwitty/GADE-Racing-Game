using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Checkpoint()
    {
        SceneManager.UnloadSceneAsync("Main Menu");
        SceneManager.LoadScene("Checkpoint Dialogue");
    }

    public void Beginner()
    {
        SceneManager.UnloadSceneAsync("Main Menu");
        SceneManager.LoadScene("Beginner Dialogue");
    }

    public void Advanced()
    {
        SceneManager.UnloadSceneAsync("Main Menu");
        SceneManager.LoadScene("Advanced Dialogue");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
