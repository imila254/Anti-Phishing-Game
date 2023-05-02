using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{

    private int buttonState; //0-neutral; 1-Phishing; 2-Legit;

    [SerializeField] private Sprite[] switchSprites;
    private Image switchImage;

    // Start is called before the first frame update
    void Start()
    {
        buttonState = 0;

        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprites[buttonState];

        gameObject.GetComponent<Button>().onClick.AddListener(SwitchButtonImage);
    }

    // Update is called once per frame
    private void SwitchButtonImage()
    {
        buttonState += 1;

        if (buttonState == 3) buttonState = 0;

        switchImage.sprite = switchSprites[buttonState];
    }

    public void Reset()
    {
        switchImage.sprite = switchSprites[0];
    }
}
