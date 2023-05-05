using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class HighscoreEntry
{
    public string name;
    public float time1;
    public float time2;
    public float time3;


    public HighscoreEntry(string name, float time1, float time2, float time3) 
    {
        this.name = name;
        this.time1 = time1;
        this.time2 = time2;
        this.time3 = time3;
    }

    public HighscoreEntry() : this("N/A", 360, 360, 360) {}

    public HighscoreEntry(string name)
    {
        this.name = name;
    }

}

