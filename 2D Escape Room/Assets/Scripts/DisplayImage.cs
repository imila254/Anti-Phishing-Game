using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{

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
        if (currentWall != previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/R1-wall" + currentWall.ToString());
            
        }

        previousWall = currentWall;
    }
}