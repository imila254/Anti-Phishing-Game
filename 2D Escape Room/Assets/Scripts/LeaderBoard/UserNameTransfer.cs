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

        //Debug.Log("." + username + ".");
        //Debug.Log(IsNameValid(username));
        
        //if (username == " " || username==null) Debug.Log("blogas");
        //Debug.Log("Clicked");
        //if (username.Length <= 1)
        //{
        //    Debug.Log("not valid");
        //    textDisplay.gameObject.SetActive(true);
        //    textDisplay.GetComponent<TMP_Text>().text = "Username is not valid";
        //}

        //else
        //{
        //    textDisplay.gameObject.SetActive(false);
        //    EntriesAddition entries = new EntriesAddition();
        //    entries.AddNewNameToHighscoreTable(username);
        //    entries.AddHighscoreEntry(username, 240,240,240);
        //    SceneManager.LoadScene(SceneToBeLoaded);
        //}

        textDisplay.gameObject.SetActive(false);

        EntriesAddition.AddNewNameToHighscoreTable(username);
        SceneManager.LoadScene(SceneToBeLoaded);

    }

    private bool IsNameValid(string input)
    {
        //return Regex.IsMatch(input, @"^(?!\s*$).+");
        return Regex.IsMatch(input, @"/^$|\s+/");


    }
}
