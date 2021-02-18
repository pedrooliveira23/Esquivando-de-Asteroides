using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptGamePlayGUI : MonoBehaviour
{
    private Text textoPontuacao;
    private GameObject canvasPausado;
    void Start()
    {
        textoPontuacao = GameObject.Find("TextPontuacao").GetComponent<Text>();
        GetComponentInChildren<Button>().onClick.AddListener(Pausar);
        GameObject.Find("/Canvas/CanvasPausado/BtnPlay").GetComponent<Button>().onClick.AddListener(Pausar);
        GameObject.Find("/Canvas/CanvasPausado/BtnReplay").GetComponent<Button>().onClick.AddListener(Replay);
        GameObject.Find("/Canvas/CanvasPausado/BtnSair").GetComponent<Button>().onClick.AddListener(Sair);
        canvasPausado = GameObject.Find("/Canvas/CanvasPausado");
        canvasPausado.SetActive(false);
    }

    private void Sair()
    {
        Pausar();
        SceneManager.LoadScene("SceneGameMenu");
    }

    private void Replay()
    {
        Pausar();
        ScriptGameOver.ReiniciarJogo();
    }

    void Update()
    {
        textoPontuacao.text ="Pontuação: " + ScriptGameMaster.pontuacao;
    }

    public void Pausar()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            canvasPausado.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            canvasPausado.SetActive(false);
        }
    }
}
