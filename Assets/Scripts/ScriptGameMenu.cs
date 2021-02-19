using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(Play);
        GameObject.Find("/CanvasMenu/BtnSair").GetComponent<Button>().onClick.AddListener(Sair);
    }

    private void Sair()
    {
        Debug.Log("Sair");
        Application.Quit();
    }

    private void Play()
    {
        SceneManager.LoadScene("SceneGamePlay");
    }
}
