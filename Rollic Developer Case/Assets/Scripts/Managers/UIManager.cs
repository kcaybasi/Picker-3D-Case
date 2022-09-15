using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(UIManager)) as UIManager;

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static UIManager instance;
    #endregion



    int _buildIndex;
    int _levelNo;
    [SerializeField] TextMeshProUGUI _levelText;

    [SerializeField] List<GameObject> _menuList = new List<GameObject>();

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }



        // Set Level Text

        _buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (PlayerPrefs.HasKey("LevelCompleteCount"))
        {
            _levelNo = C_GameManager.Instance.LevelCompleteCount;
        }
        else
        {
            _levelNo = 1;
        }
        
        _levelText.text = "LEVEL " + _levelNo;
 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_menuNo"> 0: Start Menu, 1: GameOver Menu, 2: GameSuccess Menu</param>

    public void OpenMenu(int _menuNo)
    {
        _menuList[_menuNo].SetActive(true);        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_menuNo"> 0: Start Menu, 1: GameOver Menu, 2: GameSuccess Menu</param>
    public void CloseMenu(int _menuNo)
    {
        _menuList[_menuNo].SetActive(false);
    }

    #region Button Functions

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_buildIndex+1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_buildIndex);
    }


    #endregion


}
