using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Mission : MonoBehaviour
{
    [Header("Mission's attributes")]
    public int missionID;
    public string missionName;
    public string missionDescription;
    public float requiredBits;
    public int reward;
    public bool completed = false;
    public int tier = 1, userID;
    public Sprite tier1, tier2, tier3;
    [Header("Text to adapt")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI bitsText;
    public TextMeshProUGUI rewardText;
    public Sprite[] users;
    public GameObject imageUser;
    [Header("External components")]
    public GameObject numberController, generator;
    public GPHAchievements achievements;

    void Start()
    {
        nameText.SetText(missionName);
        descText.SetText(missionDescription);
        missionTier();
        bitsText.SetText(BitUtil.StringFormat(requiredBits, BitUtil.TextFormat.Long));
        reward = (int) requiredBits * 5/8;
        rewardText.SetText(reward + "$");
        imageUser.GetComponent<Image>().sprite = users[userID];
        

    }

    public void completeMission() {
            if (numberController.GetComponent<NumberController>().missionComplete(requiredBits,reward))
            {
            achievements.Get1Mission();
            achievements.Get100Missions();
            achievements.Get10Missions();
            achievements.Get50Missions();
            completed = true;
                int misionesCompletadas = PlayerPrefs.GetInt("misionesCompletadas");
                misionesCompletadas++;
                PlayerPrefs.SetInt("misionesCompletadas",misionesCompletadas);
                Debug.Log(PlayerPrefs.GetInt("misionesCompletadas"));
                if (numberController.GetComponent<NumberController>().missionCounter == 3)
                {
                    numberController.GetComponent<NumberController>().missionCounter = 0;
                numberController.GetComponent<NumberController>().setCounterText();
                    generator.GetComponent<GenerateMissions>().deleteAllMissions();
                    generator.GetComponent<GenerateMissions>().generate5Missions();
                }
                else {
                    generator.GetComponent<GenerateMissions>().deleteMission(missionID);
                    Destroy(this.gameObject);
                }

                
            }
        }

    public void missionTier() {
        switch (tier) {
            case 1:
                requiredBits = Random.Range(1f, 160f);
                this.gameObject.GetComponent<Image>().sprite = tier1;
                break;
            case 2:
                requiredBits = Random.Range(160f, 400f);
                this.gameObject.GetComponent<Image>().sprite = tier2;
                break;
            case 3:
                requiredBits = Random.Range(400f, 800f);
                this.gameObject.GetComponent<Image>().sprite = tier3;
                break;
        }
    }
    }

   
