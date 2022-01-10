using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaController : MonoBehaviour
{
    [SerializeField] NumberController numberController;

    [SerializeField] Skin[] commonSkins;
    [SerializeField] Skin[] rareSkins;
    [SerializeField] Skin[] legendarySkins;


    private int numGachaSkins;
    private int numGachaPoweUps;

    public int numTicketsSkins;
    public int numTicketsPowerUps;
    public int numTicketsPassive;

    [SerializeField] PowerUps powerUps;

    [SerializeField] private GameObject allSkins;
    private Skin[] skinsLsit;
    private List<Skin> skkinslist;

    [SerializeField] Button buttonGachaSkin;
    [SerializeField] Button buttonGachaPowerUp;

    [SerializeField] GameObject NoTicketsText;

    [SerializeField] private TextMeshProUGUI textTicketsSkin;
    [SerializeField] private TextMeshProUGUI textTicketsPowerUps;
    [SerializeField] private TextMeshProUGUI textTicketsPassive;

    [Header("Game Objects of animations")]
    [SerializeField] private GameObject containerAnimationGacha;

    [SerializeField] private GameObject shakeGameObject;
    private Animator animatorShake;

    [SerializeField] private GameObject fallBallGameObject;
    private Animator fallBallAnimator;

    [SerializeField] private GameObject containerRewardAnimation;
    [SerializeField] private Button buttonGoBackReward;

    [SerializeField] private Animator topBall;
    [SerializeField] private Animator botBall;
    [SerializeField] private Image rewardSprite;

    [SerializeField] private GameObject buttonToStartAnimation;

    [SerializeField] private GameObject buttonSkip;

    private bool stop;

    [Header("Sprites Power Ups")]
    [SerializeField] private Sprite[] listPowerUpSprites;
    private int rarity;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private GameObject particulasCorazones;
    [SerializeField] Rebirth rebirth;
    [SerializeField] RebirthParticlesManager rebirthParticles;

    [SerializeField] GPHAchievements achievements;

    private bool activeParticles;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        particulasCorazones.SetActive(false);
    }

    private void Start()
    {
        numTicketsSkins = PlayerPrefs.GetInt("TicketsSkin",1);
        numTicketsPowerUps = PlayerPrefs.GetInt("TicketsPowerUp", 0);
        numTicketsPassive = PlayerPrefs.GetInt("TicketsPassive", 0);

        numGachaSkins = PlayerPrefs.GetInt("numSkinsGa", 0);



        animatorShake = shakeGameObject.GetComponent<Animator>();
        fallBallAnimator = fallBallGameObject.GetComponent<Animator>();


        SetNumTickets();
        skinsLsit = allSkins.GetComponentsInChildren<Skin>();
        foreach (Skin a in skinsLsit)
        {
            print("skin");
        }
    }


    private void SaveTickets()
    {
        PlayerPrefs.SetInt("TicketsSkin", numTicketsSkins);
        PlayerPrefs.SetInt("TicketsPowerUp", numTicketsPowerUps);
        PlayerPrefs.SetInt("TicketsPassive", numTicketsPassive);
        
        PlayerPrefs.SetInt("numSkinsGa", numGachaSkins);

    }

    private void PreapreAndWait()
    {
        audioManager.SetVolume("Shake", 1);
        stop = false;
        buttonSkip.SetActive(true);
        containerAnimationGacha.SetActive(true);
        buttonToStartAnimation.SetActive(true);
        shakeGameObject.SetActive(true);
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(false);
        animatorShake.speed = 0;
     
    }

    public void RoutineWrap()
    {
        audioManager.Play("ClickClack");
        buttonToStartAnimation.SetActive(false);
        StartCoroutine(StartGachaAnimation());
    }

    private IEnumerator StartGachaAnimation()
    {

        animatorShake.speed = 1;
        yield return new WaitForSeconds(0.5f);
        audioManager.Play("Shake");
        yield return new WaitForSeconds(0.5f);
        audioManager.Play("Shake");
        yield return new WaitForSeconds(2.2f);
        if (!stop)
        {
            shakeGameObject.SetActive(false);
            fallBallGameObject.SetActive(true);
            fallBallAnimator.SetInteger("rarity", rarity);

            yield return new WaitForSeconds(1.3f);
            buttonSkip.SetActive(false);
            containerRewardAnimation.SetActive(true);
            buttonGoBackReward.enabled = false;


            fallBallAnimator.SetInteger("rarity", rarity);
            topBall.SetInteger("rarity", rarity);
            botBall.SetInteger("rarity", rarity);

            ActiveParticles();

            yield return new WaitForSeconds(0.5f);
            buttonGoBackReward.enabled = true;
        }
      
      
    }

    public void SkipContainer()
    {
        StartCoroutine(SkipGachaAnimation());
    }

    public IEnumerator SkipGachaAnimation()
    {
        audioManager.SetVolume("Shake",0);
        stop = true;
        StopCoroutine(StartGachaAnimation());
        StopCoroutine(StartGachaAnimation());
        buttonSkip.SetActive(false);

        shakeGameObject.SetActive(false);
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(true);
        buttonGoBackReward.enabled = false;

        fallBallAnimator.SetInteger("rarity", rarity);
        topBall.SetInteger("rarity", rarity);
        botBall.SetInteger("rarity", rarity);


        ActiveParticles();


        yield return new WaitForSeconds(0.5f);
        buttonGoBackReward.enabled = true;
    }

    private void ActiveParticles()
    {
        if (activeParticles)
        {
            particulasCorazones.SetActive(true);
        }
        activeParticles = false;
    }

    public void exitReward()
    {
        particulasCorazones.SetActive(false);
        fallBallGameObject.SetActive(false);
        containerRewardAnimation.SetActive(false);
        containerAnimationGacha.SetActive(false);
        numberController.GuardarDatosSkin();
        SaveTickets();

    }
  

    public int generateNumberRandom()
    {
        PreapreAndWait();
        int num = Random.Range(0, 100);

        if (num >= 0 && num < 71)
        {
            Debug.Log("Objeto común");
            return 0;
        }else if(num > 70 && num < 95)
        {
            Debug.Log("Objeto raro");
            return 1;
        }
        else
        {
            Debug.Log("Objeto legendario");
            return 2;
        }
    }

    public void ChangeStateNoTicket()
    {
        NoTicketsText.SetActive(!NoTicketsText.activeSelf);
    }
    public void ClickGackaSkin()
    {
        rewardSprite.enabled = true;
        audioManager.Play("ButtonClick");
        if (numTicketsSkins <= 0)
        {
            ChangeStateNoTicket();
        }
        else
        {
            numTicketsSkins--;
            numGachaSkins++;
            int numSkin=90;
            Sprite skinImage = null;
            if (numGachaSkins == 10)
            {
                numGachaSkins = 0;
                numSkin = Random.Range(0, rareSkins.Length);
                rareSkins[numSkin].available = true;
                skinImage = rareSkins[numSkin].spriteSkin;
               
            }
            else
            {
                 rarity = generateNumberRandom();
               
                switch (rarity)
                {
                    case 0:
                        numSkin = Random.Range(0, commonSkins.Length);
                        commonSkins[numSkin].available = true;
                        skinImage = commonSkins[numSkin].spriteSkin;

                //        numSkin = Random.Range(4, 4);
                //        skinsLsit[numSkin].available = true;
                        break;
                    case 1:
                        numSkin = Random.Range(0, rareSkins.Length);
                        rareSkins[numSkin].available = true;
                        skinImage = rareSkins[numSkin].spriteSkin;
                        //        numSkin = Random.Range(4, 4);
                        //       skinsLsit[numSkin].available = true;
                        break;
                    case 2:
                        numSkin = Random.Range(0, legendarySkins.Length);
                        legendarySkins[numSkin].available = true;
                        skinImage = legendarySkins[numSkin].spriteSkin;
                        //       numSkin = Random.Range(4, 4);
                        //        skinsLsit[numSkin].available = true;
                        break;
                }
            }
          //  SetSpriteSkinInRewardImage(numSkin);
            SetSpriteSkinInRewardImage(skinImage);
        }
        SetNumTickets();
    }

    private void SetSpriteSkinInRewardImage(Sprite spriteSkin)
    {
        // rewardSprite.sprite = skinsLsit[numskin].spriteSkin;
        rewardSprite.sprite = spriteSkin;
    }

    private IEnumerator ChangeButtonColor(Button button)
    {
        button.image.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        button.image.color = Color.white;
    }


    public void ClickGachaPassive()
    {
        if (numTicketsPassive <= 0)
        {
            print(numTicketsPassive);
            ChangeStateNoTicket();
        }
        else{
            achievements.GetThePowerOfLove();
            numTicketsPassive--;
            rarity = 2;
            rewardSprite.enabled = false;
            PreapreAndWait();
            activeParticles = true;
            SetNumTickets();
            SaveTickets();
            rebirth.addStatsRebirth();
            rebirthParticles.heartsRebirth = true;
            PlayerPrefs.SetInt("heartsRebirth", 1);
            
        }
    }

    public void ClickGachaPowerUP()
    {
        rewardSprite.enabled = true;
        audioManager.Play("ButtonClick");
        if (numTicketsPowerUps <= 0)
        {
           
            ChangeStateNoTicket();
        }
        else
        {
            achievements.Use20TimesGachaPowerUp();
            numTicketsPowerUps--;
             rarity = generateNumberRandom();

            int num;
            switch (rarity)
            {
                case 0:

                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numCommonBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[0];
                    }
                    else
                    {
                        powerUps.numCommonInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[3];
                    }

                    break;
                case 1:

                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numRareBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[1];
                    }
                    else {
                        powerUps.numRareInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[4];
                    }
                
                    break;
                case 2:
                    num = Random.Range(0, 2);
                    if (num == 1)
                    {
                        powerUps.numLegendaryBytesPerClick++;
                        rewardSprite.sprite = listPowerUpSprites[2];
                    }
                    else {
                        powerUps.numLegendaryInfinityEnergy++;
                        rewardSprite.sprite = listPowerUpSprites[5];
                    }
                   

                    break;
            }
        }
        SetNumTickets();
    }

    public void SetNumTickets()
    {
        textTicketsPowerUps.text = numTicketsPowerUps.ToString();
        textTicketsSkin.text = numTicketsSkins.ToString();
        textTicketsPassive.text = numTicketsPassive.ToString();

    }





}
