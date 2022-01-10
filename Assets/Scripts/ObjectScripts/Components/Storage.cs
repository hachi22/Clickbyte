using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Component
{
    public float baseMaxBitesCapacity;
    public float maxBitesCapacity;
    [SerializeField] private float multiplier;

    private void Awake()
    {
      //  PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        SetStats();
        SetDescription();

        int olvl = PlayerPrefs.GetInt("LVLStorage",1);

        if(olvl != 1)
        {
            for (int i = 1; i < olvl; i++)
            {
                LevelUP();
            }
        }
       

    }

    public void SaveLvl()
    {
        PlayerPrefs.SetInt("LVLStorage", lvl);
    }

    public void SetStats()
    {
        maxBitesCapacity = baseMaxBitesCapacity;
        cost = basecost;
        SetDescription();
    }

    public void LevelUP()
    {
        lvl++;
  

        cost = cost * (cost / 4);

        maxBitesCapacity += cost;
        


        SetDescription();
        SaveLvl();
    }

    public void SetDescription()
    {
        statsDescription = "Max bits capacity: " + maxBitesCapacity;
    }
}
