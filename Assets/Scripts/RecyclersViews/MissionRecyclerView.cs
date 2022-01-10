using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionRecyclerView : UI.RecyclerView<MissionRecyclerView.Holder>.Adapter
{
    public List<Mission> missions;
    public GameObject row;
    public GameObject numberController;
    // Start is called before the first frame update
    void Start()
    {
        NotifyDatasetChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public override int GetItemCount()
    {
        return missions.Count;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        holder.nameText.text = missions[i].missionName;
        holder.descText.text = missions[i].missionDescription;
        holder.bitsText.text = BitUtil.StringFormat(missions[i].requiredBits, BitUtil.TextFormat.Long);
        holder.button.onClick.RemoveAllListeners();
        holder.button.onClick.AddListener(delegate ()
        {
            completeMission(missions[i].completed, missions[i].requiredBits, missions[i].reward, i);
            if (missions[i].completed)
            {
                Debug.Log("Esto funciona");
                missions.Remove(missions[i]);
                NotifyDatasetChanged();
            }
            else {
                Debug.Log("Esto no funciona");
                NotifyDatasetChanged();
            }    
        });
    }

    
    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(row);
    }

    public class Holder : ViewHolder
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descText;
        public TextMeshProUGUI bitsText;
        public TextMeshProUGUI rewardText;
        public Button button;
        public Holder(GameObject itemView) : base(itemView)
        {
            nameText = itemView.transform.Find("MissionName").GetComponent<TextMeshProUGUI>();
            descText = itemView.transform.Find("MissionDescription").GetComponent<TextMeshProUGUI>();
            bitsText = itemView.transform.Find("MissionBits").GetComponent<TextMeshProUGUI>();
            button = itemView.transform.Find("Button").GetComponent<Button>();
        }
    }

    public void completeMission(bool completed, float requiredBits, int reward, int id)
    {
        if (!completed)
        {
            if (numberController.GetComponent<NumberController>().missionComplete(requiredBits, reward))
            {
                missions[id].completed = true;
               
            }
            else
            {
                missions[id].completed = false;
            }
        }
    }
}
