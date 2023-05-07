using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    public TextMeshProUGUI textDisplay1;
    public TextMeshProUGUI textDisplay2;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay1.text = EntriesAddition.GetName();
        textDisplay2.text = EntriesAddition.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
