using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    void Update()
    {
        ManageObjects();
    }

    void ManageObjects()
    {
        for (var i = 0; i < objectsToManage.Length; i++)
        {
            if (objectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectsToManage[i].SetActive(true);
            }

            else
            {
                objectsToManage[i].SetActive(false);
            }
        }
    }
}
