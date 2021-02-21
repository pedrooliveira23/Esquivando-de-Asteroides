using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGamePlay : MonoBehaviour
{
    private ServiceSceneTransition serviceSceneTransition;
    private ServiceGameMaster serviceGameMaster;
    private ServiceScoreRegister serviceScoreRegister;
    // Start is called before the first frame update
    void Start()
    {
        serviceGameMaster = GetComponent<ServiceGameMaster>();
        serviceSceneTransition = GetComponent<ServiceSceneTransition>();
        serviceScoreRegister = GetComponent<ServiceScoreRegister>();
        GameObject.Find("/Canvas/CanvasPaused/BtnPlay").GetComponent<Button>().onClick.AddListener(serviceGameMaster.pauseGame);
        GameObject.Find("/Canvas/CanvasPaused/BtnReplay").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.goToSceneGamePlay);
        GameObject.Find("/Canvas/CanvasPaused/BtnQuitGameMenu").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.goToSceneGameMenu);
        GameObject.Find("/Canvas/BtnPause").GetComponent<Button>().onClick.AddListener(serviceGameMaster.pauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (serviceGameMaster.isPaused())
        {
            GameObject.Find("/Canvas/CanvasPaused").GetComponent<Canvas>().enabled = true;
        }
        else {
            GameObject.Find("/Canvas/CanvasPaused").GetComponent<Canvas>().enabled = false;
        }
        GameObject.Find("Canvas/TextScore").GetComponent<Text>().text = "Pontuação: " + serviceScoreRegister.printScore();
    }
}
