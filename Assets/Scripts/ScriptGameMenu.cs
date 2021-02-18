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
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(Ranking);
        GameObject.Find("/CanvasMenu/BtnMenuPlay").GetComponent<Button>().onClick.AddListener(Sair);
    }

    private void Sair()
    {
        Application.Quit();
    }

    private void Ranking()
    {
        throw new NotImplementedException();
    }

    private void Play()
    {
        SceneManager.LoadScene("SceneGamePlay");
    }
}
