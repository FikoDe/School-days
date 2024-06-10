using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    //melthod for Answers     
    public void Answer()
    {
        //checks if answer in quiz is right
        if (isCorrect)
        {
            quizManager.correct();
        }
        else
        {
            quizManager.wrong();
        }
    }
}
