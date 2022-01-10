using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceEnergy : Component
{

    public float baseSaveEnergy;
    public float saveEnergy;
    [SerializeField] private float increment;

    public float maxEnergy;

    [SerializeField] EnergyBar energyBar;

    private void Start()
    {

        SetStats();
        SetDescription();
        energyBar.SetRealEnergyCost();

        int olvl = PlayerPrefs.GetInt("LVLEnergy", 1);

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
        PlayerPrefs.SetInt("LVLEnergy", lvl);
    }

    public void SetStats()
    {
        saveEnergy = baseSaveEnergy;
        cost = basecost;
        SetDescription();
        increment = 1;
    }

    public void LevelUP()
    {
        lvl++;

        if (lvl % 5 == 0)
        {
            print(lvl % 5);
            increment *= 10;
        }


        saveEnergy += increment*3;
        energyBar.SetRealEnergyCost();

        cost = cost * (cost / 2);

        SetDescription();
        SaveLvl();
    }

    public void SetDescription()
    {
        statsDescription = "Less energy consumption per tap: " + saveEnergy;
    }
}
