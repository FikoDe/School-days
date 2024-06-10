using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QandA> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject wrapper;
    public Image currentImage;
    public Sprite NewImage;
    public GameObject panel;

    public GameObject certificate;

    public Animator animator;

    public DialogManager dialogManager;

    public GameObject dialogue;

    [SerializeField] TextMeshProUGUI QuestionText;

    private void Start()
    {
        generatQuestion();
    }

    private void Update()
    {
        //checks if player is dead
        if (GameObject.FindObjectOfType<Health>().getHealth() <= 0)
        {
            //if player is dead destroys all panels children 
            for (var i = panel.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(panel.transform.GetChild(i).gameObject);
            }
            //replace image
            currentImage.sprite = NewImage;
        }
    }

    //method for correct answer
    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generatQuestion();
    }

    //method for wron answer
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generatQuestion();
        GameObject.FindObjectOfType<Health>().GetDamaged(10);
    }



    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //sets is correct to false 
            options[i].GetComponent<Answers>().isCorrect = false;
            //sets dinamically answers to UI buttons
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];

            //condition which checks id answer user picked is same as correct answer
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    void generatQuestion()
    {
        //generates questions
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Qusetion;

            SetAnswers();
        }
        else
        {
            if (GameObject.FindObjectOfType<Health>().getHealth() <= 0)
            {
                currentImage.sprite = NewImage;
            }
            else
            {
                //if player is alive after quiz, starts another dialogue
                dialogue.SetActive(true);
                dialogManager.setIsUp(true);
                dialogManager.DisplayNextSentence();
                dialogManager.ContinueButton.SetActive(true);
                Destroy(dialogManager.QuizButton);
                Destroy(wrapper);
                certificate.SetActive(true); 
            }
        }
    }
}
