using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GooglePlayGames;

public class GetUsername : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameText;
    void Start()
    {
       usernameText.text = Social.localUser.userName.ToString();       
    }

    
}
