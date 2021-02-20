using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceGameMaster : MonoBehaviour
{
    public static GameMaster gameMaster;
    private Ship ship;
    public GameObject prefabAsteroid;

    void Start()
    {
        gameMaster = new GameMaster();
        ship = ServiceShip.ship;
        StartCoroutine("updateScore");
        StartCoroutine("updateGameTime");

        if(prefabAsteroid != null) {
            StartCoroutine(normalAsteroidWave(gameMaster.getWaveTime(), gameMaster.getWaveTime()));
            StartCoroutine(specialAsteroidWave(1f,15f));
            initialAsteroidWave();
        }

        if(GameObject.Find("Canvas/BtnPause") != null) {
            GameObject.Find("Canvas/BtnPause").GetComponent<Button>().onClick.AddListener(pauseGame);
        }
    }

    void Update()
    {
        if (GameObject.Find("Canvas/TextScore") != null)
        {
            GameObject.Find("Canvas/TextScore").GetComponent<Text>().text = "Pontuação: " + gameMaster.getScore();
        }
        gameMaster.setWavetime(1f / (gameMaster.getGameTime() / 4f));
    }

    public void initiateNewGame()
    {
        ship.setIsAlive(true);
        gameMaster.setScore(0);
        gameMaster.setGameTime(0);
        gameMaster.setWavetime(0);
        gameMaster.setIsPaused(false);
    }

    public void pauseGame()
    {
        if (gameMaster.getIsPaused())
        {
            Time.timeScale = 1;
            gameMaster.setIsPaused(false);
            ServiceSceneTransition.isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            gameMaster.setIsPaused(true);
            ServiceSceneTransition.isPaused = true;
        }
    }

    public void createAsteroid(Vector3 size, Vector3 position)
    {
        prefabAsteroid.transform.localScale = size;
        Instantiate(prefabAsteroid, position, Quaternion.identity);
    }

    IEnumerator updateScore()
    {
        while (true && ship.getIsAlive())
        {
            if (float.IsInfinity(gameMaster.getWaveTime()))
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(gameMaster.getWaveTime());
            }
            gameMaster.setScore(gameMaster.getScore()+1);
            ServiceAsteroid.asteroid.setVelocity(ServiceAsteroid.asteroid.getVelocity() + 1);
        }
    }

    IEnumerator updateGameTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gameMaster.setGameTime(gameMaster.getGameTime()+1);
        }
    }

    IEnumerator normalAsteroidWave(float minimalTime, float maximumTime)
    {
        while (true)
        {
            if(float.IsInfinity(minimalTime) || float.IsInfinity(maximumTime))
            {
                yield return new WaitForSeconds(1f);
            } else
            {
                yield return new WaitForSeconds(Random.Range(minimalTime,maximumTime));
            }

            createAsteroid(new Vector3(Random.Range(1.0f, 20.0f), Random.Range(1.0f, 20.0f), Random.Range(1.0f, 20.0f)), new Vector3(-3000, Random.Range(-500, 500), Random.Range(-500, 500)));
            createAsteroid(new Vector3(Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f)), new Vector3(-3000, Random.Range(-250, 250), Random.Range(-250, 250)));
            createAsteroid(new Vector3(Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f)), new Vector3(-3000, Random.Range(-50, 50), Random.Range(-50, 50)));
        }
    }

    IEnumerator specialAsteroidWave(float minimalTime, float maximumTime)
    {
        while (true)
        {
            if (float.IsInfinity(minimalTime) || float.IsInfinity(maximumTime))
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(minimalTime, maximumTime));
            }

            createAsteroid(new Vector3(Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f)), new Vector3(-3000, GameObject.Find("Ship").transform.position.y, GameObject.Find("Ship").transform.position.z));        }

    }

    public void initialAsteroidWave()
    {
        for(int i = 0; i <=300; i++)
        {
            createAsteroid(new Vector3(Random.Range(1.0f, 20.0f), Random.Range(1.0f, 20.0f), Random.Range(1.0f, 20.0f)), new Vector3(Random.Range(-100, -3000), Random.Range(-500, 500), Random.Range(-500, 500)));
            createAsteroid(new Vector3(Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f)), new Vector3(Random.Range(-100, -3000), Random.Range(-250, 250), Random.Range(-250, 250)));
            createAsteroid(new Vector3(Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f)), new Vector3(Random.Range(-100, -3000), Random.Range(GameObject.Find("Ship").transform.position.y - 25, GameObject.Find("Ship").transform.position.y + 25), Random.Range(GameObject.Find("Ship").transform.position.z - 25, GameObject.Find("Ship").transform.position.z + 25)));
        }
    }
}
