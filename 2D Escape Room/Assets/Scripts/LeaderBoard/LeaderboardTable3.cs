using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardTable3 : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {

        entryTemplate.gameObject.SetActive(false);

        //EntriesAddition entries = new EntriesAddition();
        //entries.AddHighscoreEntry("3table", 126,120,127);

        Debug.Log(PlayerPrefs.GetString("leaderboard"));
        string jsonStringRes = PlayerPrefs.GetString("leaderboard");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        Debug.Log(highscores.HighscoresEntries);
        Debug.Log(highscores.HighscoresEntries.Count);

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            Debug.Log(highscores.HighscoresEntries[i].name + "  " + highscores.HighscoresEntries[i].time1 + "  " + highscores.HighscoresEntries[i].time2 + "  " + highscores.HighscoresEntries[i].time3);
        }


        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            for (int j = i + 1; j < highscores.HighscoresEntries.Count; j++)
            {
                if (highscores.HighscoresEntries[j].time1 < highscores.HighscoresEntries[i].time1)
                {
                    HighscoreEntry tmp = highscores.HighscoresEntries[i];
                    highscores.HighscoresEntries[i] = highscores.HighscoresEntries[j];
                    highscores.HighscoresEntries[j] = tmp;
                }
            }
        }

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            for (int j = i + 1; j < highscores.HighscoresEntries.Count; j++)
            {
                if (highscores.HighscoresEntries[j].time2 < highscores.HighscoresEntries[i].time2)
                {
                    HighscoreEntry tmp = highscores.HighscoresEntries[i];
                    highscores.HighscoresEntries[i] = highscores.HighscoresEntries[j];
                    highscores.HighscoresEntries[j] = tmp;
                }
            }
        }

        for (int i = 0; i < highscores.HighscoresEntries.Count; i++)
        {
            for (int j = i + 1; j < highscores.HighscoresEntries.Count; j++)
            {
                if (highscores.HighscoresEntries[j].time3 < highscores.HighscoresEntries[i].time3)
                {
                    HighscoreEntry tmp = highscores.HighscoresEntries[i];
                    highscores.HighscoresEntries[i] = highscores.HighscoresEntries[j];
                    highscores.HighscoresEntries[j] = tmp;
                }
            }
        }

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

        //float score = highscoreEntry.time1;

        float minutes = Mathf.FloorToInt(highscoreEntry.time1 / 60);
        float seconds = Mathf.FloorToInt(highscoreEntry.time1 % 60);

        string textTime1 = $"{minutes:00}:{seconds:00}";
        entryTransform.Find("time").GetComponent<TextMeshPro>().text = textTime1;

        minutes = Mathf.FloorToInt(highscoreEntry.time2 / 60);
        seconds = Mathf.FloorToInt(highscoreEntry.time2 % 60);

        string textTime2 = $"{minutes:00}:{seconds:00}";
        entryTransform.Find("time2").GetComponent<TextMeshPro>().text = textTime2;

        minutes = Mathf.FloorToInt(highscoreEntry.time3 / 60);
        seconds = Mathf.FloorToInt(highscoreEntry.time3 % 60);

        string textTime3 = $"{minutes:00}:{seconds:00}";
        entryTransform.Find("time3").GetComponent<TextMeshPro>().text = textTime3;

        string name = highscoreEntry.name;
        entryTransform.Find("name").GetComponent<TextMeshPro>().text = name;

        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 0);

        transformList.Add(entryTransform);
    }
}
