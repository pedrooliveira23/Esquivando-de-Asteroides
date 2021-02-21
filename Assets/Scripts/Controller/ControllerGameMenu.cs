using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGameMenu : MonoBehaviour
{
    private ServiceSceneTransition serviceSceneTransition;
    // Start is called before the first frame update
    void Start()
    {
        serviceSceneTransition = GetComponent<ServiceSceneTransition>();
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.goToSceneGamePlay);
        GameObject.Find("/CanvasMenu/BtnMenuQuit").GetComponent<Button>().onClick.AddListener(serviceSceneTransition.quitGame);
    }
}
