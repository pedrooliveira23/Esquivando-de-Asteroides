using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGameOver : MonoBehaviour
{
    private ServiceSceneTransition serviceSceneTransition;
    private ServiceScoreRegister serviceScoreRegister;
    void Start()
    {
        serviceSceneTransition = GetComponent<ServiceSceneTransition>();
        serviceScoreRegister = GetComponent<ServiceScoreRegister>();
        GameObject.Find("/Canvas/BtnReplay").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.goToSceneGamePlay);
        GameObject.Find("/Canvas/BtnQuitGameMenu").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.goToSceneGameMenu);
        GameObject.Find("/Canvas/TextScore").GetComponent<Text>().text = "Pontuação: " + serviceScoreRegister.printScore();

    }


}
