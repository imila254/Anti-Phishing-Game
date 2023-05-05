using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFile : MonoBehaviour
{
    public static List<HighscoreEntry> highscoreEntryList;


    public static void AddValues()
    {

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry { name = "Mantas", time1 = 360 , time2 = 390 , time3 = 310 },
            new HighscoreEntry { name = "Matas", time1 = 380, time2 = 370, time3 = 320 },
            new HighscoreEntry { name = "Saule", time1 = 390, time2 = 410, time3 = 270 },
            new HighscoreEntry { name = "Ieva", time1 = 410, time2 = 450, time3 = 320 }
        };


        Highscores highscores = new Highscores { HighscoresEntries = highscoreEntryList };
        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboard", jsonString);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("leaderboard"));


    }



}
