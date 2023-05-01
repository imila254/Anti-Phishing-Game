using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject RGPanel;
    public GameObject GOPanel;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;
    public int passingScore;

    int totalQuestions = 0;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        totalQuestions = QnA.Count;
        RGPanel.SetActive(false);
        GOPanel.SetActive(false);
        generateQuestion();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        if (score >= passingScore)
        {
            GOPanel.SetActive(true);
        }
        else
        {
            RGPanel.SetActive(true);
            ScoreText.text = score + "/" + totalQuestions;
        }
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        Console.WriteLine(options.Length);
        for (int i  = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswers == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Questions;

            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();

        }
       
        
    }
}
