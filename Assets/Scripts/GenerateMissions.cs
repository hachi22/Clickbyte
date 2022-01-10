using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateMissions : MonoBehaviour
{
    public GameObject missionPrefab, gameController;
    public List<string> descsTier1,descTier2,descTier3;
    public List<GameObject> currentMissions;
    [SerializeField] GPHAchievements achievements;
    // Start is called before the first frame update
    void Start()
    {
        generate5Missions();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readFile(string file, List<string> tier)
    {
        FileInfo theSourceFile = null;
        StreamReader reader = null;
        string text = " ";
        theSourceFile = new FileInfo(file);
        reader = theSourceFile.OpenText();
        while (text != null)
        {
            text = reader.ReadLine();
            tier.Add(text);
        }
        tier.RemoveAt(tier.Count-1);
    }

    public void generate5Missions() {
        for (int i = 0; i < 5; i++)
        {

            GameObject mission = Instantiate(missionPrefab, this.gameObject.transform) as GameObject;
            mission.GetComponent<Mission>().missionID = i;
            mission.GetComponent<Mission>().missionName = "Mission " + (i + 1);
            mission.GetComponent<Mission>().numberController = gameController;
            mission.GetComponent<Mission>().generator = this.gameObject;
            mission.GetComponent<Mission>().achievements = achievements;
            int num = Random.Range(0, 2);
            Debug.Log(num);
            mission.GetComponent<Mission>().userID = num;
            if (PlayerPrefs.GetInt("misionesCompletadas") >= 10)
            {
                mission.GetComponent<Mission>().tier = 2;
                mission.GetComponent<Mission>().missionDescription = descTier2[Random.Range(0, descTier2.Count - 1)];
            }
            else {
                if (PlayerPrefs.GetInt("misionesCompletadas") >= 20)
                {
                    mission.GetComponent<Mission>().tier = 3;
                    mission.GetComponent<Mission>().missionDescription = descTier3[Random.Range(0, descTier3.Count - 1)];
                }
                else {
                    mission.GetComponent<Mission>().tier = 1;
                    mission.GetComponent<Mission>().missionDescription = descsTier1[Random.Range(0, descsTier1.Count - 1)];
                }
            }

            currentMissions.Add(mission);
        }
        
    }

    public void deleteAllMissions() {
        for (int i = 0; i < currentMissions.Count; i++)
        {
            Destroy(currentMissions[i].gameObject);
        }
        currentMissions.Clear();
    }

    public void deleteMission(int id) {
        for (int i = 0; i < currentMissions.Count-1; i++)
        {
            if (currentMissions[i].GetComponent<Mission>().missionID == id) 
            {
                currentMissions.RemoveAt(i);
            }
        }
    }
}
