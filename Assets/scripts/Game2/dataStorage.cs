using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataStorage : MonoBehaviour
{
    int FinalScore;
    public void TransformScore(int score)
    {
        FinalScore = score;
        Debug.Log("最终分数是：" + FinalScore);
    }
    public int GetFinalScore()
    {
        return FinalScore;
    }
}
