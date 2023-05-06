using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeOnClick : MonoBehaviour
{
    public string SceneToBeLoaded;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateFile.AddValues();
            SceneManager.LoadScene(SceneToBeLoaded);
        }
    }

    public void ChangeViewOnButtonClicked()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneToBeLoaded);
    }
}
