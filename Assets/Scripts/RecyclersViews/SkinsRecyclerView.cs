using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkinsRecyclerView : UI.RecyclerView<SkinsRecyclerView.Holder>.Adapter {


    public List<Skin> SkinsProcesador;
    public List<Skin> SkinsEspacio;
    public List<Skin> SkinsFuenteAlimentacion;
    public List<Skin> SkinsGrafica;

    public GameObject row;

    public List<Skin> RealSkinsList;

    [SerializeField] GameObject Container;
    [SerializeField] NumberController numberController;

    [SerializeField] Image spriteSkinProcesador;
    [SerializeField] Image spriteSkinEspacio;
    [SerializeField] Image spriteSkinFuenteAlimentacion;
    [SerializeField] Image spriteSkinGraficos;

    private List<Text> textosEqiped = new List<Text>();

    private int num;
   

    public void Start()
    {
        NotifyDatasetChanged();
    }

    public void SetSkinsList(int num)
    {
        Container.SetActive(true);
        this.num = num;
        if(num == 0)
        {
            RealSkinsList = SkinsProcesador;
        }else if(num == 1)
        {
            RealSkinsList = SkinsEspacio;
        }else if(num == 2)
        {
            RealSkinsList = SkinsFuenteAlimentacion;
        }
        else 
        {
            RealSkinsList = SkinsGrafica;
        }
        NotifyDatasetChanged();


    }

    public override int GetItemCount()
    {
        return RealSkinsList.Count;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        holder.text.text = RealSkinsList[i].names;
        
        textosEqiped.Add(holder.button.transform.GetChild(0).GetComponent<Text>());

        foreach (int num in numberController.whatSkinsPut)
        {
            if (!(num == RealSkinsList[i].numSkin))
            {
                holder.button.transform.GetChild(0).GetComponent<Text>().text = "equip";
            }
            else
            {
                holder.button.transform.GetChild(0).GetComponent<Text>().text = "equiped";
                break;
            }
        }

        if (RealSkinsList[i].available)
        {
            holder.skinSprite.sprite = RealSkinsList[i].spriteSkin;
        }
        else
        {
            holder.skinSprite.sprite = RealSkinsList[i].spriteUnavailable;
            holder.button.gameObject.SetActive(false);
        }
        holder.button.onClick.RemoveAllListeners();
        holder.button.onClick.AddListener(delegate ()
        {
            SetNewSkin(i);
            foreach(Text text in textosEqiped)
            {
                if (text!= null)
                {
                    text.text = "equip";
                }  
            }
            holder.button.transform.GetChild(0).GetComponent<Text>().text = "equiped";
            RealSkinsList[i].equiped = true;
        });

    }

    private void SetNewSkin(int i)
    {
        numberController.whatSkinsPut[num] = RealSkinsList[i].numSkin;
        numberController.SetSkins();
    }

    private void IsEquiped()
    {
        int[] e = new int[8];
       
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(row);
    }

    public class Holder : ViewHolder
    {
        public Text text;
        public Button button;
        public Image skinSprite;
        public Holder(GameObject itemView) : base(itemView)
        {
            text = itemView.transform.Find("Name").GetComponent<Text>();
            button = itemView.transform.Find("Button").GetComponent<Button>();
            skinSprite = itemView.transform.Find("Image").GetComponent<Image>();
        }
    }
}


