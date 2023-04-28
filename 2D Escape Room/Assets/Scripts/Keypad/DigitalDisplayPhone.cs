using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DigitalDisplayPhone : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;

    [SerializeField] private Image[] characters;

    public TextMeshProUGUI ResultText;

    private string codeSequence;

    public string PhoneNumber = "864623363";

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
        if (codeSequence.Length < 9)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }

        switch (digitEntered)
        {
            case "Star":
                ResetDisplay();
                break;

            case "Call":
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
                characters[3].sprite = digits[10];
                characters[4].sprite = digits[10];
                characters[5].sprite = digits[10];
                characters[6].sprite = digits[10];
                characters[7].sprite = digits[10];
                characters[8].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[10];
                characters[4].sprite = digits[10];
                characters[5].sprite = digits[10];
                characters[6].sprite = digits[10];
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[10];
                characters[4].sprite = digits[10];
                characters[5].sprite = digits[10];
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[10];
                characters[4].sprite = digits[10];
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;

            case 5:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[10];
                characters[4].sprite = characters[5].sprite;
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;

            case 6:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = characters[4].sprite;
                characters[4].sprite = characters[5].sprite;
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;

            case 7:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = characters[4].sprite;
                characters[4].sprite = characters[5].sprite;
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;

            case 8:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = characters[4].sprite;
                characters[4].sprite = characters[5].sprite;
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;

            case 9:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = characters[4].sprite;
                characters[4].sprite = characters[5].sprite;
                characters[5].sprite = characters[6].sprite;
                characters[6].sprite = characters[7].sprite;
                characters[7].sprite = characters[8].sprite;
                characters[8].sprite = digits[digitJustEntered];
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == PhoneNumber)
        {
            Debug.Log("Calling...");
            StartCoroutine(ShowMessage("Calling...", 1, true));
            //SceneManager.LoadScene(SceneToBeLoaded);

        }
        else
        {
            Debug.Log("Ops! This number does not exist...");
            StartCoroutine(ShowMessage("Ops! This number does not exist...!", 2, false));
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
        ResultText.color = isCorrect ? Color.green : Color.black;
        ResultText.enabled = true;
        yield return new WaitForSeconds(delay);
        ResultText.enabled = false;
    }
}
