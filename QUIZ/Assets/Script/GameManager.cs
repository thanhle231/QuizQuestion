using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject quiz;
    Quiz quizComplete;
    [SerializeField] GameObject Endgame;
    // Start is called before the first frame update
    void Start()
    {
        quizComplete = FindObjectOfType<Quiz>();
    }

    // Update is called once per frame
    void Update()
    {
        if(quizComplete.isComplete)
        {
            quiz.gameObject.SetActive(false);
            Endgame.gameObject.SetActive(true);
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
