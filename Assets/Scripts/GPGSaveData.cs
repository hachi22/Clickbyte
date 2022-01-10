using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine.UI;

public class GPGSaveData : MonoBehaviour
{
    private bool isSaving = false;
    private string saveName = "savegames";
    [SerializeField] Text debugText;
    [SerializeField] InputField dataToCloud;

    public void openSaveToCloud(bool saving)
    {
        if (Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution

            (saveName, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, savedGame);
        }
    }

    private void savedGame(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSaving)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(GetDataToStoreInCloud());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, saveUpdate);
            }
            else//si el ifSaving es falso abre la data desde el cloud
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, ReadDataFromCloud);
            }
        }

    }

    private void ReadDataFromCloud(SavedGameRequestStatus status, byte[] data)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            string savedata = System.Text.Encoding.ASCII.GetString(data);
            LoadDataFromCloudToOurGame(savedata);
        }
    }

    private void LoadDataFromCloudToOurGame(string savedata)
    {
        string[] data = savedata.Split('|');
        debugText.text = data[0];
       
    }

    private void saveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log("Succes");
    }

    private string GetDataToStoreInCloud()
    {
        string data = "";
        //data [0]
        data += dataToCloud.text;
        data += "|";
        //data[1]
        //data += "some text";
        //data += "|";
        return data;
    }
}
