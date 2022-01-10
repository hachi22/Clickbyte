using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : Component
{
    public float baseBitesPerSecond;
    public float bitesForSeocnd;
    [SerializeField] private float bitesPerSecondMultiplier;


    private void Start()
    {

        SetStats();
        SetDescription();


        int olvl = PlayerPrefs.GetInt("LVLGraphic", 1);
        if (olvl != 1)
        {
            for (int i = 1; i < olvl; i++)
        {
            LevelUP();
        }
        }

    }

    public void SaveLvl()
    {
        PlayerPrefs.SetInt("LVLGraphic", lvl);
    }

    public void SetStats()
    {
        bitesForSeocnd = baseBitesPerSecond;
        cost = basecost;
        SetDescription();
        bitesPerSecondMultiplier = 1;
    }

    public void LevelUP()
    {
        lvl++;


        if (lvl % 5 == 0)
        {
            bitesPerSecondMultiplier *= 6;
        }
        else
        {
            bitesPerSecondMultiplier *= 2f;
        }


        cost = cost * (cost / 2);

        bitesForSeocnd += bitesPerSecondMultiplier;
        

        SetDescription();
        SaveLvl();
    }



    public void SetDescription()
    {
        statsDescription = "Bits Per Second: " + bitesForSeocnd;
    }
}
