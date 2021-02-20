using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServiceSceneTransition : MonoBehaviour
{
    public static bool isAlive;
    public static bool isPaused;
    public static int finalScore;

    void Start()
    {
        isAlive = true;
        if (GameObject.Find("/CanvasMenu/BtnMenuPlay") != null) { 
            GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(goToSceneGamePlay);
        }
        if(GameObject.Find("/CanvasMenu/BtnMenuQuit") != null){ 
            GameObject.Find("/CanvasMenu/BtnMenuQuit").GetComponent<Button>().onClick.AddListener(quitGame);
        }
        if(GameObject.Find("/Canvas/CanvasPausado/BtnReplay") != null) { 
            GameObject.Find("/Canvas/CanvasPausado/BtnReplay").GetComponent<Button>().onClick.AddListener(goToSceneGamePlay);
        }
        if(GameObject.Find("/Canvas/CanvasPausado/BtnQuitGameMenu") != null) {
            GameObject.Find("/Canvas/CanvasPausado/BtnQuitGameMenu").GetComponent<Button>().onClick.AddListener(goToSceneGameMenu);
        }

    }

    void Update()
    {

        if (!isAlive) {
            goToGameOverScene();
        }

        if (isPaused)
        {
            if (GameObject.Find("/Canvas/CanvasPausado") != null)
            {
                GameObject.Find("/Canvas/CanvasPausado").SetActive(true);
            }
        } else
        {
            if (GameObject.Find("/Canvas/CanvasPausado") != null)
            {
                GameObject.Find("/Canvas/CanvasPausado").SetActive(false);
            }
        }
    }

    public void goToGameOverScene()
    {
        SceneManager.LoadScene("SceneGameOver");
    }

    public void goToSceneGameMenu()
    {
        SceneManager.LoadScene("SceneGameMenu");
    }

    public void goToSceneGamePlay()
    {
        SceneManager.LoadScene("SceneGamePlay");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
