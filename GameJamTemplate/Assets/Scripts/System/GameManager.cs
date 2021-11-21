using UnityEngine;


public class GameManager : Manager<GameManager>
{
    private GameStateSetter gameStateSetter;
    private SceneSetter sceneSetter;

    [HideInInspector] public Events.EventGameState OnGameStateChanged;


    protected override void Awake()
    {
        base.Awake();
        gameStateSetter = gameObject.GetComponent<GameStateSetter>();
        sceneSetter = gameStateSetter.GetComponent<SceneSetter>();
    }

    public void LoadMainMenu()
    {
        sceneSetter.LoadMainMenuScene();
    }

    public void StartNewGame()
    {
        sceneSetter.LoadFirstLevel();
    }

    public void SetInMenuState()
    {
        gameStateSetter.SetInMenuState();
    }

    public void SetGameRunningState()
    {
        gameStateSetter.SetGameRunningState();
    }

    public void TogglePause()
    {
        gameStateSetter.TogglePauseState();
    }

    public void OnPlayerDeath()
    {
        Invoke("LooseGameOver", 2f);
        UIManager.Instance.ShowTextExciter("You loose");
    }

    public void LooseGameOver()
    {
        gameStateSetter.SetGameOverState();
        CancelInvoke();
    }

    public void WinGameOver()
    {
        //Lojic of player complete the game and win
        //Not implemented in this game because it is infinite game
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool IfGameInRunningState()
    {
        return (gameStateSetter.CurrentGameState == GameStateSetter.GameState.RUNNING);
    }
}
