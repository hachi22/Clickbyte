using System;
using UnityEngine;

[System.Serializable]
public class SaveState
{
    public DateTime LastSaveTime { set; get; }
    public int SaveCount { set; get; }
}