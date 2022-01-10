using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUps : MonoBehaviour
{
    [SerializeField] int numPowerUp;
    [SerializeField] EnergyBar energy;
    [SerializeField] private ProcessorComponent processorComponent;

    [Header("Infinity Energy Power Up")]
    [SerializeField] private TextMeshProUGUI textNumCommonInfinityEnergy;
    [SerializeField] private TextMeshProUGUI textNumRareInfinityEnergy;
    [SerializeField] private TextMeshProUGUI textNumEpicInfinityEnergy;

     public int numCommonInfinityEnergy;
     public int numRareInfinityEnergy;
     public int numLegendaryInfinityEnergy;

    [Header("More Bytes Per Click")]
    [SerializeField] private TextMeshProUGUI textNumCommonBytesPerClick;
    [SerializeField] private TextMeshProUGUI textNumRareBytesPerClick;
    [SerializeField] private TextMeshProUGUI textNumEpicBytesPerClick;

     public int numCommonBytesPerClick;
     public int numRareBytesPerClick;
     public int numLegendaryBytesPerClick;


    private bool activateInfinityEnergy;
    private bool activateBytesPerClick;

    public MoveTowards[] listMoveTowards;


    private void Start()
    {
        numCommonInfinityEnergy = PlayerPrefs.GetInt("PowerUpIFC", numPowerUp);
        numRareInfinityEnergy = PlayerPrefs.GetInt("PowerUpIFR", numPowerUp);
        numLegendaryInfinityEnergy = PlayerPrefs.GetInt("PowerUpIFL", numPowerUp);

        numCommonBytesPerClick = PlayerPrefs.GetInt("PowerUpBCC", numPowerUp);
        numRareBytesPerClick = PlayerPrefs.GetInt("PowerUpBCR", numPowerUp);
        numLegendaryBytesPerClick = PlayerPrefs.GetInt("PowerUpBCL", numPowerUp);

    }

    private void SavePowerUps()
    {
        PlayerPrefs.SetInt("PowerUpIFC", numCommonInfinityEnergy);
        PlayerPrefs.SetInt("PowerUpIFR", numRareInfinityEnergy);
        PlayerPrefs.SetInt("PowerUpIFL", numLegendaryInfinityEnergy);

        PlayerPrefs.SetInt("PowerUpBCC", numCommonBytesPerClick);
        PlayerPrefs.SetInt("PowerUpBCR", numRareBytesPerClick);
        PlayerPrefs.SetInt("PowerUpBCL", numLegendaryBytesPerClick);
    }


    public void SetTexts()
    {
        textNumCommonInfinityEnergy.text = "x" + numCommonInfinityEnergy;
        textNumRareInfinityEnergy.text = "x" + numRareInfinityEnergy;
        textNumEpicInfinityEnergy.text = "x" + numLegendaryInfinityEnergy;

        textNumCommonBytesPerClick.text = "x" + numCommonBytesPerClick;
        textNumRareBytesPerClick.text = "x" + numRareBytesPerClick;
        textNumEpicBytesPerClick.text = "x" + numLegendaryBytesPerClick;


    }

    



    private void moreTypesForByte(int numRarity)
    {
        if (numRarity == 1)
        {
            StartCoroutine(ChanegBitesPerClick(2, 10));
        }else if (numRarity == 2)
        {
            StartCoroutine(ChanegBitesPerClick(3, 20));
        }
        else if (numRarity == 3)
        {
            StartCoroutine(ChanegBitesPerClick(5, 20));
        }
    }

    private IEnumerator ChanegBitesPerClick(float multiplier, float time)
    {
        activateBytesPerClick = true;
        processorComponent.bitesPerClick *= multiplier;
        yield return new WaitForSeconds(time);
        processorComponent.bitesPerClick /= multiplier;
        activateBytesPerClick = false;
    }

    private void noEnergyCost(int numRarity)
    {
        if (numRarity == 1)
        {
           StartCoroutine(ChangEnergyCost(0, 30));
        }
        else if (numRarity == 2)
        {
            StartCoroutine(ChangEnergyCost(0, 45));
        }
        else if (numRarity == 3)
        {
            StartCoroutine(ChangEnergyCost(0, 60));
        }
    }

    private IEnumerator ChangEnergyCost(float enrgyCost, float time)
    {
        activateInfinityEnergy = true;
        float aux = 0;
        aux = energy.energyCostForClick;
        energy.energyCostForClick = enrgyCost;
        yield return new WaitForSeconds(time);
        energy.energyCostForClick = aux;
        activateInfinityEnergy = false;

    }


    public void MoreBytesPerClick(int rarity)
    {
       
        if (!activateBytesPerClick)
        {
            if (rarity == 1 && numCommonBytesPerClick > 0)
            {
                moreTypesForByte(rarity);
                numCommonBytesPerClick--;
            }
            else if (rarity == 2 && numRareBytesPerClick > 0)
            {
                moreTypesForByte(rarity);
                numRareBytesPerClick--;
            }
            else if (rarity == 3 && numLegendaryBytesPerClick > 0)
            {
                moreTypesForByte(rarity);
                numLegendaryBytesPerClick--;
            }
            SetTexts();
            SavePowerUps();
        }
    }


    public void InfinityEnergy(int rarity)
    {
        print(activateInfinityEnergy);
        if (!activateInfinityEnergy)
        {
            if (rarity == 1 && numCommonInfinityEnergy > 0)
            {
                noEnergyCost(rarity);
                numCommonInfinityEnergy--;
            }
            else if (rarity == 2 && numRareInfinityEnergy > 0)
            {
                noEnergyCost(rarity);
                numRareInfinityEnergy--;
            }
            else if (rarity == 3 && numLegendaryInfinityEnergy > 0)
            {
                noEnergyCost(rarity);
                numLegendaryInfinityEnergy--;
            }
            SetTexts();
            SavePowerUps();
        }
    }


}
