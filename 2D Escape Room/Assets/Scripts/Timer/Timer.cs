using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject GameOverPanel;

    [SerializeField] TMP_Text timeText;

    [SerializeField] public float duration, currentTime;

    [SerializeField] public string SceneToBeLoaded;

    public static float ResultTime;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        currentTime = duration;

        float minutes = Mathf.FloorToInt(currentTime / 60);

        float seconds = Mathf.FloorToInt(currentTime % 60);

        string textTime = $"{minutes:00}:{seconds:00}";
        timeText.text = textTime;

        StartCoroutine(TimeIEn());

    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            float minutes = Mathf.FloorToInt(currentTime / 60);

            float seconds = Mathf.FloorToInt(currentTime % 60);

            string textTime = $"{minutes:00}:{seconds:00}";

            if (currentTime < 15)
            {
                timeText.color = Color.red;
            }

            timeText.text = textTime;

            yield return new WaitForSeconds(1f);
            currentTime--;
            ResultTime = currentTime;
        }
        OpenPanel();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneToBeLoaded);
    }


    void OpenPanel()
    {
        timeText.text = "";
        GameOverPanel.SetActive(true);
        
    }
}
