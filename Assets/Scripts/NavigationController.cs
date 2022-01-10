using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class NavigationController : MonoBehaviour
{

    [SerializeField] NumberController numberController;
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject ClickPanel;
    [SerializeField] GameObject PcPanel;
    [SerializeField] AudioManager audioManager;


    [SerializeField] Button buttonPC;

    private void Start()
    {

        audioManager = FindObjectOfType<AudioManager>();
        if(panels != null)
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
             
            }
        }

        ClickPanel.SetActive(true);

    }

    private void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
    }


    public void DesactivatePanelArray(GameObject thispa)
    {
        foreach (GameObject panel in panels)
        {

            if (!panel.name.Equals(thispa.name) && !panel.name.Equals(ClickPanel.name))
            {
                panel.SetActive(false);
            }
            else thispa.SetActive(true);
            
        }
        audioManager.Play("ButtonClick");
        buttonPC.enabled = true;
    }

    public void ChangeStatePanel(GameObject canvas)
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }else canvas.SetActive(true);
        audioManager.Play("ButtonClick");
        numberController.ChargeAnimations();
        buttonPC.enabled = true;
    
    }

    public void ChangeScene(int numScene)
    {


        //if (Social.Active.localUser.authenticated)
        {
            audioManager.Play("ButtonClick");
            SceneManager.LoadScene(numScene);
        }
        
    }

    public void ChangeEstateButtonPC()
    {
        buttonPC.enabled = false;
    }


}
