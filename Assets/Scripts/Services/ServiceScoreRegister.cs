using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceScoreRegister : MonoBehaviour
{
    // Update is called once per frame
    public void updateScore(int score)
    {
        ScoreRegister.score = score;
    }

    public int printScore()
    {
        return ScoreRegister.score;
    }
}
