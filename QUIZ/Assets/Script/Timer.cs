using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 15f;
    [SerializeField] float timeToShowAnswer = 5f;
    public float fillTimerImage;
    public bool isAnswering;
    public bool loadNextQuestion;
    float timeValue;
    void Start()
    {
        
    }
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timeValue = 0;
    }
    void UpdateTimer()
    {
        timeValue -= Time.deltaTime;
        if(isAnswering)
        {
            if(timeValue > 0)
            {
                fillTimerImage = timeValue/timeToCompleteQuestion;
            }
            else
            {
                timeValue = timeToShowAnswer;
                isAnswering = false;
            }
        }
        else
        {
            if(timeValue > 0)
            {
                fillTimerImage = timeValue/timeToShowAnswer;
            }
            else
            {
                timeValue = timeToCompleteQuestion;
                isAnswering = true;
                loadNextQuestion = true;
            }
        }
    }
}
