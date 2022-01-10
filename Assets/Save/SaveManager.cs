using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CloudSaveManager : MonoSingleton<CloudSaveManager>
{
    public Action<SavedGameRequestStatus> OnSave;
    public Action<SavedGameRequestStatus> OnLoad;

    public SaveState State { get => state; set => state = value; }
    private SaveState state;
    private BinaryFormatter formatter;

    private void Start()
    {
        // Initialize the formatter
        formatter = new BinaryFormatter();
        // Create an Empty state
        state = new SaveState();
    }

    // SaveState serializer
    private byte[] SerializeState()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            formatter.Serialize(ms, state);
            return ms.GetBuffer();
        }
    }
    private SaveState DeserializeState(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            return (SaveState)formatter.Deserialize(ms);
        }
    }

    // Google Cloud
    public void SaveToCloud(Action<PlayServiceError> errorCallback = null)
    {
        PlayService.Instance.OpenCloudSave(OnSaveResponse, errorCallback);
    }
    private void OnSaveResponse(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            byte[] data = SerializeState();
            SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder()
                .WithUpdatedDescription("Last save : " + DateTime.Now.ToString())
                .Build();

            var platform = (PlayGamesPlatform)Social.Active;
            platform.SavedGame.CommitUpdate(meta, update, data, SaveCallback);
        }
        else
            OnSave?.Invoke(status);
    }
    private void SaveCallback(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        OnSave?.Invoke(status);
    }

    public void LoadFromCloud(Action<PlayServiceError> errorCallback = null)
    {
        PlayService.Instance.OpenCloudSave(OnLoadResponse, errorCallback);
    }
    private void OnLoadResponse(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            var platform = (PlayGamesPlatform)Social.Active;
            platform.SavedGame.ReadBinaryData(meta, LoadCallback);
        }
        else
            OnLoad?.Invoke(status);
    }
    private void LoadCallback(SavedGameRequestStatus status, byte[] data)
    {
        state = DeserializeState(data);
        OnLoad?.Invoke(status);
    }
}
