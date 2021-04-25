using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System;
using System.Linq;

public class GameManager : Manager<GameManager>
{
    #region GameStates definitin
    public enum GameState
    {
        PREGAME,
        INMENU,
        RUNNING,
        PAUSED,
        GAMEOVER
    }
    GameState _currentGameState = GameState.PREGAME;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        //set { _currentGameState = value; }
    }

    #endregion

    [Header("Set In Inspector")]
    public GameObject[] SystemPrefabs;          //System prefabs conteining common for all scenes functionality, like UIManager, SoundManager etc
    List<GameObject> _instancedSystemPrefabs;   //List of all instantiated system prefabs

    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string[] levelsScenesNames;
    string _currentLevelName = string.Empty;

    public Events.EventGameState OnGameStateChanged;

    /*private PlayerController playerController;
    private PlayerController PLayer
    {
        get
        {
            if (null == playerController)
            {
                playerController = FindObjectOfType<PlayerController>();
            }

            return playerController;
        }
    }*/


    private void Start()
    {
        _instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        //UIManager.Instance.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
    }

    /// <summary>
    /// Istantiate all predefined System prefabs.
    /// </summary>
    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    /// <summary>
    /// Update current game state by GameState state param. Calls for OnGameStateChage Event.
    /// </summary>
    /// <param name="state"></param>
    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;

            case GameState.INMENU:
                Time.timeScale = 1.0f;
                break;

            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;

            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    /// <summary>
    /// Load level by string name
    /// </summary>
    /// <param name="levelName"></param>
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;

        _currentLevelName = levelName;
    }

    /// <summary>
    /// After scene load operation completed updates GameState
    /// </summary>
    /// <param name="ao"></param>
    void OnLoadOperationComplete(AsyncOperation ao)

    {
        if (levelsScenesNames.Contains(_currentLevelName))
        {
            UpdateState(GameState.RUNNING);
            //Instance.InitSessions();
        } else if(_currentLevelName == mainMenuSceneName)
        {
            UpdateState(GameState.INMENU);
        } else
        {
            Debug.LogWarning("Load undefined scene. Game state was not updated.");
            return;
        }

        Debug.Log("Load Complete.");
    }

    public void GoToMainMenu()
    {
        LoadLevel(mainMenuSceneName);
    }
    public void StartNewGame()
    {
        LoadLevel(levelsScenesNames[0]);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    protected void OnDestroy()
    {
        if (_instancedSystemPrefabs == null)
            return;

        for (int i = 0; i < _instancedSystemPrefabs.Count; ++i)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }
}
