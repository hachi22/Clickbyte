using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] NumberController bits;
    [SerializeField] GameObject secondStop;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject PcPanel;
    bool aux = false;


    [SerializeField] GameObject T1;
    [SerializeField] GameObject T2;
    [SerializeField] GameObject T3;
    [SerializeField] GameObject T4;
    [SerializeField] GameObject T5;
    [SerializeField] GameObject T6;
    [SerializeField] GameObject T7;
    [SerializeField] GameObject T8;
    [SerializeField] GameObject T9;
    [SerializeField] GameObject T10;
    [SerializeField] GameObject All;

    bool activeTutorial = true;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("activeTutorial", 1) == 1)
        {
            activeTutorial = true;
        }
        else activeTutorial = false;


        if (activeTutorial)
        {
            T1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTutorial)
        {

            if (bits.currentBits >= 12)
            {
                if (aux == false)
                {
                    T1.SetActive(false);
                    secondStop.SetActive(true);
                    aux = true;
                }

            }

            if (secondStop.activeInHierarchy && PcPanel.activeInHierarchy)
            {
                secondStop.SetActive(false);
                T2.SetActive(true);
            }

        }

    }


    public void ActiveInformationPanelTutrial()
    {
        if (activeTutorial)
        {
            T2.SetActive(false);
            T3.SetActive(true);
        }

    }

    public void ActivePanelGoToGaccha()
    {
        if (activeTutorial)
        {
            T3.SetActive(false);
            T4.SetActive(true);
        }

    }

    public void ActivePanelGaccha()
    {
        if (activeTutorial)
        {
            T4.SetActive(false);
            T5.SetActive(true);
        }

    }

    public void DesactiveGacha()
    {
        if (activeTutorial)
        {
            T5.SetActive(false);
        }

    }

    public void ActiveReturnToMainScreen()
    {
        if (activeTutorial)
        {

            T6.SetActive(true);
        }

    }


    public void ActiveGoToRebirth()
    {
        if (activeTutorial)
        {
            T9.SetActive(true);
        }
    }


    

    public void ActiveT7()
    {
        if (activeTutorial)
        {
            T6.SetActive(false);
            T9.SetActive(false);
            T7.SetActive(true);
        }

    }


    public void ActivateTutPowerUps()
    {
        if (activeTutorial)
        {

            T7.SetActive(false);
            T10.SetActive(true);
        }
    }

    public void ActiveT8()
    {
        if (activeTutorial)
        {
            T10.SetActive(false);
            T7.SetActive(false);
            T8.SetActive(true);
        }

    }

    public void closeAll()
    {
        if (activeTutorial)
        {
            All.SetActive(false);
            T8.SetActive(false);
            activeTutorial = false;
            PlayerPrefs.SetInt("activeTutorial", 0);
        }
    }
}
