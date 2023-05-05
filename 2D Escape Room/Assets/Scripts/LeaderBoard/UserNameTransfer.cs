using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UserNameTransfer : MonoBehaviour
{
    public string username;
    public GameObject inputField;
    public GameObject textDisplay;
    public string SceneToBeLoaded;

    void Start()
    {
        textDisplay.gameObject.SetActive(false);
        gameObject.GetComponent<Button>().onClick.AddListener(GetInput);
    }

    public void GetInput()
    {
        username = inputField.GetComponent<TextMeshProUGUI>().text;

        textDisplay.gameObject.SetActive(false);

        EntriesAddition.AddNewNameToHighscoreTable(username);
        SceneManager.LoadScene(SceneToBeLoaded);

    }

}
