using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int totalQuestion;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        totalQuestion = FindObjectOfType<Quiz>().CountQuestion();
    }
    int questionCorrect = 0;
    public void IncreamentQuestionCorrect()
    {
        questionCorrect++;
    }
    public int GetTotalScore()
    {
        return questionCorrect;
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt((float)questionCorrect/totalQuestion * 100);
    }
}
