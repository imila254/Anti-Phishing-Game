using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnAndOff : MonoBehaviour
{
    private int buttonState; // 0 - Off; 1 - On

    [SerializeField] private Sprite[] switchSprites;

    private Image switchImage;

    // Start is called before the first frame update
    void Start()
    {
        buttonState = 0;

        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprites[buttonState];

        gameObject.GetComponent<Button>().onClick.AddListener(TurnButtonOnAndOff);
    }

    // Update is called once per frame
    private void TurnButtonOnAndOff()
    {
        buttonState = 1 - buttonState;
        switchImage.sprite = switchSprites[buttonState];
    }
}
