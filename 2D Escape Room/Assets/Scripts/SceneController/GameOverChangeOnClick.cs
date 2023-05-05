using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverChangeOnClick : MonoBehaviour
{
    public string SceneToBeLoaded;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EntriesAddition.AddLevelTime(360 - Timer.ResultTime, 3);
            SceneManager.LoadScene(SceneToBeLoaded);
        }
    }
}
