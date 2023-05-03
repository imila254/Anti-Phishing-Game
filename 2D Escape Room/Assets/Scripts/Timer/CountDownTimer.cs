using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountDownTimer : MonoBehaviour
{
    public float countdown;

    public TMP_Text TimerDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

       

        float minutes = Mathf.FloorToInt(countdown / 60);

        float seconds = Mathf.FloorToInt(countdown % 60);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);


        if (countdown < 15)
        {
            TimerDisplayText.color = Color.red;
        }
        TimerDisplayText.text = textTime;

    }
}
