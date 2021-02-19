using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ScriptGameMaster : MonoBehaviour
{

    public GameObject prefabAsteroide;
    public static int pontuacao = 0;
    public static Boolean vivo = true;
    public static int tempo = 0;
    public static float tick;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("contaPontuacao");
        StartCoroutine("ondaDeAsteroides");
        StartCoroutine("ondaDeAsteroidesNoPlayer");
        StartCoroutine("contaTempo");

        for(int i = 0; i <= 300; i++)
        {
            criarAsteroidesInicio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!vivo)
        {
            StartCoroutine("transicaoScene");
        }

        tick = 1f / (tempo/4);
    }

    private void criarAsteroides()
    {
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 20.0f), UnityEngine.Random.Range(1.0f, 20.0f), UnityEngine.Random.Range(1.0f, 20.0f));
        Instantiate(prefabAsteroide, new Vector3(-3000, UnityEngine.Random.Range(-500, 500), UnityEngine.Random.Range(-500, 500)), Quaternion.identity);
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f));
        Instantiate(prefabAsteroide, new Vector3(-3000, UnityEngine.Random.Range(-250, 250), UnityEngine.Random.Range(-250, 250)), Quaternion.identity);
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f));
        Instantiate(prefabAsteroide, new Vector3(-3000, UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(-50, 50)), Quaternion.identity);
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 5.0f), UnityEngine.Random.Range(1.0f, 5.0f), UnityEngine.Random.Range(1.0f, 5.0f));
        Instantiate(prefabAsteroide, new Vector3(3000, UnityEngine.Random.Range(GameObject.Find("Player").transform.position.y - 25, GameObject.Find("Player").transform.position.y + 25), UnityEngine.Random.Range(GameObject.Find("Player").transform.position.z - 25, GameObject.Find("Player").transform.position.z + 25)), Quaternion.identity);

    }

    private void criarAsteroidesNoPlayer()
    {
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f));
        Instantiate(prefabAsteroide, new Vector3(-3000, GameObject.Find("Player").transform.position.y, GameObject.Find("Player").transform.position.z - 1), Quaternion.identity);
    }

    private void criarAsteroidesInicio()
    {
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 20.0f), UnityEngine.Random.Range(1.0f, 20.0f), UnityEngine.Random.Range(1.0f, 20.0f));
        Instantiate(prefabAsteroide, new Vector3(UnityEngine.Random.Range(-100,-3000), UnityEngine.Random.Range(-500, 500), UnityEngine.Random.Range(-500, 500)), Quaternion.identity);
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f));
        Instantiate(prefabAsteroide, new Vector3(UnityEngine.Random.Range(-100, -3000), UnityEngine.Random.Range(-250, 250), UnityEngine.Random.Range(-250, 250)), Quaternion.identity);
        prefabAsteroide.transform.localScale = new Vector3(UnityEngine.Random.Range(1.0f, 5.0f), UnityEngine.Random.Range(1.0f, 5.0f), UnityEngine.Random.Range(1.0f, 5.0f));
        Instantiate(prefabAsteroide, new Vector3(UnityEngine.Random.Range(-100, -3000), UnityEngine.Random.Range(GameObject.Find("Player").transform.position.y - 25, GameObject.Find("Player").transform.position.y + 25), UnityEngine.Random.Range(GameObject.Find("Player").transform.position.z - 25, GameObject.Find("Player").transform.position.z + 25)), Quaternion.identity);
    }

    IEnumerator ondaDeAsteroides()
    {
        while (true)
        {
            if(float.IsInfinity(tick)) { 
                yield return new WaitForSeconds(1f);
            } else
            {
                yield return new WaitForSeconds(tick);
            }
            criarAsteroides();
        }
    }

    IEnumerator ondaDeAsteroidesNoPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(tick,15.0f));
            criarAsteroidesNoPlayer();
        }
    }

    IEnumerator contaPontuacao()
    {
        while (true && vivo)
        {
            if (float.IsInfinity(tick))
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(tick);
            }
            pontuacao++;
        }
    }

    IEnumerator transicaoScene()
    {
        if (vivo == false)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("SceneGameOver");
        }
    }

    IEnumerator contaTempo()
    {
        while (true) { 
            yield return new WaitForSeconds(1f);
            tempo++;
        }
    }
}
