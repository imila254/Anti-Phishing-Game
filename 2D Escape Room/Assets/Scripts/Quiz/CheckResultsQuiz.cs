using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class CheckResultsQuiz : MonoBehaviour
{

    [SerializeField] private Image[] buttons;

    public GameObject PanelCorrect;
    public GameObject PanelWrong;
    public GameObject PanelResult;
    public GameObject DisplayNewObject;

    public int[] CorrectButtonIndexes;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnCheckButtonClick);
       
    }


    private void OnCheckButtonClick()
    {
        StartCoroutine(CheckIfButtonsComboCorrect() ? Waiter(true) : Waiter(false));
    }

    private bool CheckIfButtonsComboCorrect()
    {

        var isCorrect = false;

        switch (CorrectButtonIndexes.Length)
        {
            case 3:
                if (buttons[0].sprite.name.Contains("Off")
               && buttons[1].sprite.name.Contains("Off")
               && buttons[2].sprite.name.Contains("Off")
               && buttons[3].sprite.name.Contains("Off")
               && buttons[4].sprite.name.Contains("Off")
               && buttons[5].sprite.name.Contains("On")
               && buttons[6].sprite.name.Contains("On")
               && buttons[7].sprite.name.Contains("Off")
               && buttons[8].sprite.name.Contains("On")
                ) isCorrect = true;
                break;
            case 5:
                if (buttons[0].sprite.name.Contains("On")
                    && buttons[1].sprite.name.Contains("On")
                    && buttons[2].sprite.name.Contains("On")
                    && buttons[3].sprite.name.Contains("Off")
                    && buttons[4].sprite.name.Contains("Off")
                    && buttons[5].sprite.name.Contains("Off")
                    && buttons[6].sprite.name.Contains("Off")
                    && buttons[7].sprite.name.Contains("On")
                    && buttons[8].sprite.name.Contains("On")
                   ) isCorrect = true;
                break;
            case 7:
                if (buttons[0].sprite.name.Contains("On")
                    && buttons[1].sprite.name.Contains("On")
                    && buttons[2].sprite.name.Contains("On")
                    && buttons[3].sprite.name.Contains("Off")
                    && buttons[4].sprite.name.Contains("On")
                    && buttons[5].sprite.name.Contains("Off")
                    && buttons[6].sprite.name.Contains("Off")
                    && buttons[7].sprite.name.Contains("Off")
                    && buttons[8].sprite.name.Contains("Off")
                    && buttons[9].sprite.name.Contains("On")
                    && buttons[10].sprite.name.Contains("On")
                    && buttons[11].sprite.name.Contains("On")
                   ) isCorrect = true;
                break;
        }

        return isCorrect;
    }

    IEnumerator Waiter(bool isCorrect)
    {
        if (isCorrect)
        {
            PanelCorrect.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            PanelResult.gameObject.SetActive(true);
            DisplayNewObject.SetActive(true);
        }
        else
        {
            PanelWrong.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            PanelWrong.gameObject.SetActive(false);
        }
    }
}
