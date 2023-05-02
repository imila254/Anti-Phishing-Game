using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWhiteboard : MonoBehaviour
{

    [SerializeField] private Image[] buttons;

    public GameObject PanelCorrect;
    public GameObject PanelWrong;
    public GameObject PanelResult;
    public GameObject PanelCurrent;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnCheckButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCheckButtonClick()
    {
        Debug.Log("Clicked");
        if(CheckIfButtonsComboCorrect()) Debug.Log("Correct");
        else
        {
            Debug.Log("Wrong");
        }
        
        
        StartCoroutine(CheckIfButtonsComboCorrect() ? Waiter(true) : Waiter(false));
    }

    private bool CheckIfButtonsComboCorrect()
    {
        bool isCorrect = buttons[0].sprite.name.Contains("Legit")
                         && buttons[1].sprite.name.Contains("Phishing")
                         && buttons[2].sprite.name.Contains("Phishing")
                         && buttons[3].sprite.name.Contains("Phishing")
                         && buttons[4].sprite.name.Contains("Legit")
                         && buttons[5].sprite.name.Contains("Phishing")
                         && buttons[6].sprite.name.Contains("Legit")
                         && buttons[7].sprite.name.Contains("Phishing")
                         && buttons[8].sprite.name.Contains("Phishing")
                         && buttons[9].sprite.name.Contains("Legit");

        return isCorrect;

    }


    IEnumerator Waiter(bool isCorrect)
    {
        if (isCorrect)
        {
            //Debug.Log("Correct");
            PanelCorrect.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            PanelResult.gameObject.SetActive(true);
            PanelCurrent.gameObject.SetActive(false);
            PanelCorrect.gameObject.SetActive(false);

        }
        else
        {
            //Debug.Log("Wrong");
            PanelWrong.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            PanelWrong.gameObject.SetActive(false);
        }
    }
}
