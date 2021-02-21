using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private int gameSpeed;
    private float gameTime;
    private float waveTime;
    private bool isPaused;

    public GameMaster()
    {
        isPaused = false;
    }
    public float getGameTime() { return gameTime; }
    public float getWaveTime() { return waveTime; }
    public bool getIsPaused() { return isPaused; }
    public int getGameSpeed() { return gameSpeed; }
    public void setGameTime(float gameTime) { this.gameTime = gameTime; }
    public void setWavetime(float waveTime) { this.waveTime = waveTime; }
    public void setIsPaused(bool isPaused) { this.isPaused = isPaused; }
    public void setGameSpeed(int gameSpeed) { this.gameSpeed = gameSpeed; }
}
