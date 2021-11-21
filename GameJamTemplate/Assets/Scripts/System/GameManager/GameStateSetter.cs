using UnityEngine;

public class GameStateSetter : MonoBehaviour
{
    public enum GameState
    {
        PREGAME,
        INMENU,
        RUNNING,
        PAUSED,
        GAMEOVER
    }
    private GameState _currentGameState;
    public GameState CurrentGameState
    {
        get { return _currentGameState; }
    }

    private void Start()
    {
        UpdateState(GameStateSetter.GameState.PREGAME);
    }

    public void SetInMenuState()
    {
        UpdateState(GameState.INMENU);
    }

    public void SetGameRunningState()
    {
        UpdateState(GameState.RUNNING);
    }

    public void TogglePauseState()
    {
        UpdateState(CurrentGameState == GameStateSetter.GameState.RUNNING ? GameStateSetter.GameState.PAUSED : GameStateSetter.GameState.RUNNING);
    }

    public void SetGameOverState()
    {
        UpdateState(GameState.GAMEOVER);
    }

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

            case GameState.GAMEOVER:
                Time.timeScale = 0.0f;
                break;

            default:
                break;
        }

        GameManager.Instance.OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }
}
