using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript2 : MonoBehaviour
{
    public bool isCorrect = false;

    public QuizManager2 quizManager2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager2.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager2.wrong();
        }
    }
}
