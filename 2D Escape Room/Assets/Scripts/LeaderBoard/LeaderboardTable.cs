using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LeaderboardTable : MonoBehaviour
{

    public Transform entryContainer;
    public Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {

        entryTemplate.gameObject.SetActive(false);

        //highscoreEntryList = new List<HighscoreEntry>()
        //{
        //    new HighscoreEntry { name = "player1", time1 = 10, time2 = -1, time3 = -1 },
        //    new HighscoreEntry { name = "player2", time1 = 9, time2 = -1, time3 = -1 },
        //    new HighscoreEntry { name = "player3", time1 = 8, time2 = -1, time3 = -1 },
        //    new HighscoreEntry { name = "player4", time1 = 1, time2 = -1, time3 = -1 }
        //};


       // AddHighscoreEntry("playerALL", 10,10,10);

        //AddNewNameToHighscoreTable("name");
        //AddFirstLevelTime(100);
        //AddLevelTime(11,1);
        //AddLevelTime(22,2);
        //AddLevelTime(33,3);

        //EntriesAddition entries = new EntriesAddition();
        //entries.AddHighscoreEntry("11th", 120,120,120);

        Debug.Log(PlayerPrefs.GetString("leaderboard"));
        string jsonStringRes = PlayerPrefs.GetString("leaderboard");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        Debug.Log(highscores.HighscoresEntries);
        Debug.Log(highscores.HighscoresEntries.Count);

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            Debug.Log(highscores.HighscoresEntries[i].name + "  " + highscores.HighscoresEntries[i].time1 + "  " + highscores.HighscoresEntries[i].time2 + "  " + highscores.HighscoresEntries[i].time3);
        }

        //for (int i = 0; i < highscoreEntryList.Count; i++)
        //{
        //    for (int j = i + 1; j < highscoreEntryList.Count; j++)
        //    {
        //        if (highscoreEntryList[j].time1 > highscoreEntryList[i].time1)
        //        {
        //            HighscoreEntry tmp = highscoreEntryList[i];
        //            highscoreEntryList[i] = highscoreEntryList[j];
        //            highscoreEntryList[j] = tmp;
        //        }
        //    }
        //}

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            for (int j = i + 1; j < highscores.HighscoresEntries.Count; j++)
            {
                if (highscores.HighscoresEntries[j].time1 > highscores.HighscoresEntries[i].time1)
                {
                    HighscoreEntry tmp = highscores.HighscoresEntries[i];
                    highscores.HighscoresEntries[i] = highscores.HighscoresEntries[j];
                    highscores.HighscoresEntries[j] = tmp;
                }
            }
        }
        //highscoreEntryTransformList = new List<Transform>();
        //foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        //{
        //    CreateLeaderboardEntryTransform(highscoreEntry, entryContainer,highscoreEntryTransformList);
        //}

        highscoreEntryTransformList = new List<Transform>();

        int top = 0;
        foreach (var highscoreEntry in highscores.HighscoresEntries)
        {
            //Debug.Log(top);
            if (top < 10)
            {
                CreateLeaderboardEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                top++;
            }
            else break;

        }
        



        /*
        Highscores highscores = new Highscores{ HighscoresEntries = highscoreEntryList};
        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("leaderboardTable"));
        */
    }

    private void CreateLeaderboardEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {

        float templateHeight = 65f; 
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }

        entryTransform.Find("position").GetComponent<TextMeshPro>().text = rankString;

        float score = highscoreEntry.time1;

        float minutes = Mathf.FloorToInt(score / 60);

        float seconds = Mathf.FloorToInt(score % 60);

        string textTime = $"{minutes:00}:{seconds:00}";
        entryTransform.Find("time").GetComponent<TextMeshPro>().text = textTime;

        string name = highscoreEntry.name;
        entryTransform.Find("name").GetComponent<TextMeshPro>().text = name;

        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 0);

        transformList.Add(entryTransform);
    }


    //private class Highscores
    //{
    //    public List<HighscoreEntry> HighscoresEntries;
    //}

    //[System.Serializable]
    //private class HighscoreEntry
    //{
    //    public string name;
    //    public float time1;
    //    public float time2;
    //    public float time3;
    //}
    // Start is called before the first frame update

    /*
    private void AddHighscoreEntry(string name, float time1, float time2, float time3)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{name = name, time1 = time1, time2 = time2, time3 = time3};

        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        highscores.HighscoresEntries.Add(highscoreEntry);

        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
    }

    private void AddNewNameToHighscoreTable(string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{name = name};

        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        highscores.HighscoresEntries.Add(highscoreEntry);

        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
    }

    private void AddLevelTime(float time, int level)
    {
        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);
        int lastIndex = highscores.HighscoresEntries.Count - 1;

        switch (level)
        {
            case 1:
                highscores.HighscoresEntries[lastIndex].time1 = time;
                break;
            case 2:
                highscores.HighscoresEntries[lastIndex].time2 = time;
                break;
            case 3:
                highscores.HighscoresEntries[lastIndex].time3 = time;
                break;
        }
        
        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
    }
    */

}
