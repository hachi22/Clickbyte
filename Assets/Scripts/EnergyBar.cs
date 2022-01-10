using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{

	[SerializeField] private Slider slider;
	[SerializeField] private Gradient gradient;
	[SerializeField] private Image fill;

	//[SerializeField] private float maxEnergy = 100;
	public float currentEnergy;

	[SerializeField] float energyForSecond;
    public float energyCostForClick;
    [SerializeField] private TextMeshProUGUI bitText;
    [SerializeField] private GameObject eventSystem;

	[SerializeField] private SourceEnergy sourceEnergyComponent;

    private void Awake()
    {
    //    PlayerPrefs.DeleteAll();
    }


    void Start()
	{
		currentEnergy = sourceEnergyComponent.maxEnergy;
        currentEnergy = PlayerPrefs.GetFloat("EnergyInBar", sourceEnergyComponent.maxEnergy);
        SetMaxHealth(sourceEnergyComponent.maxEnergy);
	
	}


//	public void ChangeMaxEnergy(float newMaxEnergy)
//    {
//		slider.maxValue = newMaxEnergy;
//		maxEnergy = newMaxEnergy;
//		SetMaxHealth(maxEnergy);
//		SetHealth(currentEnergy);
//	}

 
	private void FixedUpdate()
	{
		if (currentEnergy < sourceEnergyComponent.maxEnergy)
		{
			currentEnergy += energyForSecond * Time.deltaTime;
			SetHealth(currentEnergy);
		}
        PlayerPrefs.SetFloat("EnergyInBar", currentEnergy);
	}
	

    public void SetMaxHealth(float energy)
	{
		slider.maxValue = energy;
		slider.value = energy;
		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(float health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

	public bool DownBar()
	{
        if (currentEnergy - energyCostForClick < 0)
        {
			return false;
		}
        else
        {
			currentEnergy -= energyCostForClick;
			SetHealth(currentEnergy);
			return true;
        }
		
	}

	public void UpBar(float up)
	{
        if (currentEnergy < sourceEnergyComponent.maxEnergy)
        {
			currentEnergy += up;
			SetHealth(currentEnergy);
		}

	}


    public void SetRealEnergyCost()
    {
        energyCostForClick -= sourceEnergyComponent.saveEnergy;
    }

}
