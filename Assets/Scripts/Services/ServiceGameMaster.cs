﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceGameMaster : MonoBehaviour
{
    private GameMaster gameMaster;
    private ServiceShip serviceShip;
    private ServiceSceneTransition serviceSceneTransition;
    private ServiceScoreRegister serviceScoreRegister;
    private ServiceAsteroid serviceAsteroid;
    public GameObject prefabAsteroid;

    void Start()
    {
        gameMaster = GetComponent<GameMaster>();
        serviceScoreRegister = GetComponent<ServiceScoreRegister>();
        serviceShip = GameObject.Find("Ship").GetComponent<ServiceShip>();
        serviceSceneTransition = GetComponent<ServiceSceneTransition>();
        serviceAsteroid = prefabAsteroid.GetComponent<ServiceAsteroid>();
        initiateNewGame();
        initialAsteroidWave();
        StartCoroutine("normalAsteroidWave");
        StartCoroutine("specialAsteroidWave");
        StartCoroutine("updateScore");
        StartCoroutine("updateGameTime");
    }

    void Update()
    {
        verifyIfAlive();
        serviceAsteroid.updateVelocity(gameMaster.getGameSpeed());
        gameMaster.setWavetime(1.0f / (gameMaster.getGameTime()/2));
    }

    public void initiateNewGame()
    {
        serviceShip.initiateNewGame();
        serviceScoreRegister.updateScore(0);
        gameMaster.setGameSpeed(20);
        gameMaster.setGameTime(0);
        gameMaster.setWavetime(0);
        gameMaster.setIsPaused(false);
        Time.timeScale = 1;
    }
    public void pauseGame()
    {
        if (gameMaster.getIsPaused())
        {
            Time.timeScale = 1;
            gameMaster.setIsPaused(false);
            serviceShip.pauseInput();
        }
        else
        {
            Time.timeScale = 0;
            gameMaster.setIsPaused(true);
            serviceShip.pauseInput();
        }
    }

    public bool isPaused()
    {
        return gameMaster.getIsPaused();
    }
    public void verifyIfAlive()
    {
        if (!serviceShip.isAlive())
        {
            serviceSceneTransition.goToGameOverScene();
        }
    }

    public void createAsteroid(Vector3 size, Vector3 position)
    {
        prefabAsteroid.transform.localScale = size;
        Instantiate(prefabAsteroid, position, Quaternion.identity);
    }

    IEnumerator updateScore()
    {
        while (true && serviceShip.isAlive() && serviceShip.isInputPaused())
        {
            if (float.IsInfinity(gameMaster.getWaveTime()))
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(gameMaster.getWaveTime());
            }

            serviceScoreRegister.updateScore(serviceScoreRegister.printScore() + 1);
            gameMaster.setGameSpeed(gameMaster.getGameSpeed() + 1);
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

    IEnumerator normalAsteroidWave()
    {
        while (true) { 
            if(float.IsInfinity(gameMaster.getWaveTime()))
            {
                yield return new WaitForSeconds(1f);
            } else
            {
                yield return new WaitForSeconds(gameMaster.getWaveTime());
            }
            createAsteroid(new Vector3(Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f)), new Vector3(-3000, Random.Range(-50, 50), Random.Range(-50, 50)));
        }
    }

    IEnumerator specialAsteroidWave()
    {
        while (true) { 
            yield return new WaitForSeconds(Random.Range(1.0f, 15.0f));
            createAsteroid(new Vector3(Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f)), new Vector3(-3000, GameObject.Find("Ship").transform.position.y, GameObject.Find("Ship").transform.position.z));
        }
    }

    public void initialAsteroidWave()
    {
        for(int i = 0; i <=100; i++)
        {
            createAsteroid(new Vector3(Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f)), new Vector3(Random.Range(-100, -3000), Random.Range(GameObject.Find("Ship").transform.position.y - 25, GameObject.Find("Ship").transform.position.y + 25), Random.Range(GameObject.Find("Ship").transform.position.z - 25, GameObject.Find("Ship").transform.position.z + 25)));
        }
    }
}
