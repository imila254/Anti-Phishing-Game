using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public string SceneToBeLoaded;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void OnButtonClicked()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneToBeLoaded);
        CreateFile.AddValues();
    }
}
