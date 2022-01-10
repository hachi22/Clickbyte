using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public int itemID, quantity;
    public float price;
    public string name;
    public Sprite itemSprite;
    public string currency;
    [Header("Text to adapt")]
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI priceText;
    public GameObject itemImage;
    // Start is called before the first frame update
    void Start()
    {
        priceText.SetText(price+currency);
        quantityText.SetText(quantity+" X");
        itemImage.GetComponent<Image>().sprite = itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
