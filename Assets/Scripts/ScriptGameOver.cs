using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptGameOver : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("/CanvasGameOver/BtnReplay").GetComponent<Button>().onClick.AddListener(ReiniciarJogo);
        GameObject.Find("/CanvasGameOver/BtnSair").GetComponent<Button>().onClick.AddListener(SairParaMenu);
    }
    void Update()
    {
        GameObject.Find("/CanvasGameOver/TextPontuacaoFinal").GetComponent<Text>().text = "Pontuação: " + ScriptGameMaster.pontuacao;
    }

    public static void SairParaMenu()
    {
        GameObject.Find("/CanvasGameOver/AudioClick").GetComponent<AudioSource>().Play();
        ReiniciarJogo();
        SceneManager.LoadScene("SceneGameMenu");
    }

    public static void ReiniciarJogo()
    {
        GameObject.Find("/CanvasGameOver/AudioClick").GetComponent<AudioSource>().Play();
        ScriptGameMaster.pontuacao = 0;
        ScriptNave.velocidade = 0;
        ScriptGameMaster.vivo = true;
        ScriptGameMaster.tempo = 0;
        SceneManager.LoadScene("SceneGamePlay");
    }
}
