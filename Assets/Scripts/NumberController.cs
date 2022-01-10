using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NumberController : MonoBehaviour
{
    
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    [SerializeField] EnergyBar energyBarController;
   // [SerializeField] public float bitPerClick;
    //[SerializeField] public double bitPerSecond;
    [SerializeField] public int energyPerClick;
    [SerializeField] public int totalEnergy;
    [SerializeField] public int energyRecovery;
    [SerializeField] public float currentBits=0;
    [SerializeField] public int missionCounter = 0;

    [SerializeField] private TextMeshProUGUI bitText;

    [Header("Skins Recycler")]
    [SerializeField] private GameObject allSkins;
    [SerializeField] private Image[] wherePutSkins;

    public int[] whatSkinsPut = new int[] {5,1,2,3};

    [SerializeField] SkinsRecyclerView skinsRecyclerView;

    [Header("Components")]
    [SerializeField] private SourceEnergy sourceEnergy;
    [SerializeField] private ProcessorComponent processorComponent;
    [SerializeField] private Storage storage;
    [SerializeField] private Graphic graphicCompoenent;

    private int numComponenet;
    [SerializeField] private TextMeshProUGUI textNameInfoPanel;
    [SerializeField] private TextMeshProUGUI textDescriptionInfoPanel;
    [SerializeField] private TextMeshProUGUI textStatsInfoPanel;
    [SerializeField] private TextMeshProUGUI textCost;
    [SerializeField] private TextMeshProUGUI textLvl;
    public GameObject animationScript, mouseAnimation;

    [Header("Money Texts")]

    [SerializeField] private TextMeshProUGUI textDolares;
    [SerializeField] private TextMeshProUGUI textPasiveMoney;
    public TextMeshProUGUI textHardCurrency;
    [SerializeField] public TextMeshProUGUI counterMissions;

    [SerializeField] private AudioManager audioManager;
    public int numDolars;
    public int numPasiveMoney;
    public int dogeCoins;





    void Start()
    {
        currentBits = PlayerPrefs.GetFloat("TotalBits",0);
        RecargarDatosSkin();
        ChargeAnimations();
        audioManager = FindObjectOfType<AudioManager>();
        SetMoney();
        SetSkins();
    }



    public void RecargarDatosSkin()
    {
        int i = 0;
        foreach (Skin s in allSkins.GetComponentsInChildren<Skin>())
        {
            if (PlayerPrefs.GetInt("skin" + i, 9) == 1)
            {
                s.available = true;
            }
            else s.available = false;

            if (PlayerPrefs.GetInt("equiped" + i, 9) == 1)
            {
                s.equiped = true;
            }
            else s.equiped = false;
            print(PlayerPrefs.GetInt("equiped" + i, 9));
            i++;

            if (i <= 4)
            {
                s.available=true;
            }
        }

        if (!(PlayerPrefs.GetInt("whatSkinPut1", 1) == 1))
        {
            i = 0;
            foreach (int intt in whatSkinsPut)
            {
                whatSkinsPut[i] = PlayerPrefs.GetInt("whatSkinPut" + i, 1);

                i++;
            }
        }
    }

    public void GuardarDatosSkin()
    {
        int i = 0;
        foreach (Skin s in allSkins.GetComponentsInChildren<Skin>())
        {
            if (s.available)
            {
                PlayerPrefs.SetInt("skin" + i, 1);
            }
            else PlayerPrefs.SetInt("skin" + i, 0);

            if (s.equiped)
            {
                PlayerPrefs.SetInt("equiped" + i, 1);
            }
            else PlayerPrefs.SetInt("equiped" + i, 0);

            i++;
        }
        i = 0;
        foreach (int intt in whatSkinsPut)
        {
            PlayerPrefs.SetInt("whatSkinPut" + i, whatSkinsPut[i]);
            i++;
        }
    }


    private void SetMoney()
    {
        numDolars = PlayerPrefs.GetInt("Dolars");
        numPasiveMoney = PlayerPrefs.GetInt("PasiveMoney");
        dogeCoins = PlayerPrefs.GetInt("Dogecoins");

        textDolares.text = numDolars.ToString();
        textPasiveMoney.text = numPasiveMoney.ToString();
        textHardCurrency.text = dogeCoins.ToString();
    }
    
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (MaxCapacity())
        {
            currentBits += graphicCompoenent.bitesForSeocnd * Time.deltaTime;

            string delay = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
            bitText.text = delay;
        }
        else
        {
            currentBits = storage.maxBitesCapacity;
            bitText.text = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
        }

        PlayerPrefs.SetFloat("TotalBits", currentBits);
    }

    public void incrementalScore()
    {
       
        PlayerPrefs.SetFloat("ScoreToUpdate", currentBits);
    }

    public void RestBits(float bits)
    {
        currentBits -= bits;
        bitText.text = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long);
    }



    public void ClickOnByteButton()
    {
        audioManager.PlayKeyBoard();
        if (MaxCapacity() && energyBarController.DownBar())
        {
            currentBits += processorComponent.bitesPerClick;
            string delay = BitUtil.StringFormat(currentBits, BitUtil.TextFormat.Long) + "/" + BitUtil.StringFormat(storage.maxBitesCapacity, BitUtil.TextFormat.Long);
            bitText.text = delay;       
            animationScript.GetComponent<RandomAnimation>().startAnimation();
            mouseAnimation.GetComponent<Animator>().SetTrigger("Click");

        }

    }


    private bool MaxCapacity()
    {
        if (storage.maxBitesCapacity >= (currentBits + processorComponent.bitesPerClick))
        {
            return true;
        }
        else return false;
    }





    public void SetSkins()
    {
       for(int i=0; i<wherePutSkins.Length; i++)
        {
            wherePutSkins[i].sprite = allSkins.transform.GetChild(whatSkinsPut[i]).gameObject.GetComponent<Skin>().spriteSkin;
        }
 //       wherePutSkins[0].sprite = allSkins.transform.GetChild(whatSkinsPut[0]).gameObject.GetComponent<Skin>().spriteSkin;
//        print(allSkins.transform.GetChild(whatSkinsPut[0]).gameObject.GetComponent<Skin>().spriteSkin);
    }

    [Header("Skins Layout")]

    [SerializeField] GameObject containerE;
    [SerializeField] GameObject containerP;
    [SerializeField] GameObject containerS;
    [SerializeField] GameObject containerG;

    [SerializeField] GameObject[] containerEnergy;
    [SerializeField] GameObject[] containerProcessor;
    [SerializeField] GameObject[] containerStorage;
    [SerializeField] GameObject[] containerGrafic;

    [SerializeField] Skin[] laListaDeSkinsEnergy;
    [SerializeField] Skin[] laListaDeSkinsProcessor;
    [SerializeField] Skin[] laListaDeSkinsStorage;
    [SerializeField] Skin[] laListaDeSkinsGrafic;

    [SerializeField] Animator energyAnimator;
    [SerializeField] Animator processorAnimator;
    [SerializeField] Animator storageAnimator;
    [SerializeField] Animator graphicAnimator;

    [SerializeField] ScrollRect scrollRect;


    public void SetInfoInPanel(int num)
    {
        containerE.SetActive(false);
        containerP.SetActive(false);
        containerS.SetActive(false);
        containerG.SetActive(false);
        numComponenet = num;
        switch (num)
        {
            case 0:
                containerE.SetActive(true);
                scrollRect.content = containerE.GetComponent<RectTransform>();
                SetUI(sourceEnergy.cName, sourceEnergy.description, sourceEnergy.statsDescription, sourceEnergy.cost, sourceEnergy.lvl);
                SetSkinLayaout(containerEnergy, laListaDeSkinsEnergy);
             //   skinsRecyclerView.SetSkinsList(numComponenet);
                 break;
            case 1:
                containerP.SetActive(true);
                scrollRect.content = containerP.GetComponent<RectTransform>();
                SetUI(processorComponent.cName, processorComponent.description, processorComponent.statsDescription, processorComponent.cost, processorComponent.lvl);
                SetSkinLayaout(containerProcessor, laListaDeSkinsProcessor);
                //     skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 2:
                containerS.SetActive(true);
                scrollRect.content = containerS.GetComponent<RectTransform>();
                SetUI(storage.cName, storage.description, storage.statsDescription, storage.cost, storage.lvl);
                SetSkinLayaout(containerStorage, laListaDeSkinsStorage);
                //    skinsRecyclerView.SetSkinsList(numComponenet);
                break;
            case 3:
                containerG.SetActive(true);
                scrollRect.content = containerG.GetComponent<RectTransform>();
                SetUI(graphicCompoenent.cName, graphicCompoenent.description, graphicCompoenent.statsDescription, graphicCompoenent.cost,graphicCompoenent.lvl);
                SetSkinLayaout(containerGrafic, laListaDeSkinsGrafic);
                //    skinsRecyclerView.SetSkinsList(numComponenet);
                break;

        }
    }

    public void SetNewSkin(string name)
    {
        Skin[] sgdg = allSkins.GetComponentsInChildren<Skin>();
        Skin skinn = Array.Find(sgdg, skin => skin.names == name);
        DesequipAll(skinn);
       
        // print(skinn);
        //  print(whatSkinsPut[numComponenet]);
        whatSkinsPut[numComponenet] = skinn.numSkin;
      //  print(whatSkinsPut[numComponenet]);
        SetSkins();
        GuardarDatosSkin();
    }

    private int animatedE;
    private int animatedP;
    private int animatedS;
    private int animatedG;

    private void DesequipAll(Skin skin)
    {
        switch (numComponenet)
        {
            case 0:
                CleanEquip(laListaDeSkinsEnergy);
                skin.equiped = true;
                SetSkinLayaout(containerEnergy, laListaDeSkinsEnergy);
                if (skin.isAnimated)
                {
                    EnableAnimatorAndPlay(skin.names, energyAnimator);
                    PlayerPrefs.SetString("energy", skin.names);
                    animatedE = 1;
                    PlayerPrefs.SetInt("animatedE", animatedE);
                }
                else
                {
                    energyAnimator.enabled = false;
                    animatedE = 0;
                    PlayerPrefs.SetInt("animatedE", animatedE);
                }
                break;
            case 1:
                CleanEquip(laListaDeSkinsProcessor);
                skin.equiped = true;
                SetSkinLayaout(containerProcessor, laListaDeSkinsProcessor);
                if (skin.isAnimated)
                {
                    EnableAnimatorAndPlay(skin.names, processorAnimator);
                    PlayerPrefs.SetString("proces", skin.names);
                    animatedP = 1;
                    PlayerPrefs.SetInt("animatedP", animatedP);
                }
                else
                {
                    animatedP = 0;
                    PlayerPrefs.SetInt("animatedP", animatedP);
                    processorAnimator.enabled = false;
                }
                break;
            case 2:
                CleanEquip(laListaDeSkinsStorage);
                skin.equiped = true;
                SetSkinLayaout(containerStorage, laListaDeSkinsStorage);
                if (skin.isAnimated)
                {
                    EnableAnimatorAndPlay(skin.names, storageAnimator);
                    PlayerPrefs.SetString("storage", skin.names);
                    animatedS = 1;
                    PlayerPrefs.SetInt("animatedS", animatedS);
                }
                else {
                    animatedS = 0;
                    storageAnimator.enabled = false;
                    PlayerPrefs.SetInt("animatedS", animatedS);
                }
       
                break;
            case 3:
                CleanEquip(laListaDeSkinsGrafic);
                skin.equiped = true;
                SetSkinLayaout(containerGrafic, laListaDeSkinsGrafic);
                if (skin.isAnimated)
                {
                    EnableAnimatorAndPlay(skin.names, graphicAnimator);
                    PlayerPrefs.SetString("grafic", skin.names);
                    animatedG = 1;
                    PlayerPrefs.SetInt("animatedG", animatedG);
                }
                else {
                    graphicAnimator.enabled = false;
                    animatedG = 0;
                    PlayerPrefs.SetInt("animatedG", animatedG);
                }
                break;
        }
    }

    private void CleanEquip(Skin [] list)
    {
        foreach (Skin s in list)
        {
            s.equiped = false;
        }
    }

    public void ChargeAnimations()
    {
        if (PlayerPrefs.GetInt("animatedG") == 1)
        {
            graphicAnimator.enabled = true;
            graphicAnimator.SetBool("Normal", false);
            graphicAnimator.SetTrigger("Grafic V2");
        }

        if (PlayerPrefs.GetInt("animatedS") == 1)
        {
            numComponenet = 2;
            storageAnimator.enabled = true;
            storageAnimator.SetBool("Normal", false);
            storageAnimator.SetTrigger("CD");
            
        }


        if (PlayerPrefs.GetInt("animatedE") ==1)
        {
            numComponenet = 0;
            EnableAnimatorAndPlay(PlayerPrefs.GetString("energy"), energyAnimator);
        }


        
    }

    private void EnableAnimatorAndPlay(string nameSkin, Animator animator)
    {

        animator.enabled = true;
        energyAnimator.SetBool("Normal", false);
        animator.SetTrigger(nameSkin);
    }

    public void SetSkinLayaout(GameObject[] llistacontainers, Skin[] listaSkins)
    {
     
       
        Text nombre;
        Image image;
        Button button;
        Text textButton;

        for(int i =0; i< llistacontainers.Length; i++)
        {
            nombre = llistacontainers[i].transform.GetChild(1).GetComponent<Text>();


            image = llistacontainers[i].transform.GetChild(2).GetComponent<Image>();
            button = llistacontainers[i].transform.GetChild(3).GetComponent<Button>();
            textButton = button.GetComponentInChildren<Text>();

            if (listaSkins[i].available)
            {

                nombre.text = listaSkins[i].names;
                button.enabled = true;
                if (listaSkins[i].equiped)
                {
                    textButton.text = "equiped";
                }
                else textButton.text = "equip";

                
                image.sprite = listaSkins[i].spriteSkin;
            }
            else
            {
                nombre.text = "???";
                image.sprite = listaSkins[i].spriteUnavailable;
                button.enabled = false;
                textButton.text = "locked";
            }
        }


    }

    public void SetUI(string name, string description, string stats, float cost, int level)
    {
        textNameInfoPanel.text = name;
        textDescriptionInfoPanel.text = description;
        textStatsInfoPanel.text = stats;
        textCost.text = BitUtil.StringFormat(cost, BitUtil.TextFormat.Long);
        textLvl.text = "Lvl "+level.ToString();
    }


    public void LevelUp()
    {
        switch (numComponenet)
        {
            case 0:
                if (currentBits >= sourceEnergy.cost)
                {
                    RestBits(sourceEnergy.cost);
                    sourceEnergy.LevelUP();
                    SetUI(sourceEnergy.cName, sourceEnergy.description, sourceEnergy.statsDescription, sourceEnergy.cost, sourceEnergy.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 1:
                if (currentBits >= processorComponent.cost)
                {
                    RestBits(processorComponent.cost);
                    processorComponent.LevelUP();
                    SetUI(processorComponent.cName, processorComponent.description, processorComponent.statsDescription, processorComponent.cost, processorComponent.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 2:
                if (currentBits >= storage.cost)
                {
                    RestBits(storage.cost);
                    storage.LevelUP();
                    SetUI(storage.cName, storage.description, storage.statsDescription, storage.cost, storage.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
            case 3:
                if (currentBits >= graphicCompoenent.cost)
                {
                    RestBits(graphicCompoenent.cost);
                    graphicCompoenent.LevelUP();
                    SetUI(graphicCompoenent.cName, graphicCompoenent.description, graphicCompoenent.statsDescription, graphicCompoenent.cost, graphicCompoenent.lvl);
                }
                else
                {
                    StartCoroutine(ChangeTextColor());
                }
                break;
        }
    }

    private IEnumerator ChangeTextColor()
    {
        textCost.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        textCost.color = Color.white;
    }

    public bool missionComplete(float requiredBits, int reward) {
        if (currentBits >= requiredBits)
        {
            RestBits(requiredBits);
            numDolars += reward;
            textDolares.SetText(numDolars+"");
            missionCounter++;
            setCounterText();
            return true;
        }
        else {
            return false;
        }

    }

    public void setCounterText() {
        counterMissions.SetText(missionCounter.ToString());
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Dolars",numDolars);
        PlayerPrefs.SetInt("PasiveMoney",numPasiveMoney);
        PlayerPrefs.SetInt("Dogecoins",dogeCoins);
    }
}
