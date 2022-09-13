using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
 
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
  
}
