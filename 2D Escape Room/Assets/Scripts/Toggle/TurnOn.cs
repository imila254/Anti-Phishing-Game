using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOn : MonoBehaviour
{

    [SerializeField] private Sprite[] switchSprites;

    private Image switchImage;
    public GameObject FishTank;
    public GameObject Tank;
    // Start is called before the first frame update
    void Start()
    {
        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprites[0];

        gameObject.GetComponent<Button>().onClick.AddListener(TurnButtonOn);
    }

    // Update is called once per frame
    private void TurnButtonOn()
    {
        //buttonState = 1 - buttonState;
        switchImage.sprite = switchSprites[1];
        FishTank.gameObject.SetActive(false);
        Tank.gameObject.SetActive(true);
    }
}
