using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Question")]
    [SerializeField] List<QuestionSO> questions;
    [SerializeField] TextMeshProUGUI questionText;
    QuestionSO currentQuestion;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Button")]
    [SerializeField] GameObject[] answerButton;
    [SerializeField] Color32 defaultColor = new Color32(12,183,190,255);
    [SerializeField] Sprite clickOnSprite;
    [SerializeField] Sprite defaultSprite;
    bool hasAnswerEarly = true;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = CountQuestion();
        progressBar.value = 0;
    }

    void Start()
    {
        
    }

    private void GetRandomQuestion()
    {
        int count = questions.Count;
        int index = Random.Range(0,count);
        currentQuestion = questions[index];
        count--;
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
        timerImage.fillAmount = timer.fillTimerImage;   
        if(timer.loadNextQuestion)
        {
            
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            GetNextQuestion();
            timer.loadNextQuestion = false;
            hasAnswerEarly = false;
        }
        else if(!hasAnswerEarly && !timer.isAnswering)
        {
            DisplayAnswer(-1);
            SetDontClick(-1);
            hasAnswerEarly = true;
        }
    }

    private void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            SetCanClick();
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI answerText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnSelectedButton(int index)
    {
        hasAnswerEarly = true;
        DisplayAnswer(index);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Debug.Log(index);
        if (index == currentQuestion.GetIndexCorrect())
        {
            questionText.text = "Correct";
            SetDontClick(index);
            scoreKeeper.IncreamentQuestionCorrect();
        }
        else
        {
            int correctIndex = currentQuestion.GetIndexCorrect();
            questionText.text = "You are wrong \n Correct Answer is: " + currentQuestion.GetAnswer(correctIndex);
            SetDontClick(index);
        }
    }

    void SetDontClick(int index)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            if(i == index)
                {
                    button.image.sprite = clickOnSprite;
                }
            button.interactable = false;
        }
    }
    void SetCanClick()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.image.sprite = defaultSprite;
            button.interactable = true;
        }
    }
    public int CountQuestion()
    {
        return questions.Count;
    }
}
