using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage;

    public GameObject[] UIRenderObjects;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        if (UIRenderObjects != null) RenderUI();
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

    void RenderUI()
    {
        for (var i = 0; i < UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }
}
