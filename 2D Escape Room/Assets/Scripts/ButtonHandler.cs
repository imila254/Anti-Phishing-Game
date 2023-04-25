using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    private DisplayImage currentDisplay;

    private float initialCameraSize;
    
    private Vector3 initialCameraPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {

        if (currentDisplay.CurrentState == DisplayImage.State.Zoom)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.Normal;
            var zoomInObjects = FindObjectsOfType<ZoomInObject>();

            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Room_1":
                    currentDisplay.GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/R1-wall" + currentDisplay.CurrentWall);

                    break;

                case "Room_2":
                    currentDisplay.GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/R2-wall" + currentDisplay.CurrentWall);

                    break;

                case "Room_3":
                    currentDisplay.GetComponent<SpriteRenderer>().sprite =
                        Resources.Load<Sprite>("Sprites/R3-wall" + currentDisplay.CurrentWall);

                    break;
            }
            {
                
            }
            //currentDisplay.GetComponent<SpriteRenderer>().sprite =
            //    Resources.Load<Sprite>("Sprites/R1-wall" + currentDisplay.CurrentWall);

            currentDisplay.CurrentState = DisplayImage.State.Normal;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
