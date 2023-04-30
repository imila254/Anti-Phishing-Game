using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class CheckResults : MonoBehaviour
{

    [SerializeField] private Image[] buttons;

    public GameObject PanelCorrect;
    public GameObject PanelWrong;
    public GameObject PanelResult;

    public int[] CorrectButtonIndexes;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnCheckButtonClick);
       
    }


    private void OnCheckButtonClick()
    {


        if (CorrectButtonIndexes.Length == CheckCorrectButtons())
        {
            Debug.Log("Correct!");
            StartCoroutine(Waiter(true));

        }
        else
        {
            Debug.Log("Wrong!");
            StartCoroutine(Waiter(false));
        }
    }

    private int CheckCorrectButtons()
    {
        return CorrectButtonIndexes.Count(t => buttons[t].sprite.name.Contains("On"));
    }

    IEnumerator Waiter(bool isCorrect)
    {
        if (isCorrect)
        {
            PanelCorrect.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            PanelResult.gameObject.SetActive(true);
        }
        else
        {
            PanelWrong.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            PanelWrong.gameObject.SetActive(false);
        }
        //gameObject.SetActive(true);
        //yield return new WaitForSeconds(2);
        //gameObject.SetActive(false);
    }
}
