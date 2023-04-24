using System;
using System.Collections.Generic;
using UnityEngine;


public class ZoomInObject : MonoBehaviour, IInteractable
{

    public float ZoomRatio = .5f;

    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            this.transform.position.z);
    }
}
