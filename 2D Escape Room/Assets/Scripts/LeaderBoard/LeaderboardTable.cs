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


        //AddHighscoreEntry("new player", 10,10,10);
        Debug.Log(PlayerPrefs.GetString("leaderboardTable"));
        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        Debug.Log(highscores.HighscoresEntries);
        Debug.Log(highscores.HighscoresEntries.Count);

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            Debug.Log(highscores.HighscoresEntries[i].name + "  " + highscores.HighscoresEntries[i].time1);
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
        foreach (var highscoreEntry in highscores.HighscoresEntries)
        {
            CreateLeaderboardEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
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
        entryTransform.Find("time").GetComponent<TextMeshPro>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("name").GetComponent<TextMeshPro>().text = name;

        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 0);

        transformList.Add(entryTransform);
    }


    private class Highscores
    {
        public List<HighscoreEntry> HighscoresEntries;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public float time1;
        public float time2;
        public float time3;
    }
    // Start is called before the first frame update

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
}
