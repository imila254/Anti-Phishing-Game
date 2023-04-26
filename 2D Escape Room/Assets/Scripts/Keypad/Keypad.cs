using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    private GameObject displayImage;
    // Start is called before the first frame update
    void Start()
    {
        displayImage = GameObject.Find("displayImage");
    }

    // Update is called once per frame
    void Update()
    {
        HideDisplay();
    }

    public void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.Normal)
        {
            this.gameObject.SetActive(false);
        }
    }
}
