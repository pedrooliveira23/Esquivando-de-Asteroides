using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameOver : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 40), "Você perdeu! Pontuação: " + ScriptGameMaster.pontuacao);
        if (GUI.Button(new Rect(10, 70, 120, 40), "Jogar Novamente"))
        {
            ReiniciarJogo();
        }
        if (GUI.Button(new Rect(10, 120, 120, 40), "Sair do Jogo"))
        {
            SairDoJogo();
        }
    }

    public static void SairDoJogo()
    {
        Application.Quit();
    }

    public static void ReiniciarJogo()
    {
        ScriptGameMaster.pontuacao = 0;
        ScriptNave.velocidade = 30f;
        ScriptGameMaster.vivo = true;
        ScriptGameMaster.tempo = 0;
        SceneManager.LoadScene("SceneGamePlay");
    }
}
