using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGAuth : MonoBehaviour
{
    public static PlayGamesPlatform platform;
    public bool bought = false;

    void Start()
    {    

        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
            
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Loged in");
                IAPManager.Instance.InitializeIAPManager(InitializeResultCallback);
            }
            else
            {
                Debug.Log("Failed to login");
            }
        });
    }

    private void InitializeResultCallback(IAPOperationStatus status, string message, List<StoreProduct> shopProducts)
    {
        
        if (status == IAPOperationStatus.Success)
        {   //IAP was successfully initialized //loop through all products
            for (int i = 0; i < shopProducts.Count; i++)
            {
                if (shopProducts[i].productName == "YourProductName")
                {
                    //if active variable is true, means that user had bought that product //so enable access
                    if (shopProducts[i].active)
                    {
                        bought = true;
                    }
                }
            }
        } else
        { Debug.Log("Error occurred "+ message); } }


            void Update()
    {
        
    }
}
