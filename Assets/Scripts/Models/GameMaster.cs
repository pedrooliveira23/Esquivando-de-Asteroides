using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster
{
    private int score;
    private float gameTime;
    private float waveTime;
    private bool isPaused;

    public GameMaster()
    {
        isPaused = false;
    }
    public int getScore() { return score; }
    public float getGameTime() { return gameTime; }
    public float getWaveTime() { return waveTime; }
    public bool getIsPaused() { return isPaused; }
    public void setScore(int score) { this.score = score; }
    public void setGameTime(float gameTime) { this.gameTime = gameTime; }
    public void setWavetime(float waveTime) { this.waveTime = waveTime; }
    public void setIsPaused(bool isPaused) { this.isPaused = isPaused; }
}
