using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question",menuName ="Create Question")]
public class QuestionSO : ScriptableObject
{
   [TextArea(2,5)]
   [SerializeField] string question = "Enter your question";
   [SerializeField] string[] answer = new string[4];
   public int indexCorrect;
   public string GetQuestion()
   {
        return question;
   }
   public int GetIndexCorrect()
   {
        return indexCorrect;
   }
   public string GetAnswer(int index)
   {
        return answer[index];
   }
}
