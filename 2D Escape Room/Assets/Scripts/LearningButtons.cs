using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningButtons : MonoBehaviour
{
    public GameObject NextPanel;
    public GameObject PrevtPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        PrevtPanel.SetActive(false);
        NextPanel.SetActive(true);
    }
}
