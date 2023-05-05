using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;


public class EntriesAddition : MonoBehaviour
{
    public static void AddHighscoreEntry(string name, float time1, float time2, float time3)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = name, time1 = time1, time2 = time2, time3 = time3 };

        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        highscores.HighscoresEntries.Add(highscoreEntry);

        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
    }

    public static void AddNewNameToHighscoreTable(string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = name };

        string jsonStringRes = PlayerPrefs.GetString("leaderboardTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonStringRes);

        highscores.HighscoresEntries.Add(highscoreEntry);

        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboardTable", jsonString);
        PlayerPrefs.Save();
    }

    public static void AddLevelTime(float time, int level)
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
}

