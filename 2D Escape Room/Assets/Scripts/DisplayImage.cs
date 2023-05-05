using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayImage : MonoBehaviour
{

    public enum State
    {
        Normal,
        Zoom,
        ChangedView
    };

    public State CurrentState { get; set; }


    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 5)
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else
                currentWall = value;
        }
    }

    private int currentWall;
    private int previousWall;


    // Start is called before the first frame update
    void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    // Update is called once per frame
    void Update()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Room_1":

                if (currentWall != previousWall)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R1-wall" + currentWall.ToString());

                }

                previousWall = currentWall;
                break;

            case "Room_2":

                if (currentWall != previousWall)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R2-wall" + currentWall.ToString());

                }

                previousWall = currentWall;
                break;

            case "Room_3":
                if (currentWall != previousWall)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R3-wall" + currentWall.ToString());

                }

                previousWall = currentWall;
                break;

            case "Learning":
                if (currentWall != previousWall)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Learnings/" + currentWall.ToString());

                }

                previousWall = currentWall;
                break;
        }


        //if (SceneManager.GetActiveScene().name == "Room_1")
        //{
        //    if (currentWall != previousWall)
        //    {
        //        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R1-wall" + currentWall.ToString());

        //    }

        //    previousWall = currentWall;
        //}

        //if (SceneManager.GetActiveScene().name == "Room_2")
        //{
        //    if (currentWall != previousWall)
        //    {
        //        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R2-wall" + currentWall.ToString());

        //    }

        //    previousWall = currentWall;
        //}

        //if (SceneManager.GetActiveScene().name == "Room_3")
        //{
        //    if (currentWall != previousWall)
        //    {
        //        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R3-wall" + currentWall.ToString());

        //    }

        //    previousWall = currentWall;
        //}

        //if (currentWall != previousWall)
        //{
        //    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R1-wall" + currentWall.ToString());
            
        //}

        //previousWall = currentWall;
    }
}