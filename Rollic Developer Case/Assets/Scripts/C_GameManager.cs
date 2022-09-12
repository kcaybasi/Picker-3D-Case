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
    private static C_GameManager instance;
    #endregion


    [Header("Level Parameters")]

    [SerializeField] int _requiredCollectible;
    [SerializeField] int _collectedCount;
    [SerializeField] List<GameObject> _collectedList;


    [Header("UI")]

    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _gamsSuccessMenu;

    public enum GameState { Start,Gameplay,GameOver}
    GameState _gameState;
    public GameState CurrenGameState { get => _gameState; set => _gameState = value; }
    public int RequiredCollectible { get => _requiredCollectible; set => _requiredCollectible = value; }
    public List<GameObject> CollectedList { get => _collectedList; set => _collectedList = value; }
    public int CollectedCount { get => _collectedCount; set => _collectedCount = value; }

    public delegate void GameAction();
    public static event GameAction OnGameStarted;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        CurrenGameState = GameState.Start;
    }


    private void Update()
    {

        if (Input.anyKeyDown && CurrenGameState==GameState.Start )
        {
            CloseMenu(_startMenu);
            CurrenGameState = GameState.Gameplay;
            OnGameStarted?.Invoke();
        }

        if (Input.touchCount > 0 && CurrenGameState==GameState.Start)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                CurrenGameState = GameState.Gameplay;
                OnGameStarted?.Invoke();
            }
        }
        else
        {
            return;
        }
    }


    void CloseMenu(GameObject _menu)
    {
        _menu.SetActive(false);
    }

    public void CheckLevelSuccess()
    {
        if (CollectedList.Count == 0)
        {
          
            if (_collectedCount >= _requiredCollectible)
            {
               // Debug.Log("Game success");
            }
            else
            {
               // Debug.Log("Game over");
            }
        }
  
    }
}
