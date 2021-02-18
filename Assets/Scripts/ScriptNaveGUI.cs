using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptNaveGUI : MonoBehaviour
{
    private Text textoPontuacao;
    void Start()
    {
        textoPontuacao = GameObject.Find("TextPontuacao").GetComponent<Text>();
        //TODO: essa parte do código está dando nullpointer, porém funciona
        GetComponentInChildren<Button>().onClick.AddListener(Pausar);
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
        } else
        {
            Time.timeScale = 1;
        }
    }
}
