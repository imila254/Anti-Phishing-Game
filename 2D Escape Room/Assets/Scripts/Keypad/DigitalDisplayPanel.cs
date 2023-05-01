using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DigitalDisplayPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;

    [SerializeField] private Image[] characters;

    public TextMeshProUGUI ResultText;

    public GameObject PanelOpen;

    private string codeSequence;

    public string Password = "d15a";

    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";

        foreach (var character in characters)
        {
            character.sprite = digits[10];
        }

        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "4":
                    codeSequence += "4";
                    DisplayCodeSequence(0);
                    break;
                case "w":
                    codeSequence += "w";
                    DisplayCodeSequence(1);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(2);
                    break;
                case "c":
                    codeSequence += "c";
                    DisplayCodeSequence(3);
                    break;
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(4);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "d":
                    codeSequence += "d";
                    DisplayCodeSequence(6);
                    break;
                case "a":
                    codeSequence += "a";
                    DisplayCodeSequence(7);
                    break;
                case "b":
                    codeSequence += "b";
                    DisplayCodeSequence(8);
                    break;
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(9);
                    break;
            }
        }

        switch (digitEntered)
        {
            case "Star":
                ResetDisplay();
                break;

            case "Hash":
                if (codeSequence.Length > 0)
                {
                    CheckResults();
                }
                break;
        }
    }

    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == Password)
        {
            Debug.Log("Correct!");
            StartCoroutine(ShowMessage("Correct!", 2, true));
            //SceneManager.LoadScene(SceneToBeLoaded);

        }
        else
        {
            Debug.Log("Wrong!");
            StartCoroutine(ShowMessage("Wrong!", 2, false));
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        foreach (var character in characters)
        {
            character.sprite = digits[10];
        }

        codeSequence = "";
    }

    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }

    IEnumerator ShowMessage(string message, float delay, bool isCorrect)
    {
        ResultText.text = message;
        ResultText.color = isCorrect ? Color.green : Color.red;
        ResultText.enabled = true;
        yield return new WaitForSeconds(delay);
        ResultText.enabled = false;
        if (isCorrect) PanelOpen.gameObject.SetActive(true);
    }

}
