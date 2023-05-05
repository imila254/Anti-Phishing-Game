using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject GOPanel;
    public Spawner spawner;
    public GameObject Game;
    public GameObject destroy;


    public int score;
    public int passScore;
    
    // Start is called before the first frame update
    void Start()
    {
        GOPanel.SetActive(false);
        destroy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        destroy.SetActive(true);
        spawner.GameOver();
        GOPanel.SetActive(true);
        //Game.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "wrong")
        {
            Destroy(target.gameObject);
            score--;
        }
        
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "right")
        {
            Destroy(target.gameObject);
            score ++;
        }
        if(score >= passScore)
        {
            GameOver();


        }
    }

    IEnumerable WaitRestart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
