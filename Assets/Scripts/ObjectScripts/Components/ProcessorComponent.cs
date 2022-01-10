using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessorComponent : Component
{


    public float baseBitesPerClick;
    public float bitesPerClick;

    [SerializeField] private float baseEnergyPerClick;
    public float energyPerClick;

    [SerializeField] private float bitesMultiplier;
    [SerializeField] private float energyMultiplier;

    private void Start()
    {

        SetStats();
        SetDescription();

        
        int olvl = PlayerPrefs.GetInt("LVLProcessor", 1);

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
        PlayerPrefs.SetInt("LVLProcessor", lvl);
    }

    public void SetStats()
    {
        bitesPerClick = baseBitesPerClick;
        energyPerClick = baseEnergyPerClick;
        cost = basecost;
        SetDescription();
        energyMultiplier = 1;
        bitesMultiplier = 1;
    }

    public void LevelUP()
    {
        lvl++;

        if (lvl % 5 == 0)
        {
            energyMultiplier *=1.1f;
            bitesMultiplier *=10;
        }
        else
        {
            bitesMultiplier *= 3f;
            energyMultiplier *= 1.5f;
        }


        cost = cost * (cost / 2);

        bitesPerClick += bitesMultiplier;
        energyPerClick += energyMultiplier;

        SaveLvl();

        SetDescription();
    }

    public void SetDescription()
    {
        statsDescription = "bits per click: " + bitesPerClick + "\n" +
              "cost for click: " + energyPerClick;
    }
}
