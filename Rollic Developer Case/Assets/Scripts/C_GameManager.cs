using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GameManager : MonoBehaviour
{

    [Header("UI")]

    [SerializeField] GameObject _startMenu;

    public enum GameState { Start,Gameplay,GameOver}
    GameState _gameState;
    public GameState CurrenGameState { get => _gameState; set => _gameState = value; }


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


}
