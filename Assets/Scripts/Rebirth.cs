using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rebirth : MonoBehaviour
{
    [SerializeField] NumberController bits;
    [SerializeField] Graphic lvlGraphic;
    [SerializeField] ProcessorComponent lvlProcessor;
    [SerializeField] Storage lvlStorage;
    [SerializeField] SourceEnergy lvlEnergy;
    [SerializeField] EnergyBar energyBar;
    public int numRebirths;
    [SerializeField] TextMeshProUGUI textRebirth;
    [SerializeField] TextMeshProUGUI textMoneyRebirth;
    private string normalRebirth = "0% enhanced components";
    int rebirthMoneyText;
    string firstTextMoney = "You will lose all your bits and your components stats will be 0, but you will gain ";
    string secondTextMoney = " coins that you can exchange for a ticket of the pasive gacha";

    private void Start()
    {
        numRebirths = PlayerPrefs.GetInt("numRebirth", 0); 
    }

    private void Update()
    {
        textMoneyRebirth.text = firstTextMoney + rebirthMoneyText + secondTextMoney;
    }

    public void addStatsRebirth()
    {
        numRebirths++;
        PlayerPrefs.SetInt("numRebirths", numRebirths);
        textRebirth.text = numRebirths * 7 + normalRebirth;
        lvlGraphic.baseBitesPerSecond += lvlGraphic.baseBitesPerSecond * (numRebirths * 0.7f);
        lvlGraphic.bitesForSeocnd += lvlGraphic.bitesForSeocnd * (numRebirths * 0.7f);
        lvlEnergy.baseSaveEnergy += lvlEnergy.baseSaveEnergy * (numRebirths * 0.7f);
        lvlEnergy.saveEnergy += lvlEnergy.saveEnergy * (numRebirths * 0.7f);
        lvlStorage.baseMaxBitesCapacity += lvlStorage.baseMaxBitesCapacity * (numRebirths * 0.7f);
        lvlProcessor.baseBitesPerClick += lvlProcessor.baseBitesPerClick * (numRebirths * 0.7f);
        lvlProcessor.bitesPerClick += lvlProcessor.baseBitesPerClick * (numRebirths * 0.7f);
    }

    public void resetAll()
    {
       
        if(bits.currentBits < 10000)
        {
            //0 moneda de rebirth
        }
        if(bits.currentBits > 10000 && bits.currentBits< 100000)
        {
            bits.numPasiveMoney+=6;
            rebirthMoneyText = 6;
        }
        if (bits.currentBits > 100000 && bits.currentBits < 1000000)
        {
            bits.numPasiveMoney+=12;
            rebirthMoneyText = 12;
        }
        if (bits.currentBits > 1000000 && bits.currentBits < 10000000)
        {
            bits.numPasiveMoney += 18;
            rebirthMoneyText = 18;
        }
        if (bits.currentBits > 10000000 && bits.currentBits < 100000000)
        {
            bits.numPasiveMoney += 24;
            rebirthMoneyText = 24;
        }
        if (bits.currentBits > 100000000 && bits.currentBits < 1000000000)
        {
            bits.numPasiveMoney += 30;
            rebirthMoneyText = 30;
        }
        if (bits.currentBits > 1000000000 && bits.currentBits < 10000000000)
        {
            bits.numPasiveMoney += 36;
            rebirthMoneyText = 36;
        }
        if (bits.currentBits > 10000000000 && bits.currentBits < 100000000000)
        {
            bits.numPasiveMoney += 42;
            rebirthMoneyText = 42;
        }
        if (bits.currentBits > 100000000000 && bits.currentBits < 1000000000000)
        {
            bits.numPasiveMoney += 48;
            rebirthMoneyText = 48;
        }
        if (bits.currentBits > 1000000000000 && bits.currentBits < 10000000000000)
        {
            bits.numPasiveMoney += 56;
            rebirthMoneyText = 56;
        }
        if (bits.currentBits > 10000000000000)
        {
            bits.numPasiveMoney += 62;
            rebirthMoneyText = 62;
        }
        energyBar.currentEnergy = lvlEnergy.maxEnergy;
        energyBar.SetMaxHealth(lvlEnergy.maxEnergy);

        bits.currentBits = 0;
        lvlGraphic.lvl = 1;
        lvlGraphic.SetStats();
        lvlGraphic.SaveLvl();

        lvlEnergy.lvl = 1;
        lvlEnergy.SetStats();
        lvlEnergy.SaveLvl();

        lvlProcessor.lvl = 1;
        lvlProcessor.SetStats();
        lvlProcessor.SaveLvl();

        lvlStorage.lvl = 1;
        lvlStorage.SetStats();
        lvlStorage.SaveLvl();

       
    }
}
