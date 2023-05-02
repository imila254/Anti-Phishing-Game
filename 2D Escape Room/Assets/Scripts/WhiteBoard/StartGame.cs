using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject NextScreen;
    public GameObject CurrentScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartPressed);
    }


    private void StartPressed()
    {
        CurrentScreen.gameObject.SetActive(false);
        NextScreen.gameObject.SetActive(true);

    }
}
