using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServiceSceneTransition : MonoBehaviour
{
    public void goToGameOverScene()
    {
        Debug.Log("Loading SceneGameOver");
        SceneManager.LoadScene("SceneGameOver");
    }

    public void goToSceneGameMenu()
    {
        Debug.Log("Loading SceneGameMenu");
        SceneManager.LoadScene("SceneGameMenu");
    }

    public void goToSceneGamePlay()
    {
        Debug.Log("Loading SceneGamePlay");
        SceneManager.LoadScene("SceneGamePlay");
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
