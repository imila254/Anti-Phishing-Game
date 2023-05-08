using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeOnClickLevel : MonoBehaviour
{
    public string SceneToBeLoaded;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           SceneManager.LoadScene(SceneToBeLoaded);
        }
    }
}
