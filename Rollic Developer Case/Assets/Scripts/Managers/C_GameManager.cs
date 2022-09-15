using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GameManager : MonoBehaviour
{
    #region Singleton

    public static C_GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(C_GameManager)) as C_GameManager;

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public int LevelCompleteCount { get => _levelCompleteCount; set => _levelCompleteCount = value; }

    private static C_GameManager instance;
    #endregion
    int _levelCompleteCount;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        LevelCompleteCount = PlayerPrefs.GetInt("LevelCompleteCount");
    }

    public void SaveLevelProgress()
    {
        LevelCompleteCount = PlayerPrefs.GetInt("LevelCompleteCount");
        LevelCompleteCount++;
        PlayerPrefs.SetInt("LevelCompleteCount", LevelCompleteCount);
    }
}
