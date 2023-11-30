using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] Button button;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        endText.text = "Congratulation!!!\nyour score: " + scoreKeeper.CalculateScore() +"%";
    }
    public void PlayAGain()
    {
        gameManager.OnReplayLevel();
    }
}
