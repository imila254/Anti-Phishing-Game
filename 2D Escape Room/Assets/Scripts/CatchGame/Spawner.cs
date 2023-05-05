using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{      
    public GameObject[] urls;
    public GameObject[] wrong;

    public float xBounds;
    public float yBound;


    // Start is called before the first frame update
    void Start()
    {      
        StartCoroutine(SpawnRandomGameObject());   
    }

    public void GameOver()
    {
        StopCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(3);

        int randomURL = Random.Range(0, urls.Length);
        int randomWrong = Random.Range(0, wrong.Length);

        if (Random.value <= .6f)
            Instantiate(urls[randomURL],
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        else
            Instantiate(wrong[randomWrong],
                 new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);

        StartCoroutine(SpawnRandomGameObject());               
    }
}