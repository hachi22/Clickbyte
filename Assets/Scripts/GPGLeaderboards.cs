using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGLeaderboards : MonoBehaviour
{
    bool isPaused = false;

    private void Start()
    {
        OnApplicationQuit();

        if (isPaused)
        {
            UpdateLeaderboardScore();
        }
    }

    private void OnApplicationQuit()
    {
        UpdateLeaderboardScore();
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }
    public void OepnLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboardScore()
    {

        Social.ReportScore((long)PlayerPrefs.GetFloat("ScoreToUpdate", 1), GPGSIds.leaderboard_score, (bool succes) =>
        {
            Debug.Log(succes);
        });
    }
}
