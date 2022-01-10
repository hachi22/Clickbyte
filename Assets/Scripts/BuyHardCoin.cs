using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHardCoin : MonoBehaviour
{

    [SerializeField] NumberController coins;

   public void buy100HardCoin()
    {
       
          IAPManager.Instance.BuyProduct(ShopProductNames.dogecoinsx100, ProductBoughtCallback);
             
    }

    public void buy300HardCoin()
    {
       
          IAPManager.Instance.BuyProduct(ShopProductNames.dogecoinsx300, ProductBoughtCallback);
              
        
    }

    private void ProductBoughtCallback(IAPOperationStatus status, string message, StoreProduct product)
    {
        if (status == IAPOperationStatus.Success)
        {//each consumable gives coins in this example
            if (product.productType == ProductType.Consumable)
                coins.dogeCoins += product.value;
            coins.textHardCurrency.SetText(coins.dogeCoins.ToString());
        }
        else
        {            //an error occurred in the buy process, log the message for more details
            Debug.Log("Buy product failed: " + message);
        }
    }
}
       

