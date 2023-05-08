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
            new HighscoreEntry { name = "Mantas", time1 = 540 , time2 = 598, time3 = 470 },
            new HighscoreEntry { name = "Matas", time1 = 549, time2 = 538, time3 = 485 },
            new HighscoreEntry { name = "Saule", time1 = 522, time2 = 517, time3 = 590 },
            new HighscoreEntry { name = "Ieva", time1 = 400, time2 = 527, time3 = 580 }
        };


        Highscores highscores = new Highscores { HighscoresEntries = highscoreEntryList };
        string jsonString = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("leaderboard", jsonString);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("leaderboard"));


    }



}
