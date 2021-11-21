using UnityEngine;

public class GUIGroupsSetter : MonoBehaviour
{
    [SerializeField] private GameObject bootMenu;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameOverMenu gameOverMenu;
    //[SerializeField] private InGameGUIExternalConnector inGameUI;
    [SerializeField] private OptionsMenu optionsMenu;
    [SerializeField] private CreditsScreen creditsScreen;

    public void HandleGameStateChanged(GameStateSetter.GameState currentState, GameStateSetter.GameState previousState)
    {
        Debug.LogFormat("Game state {0}", currentState.ToString());

        bootMenu.SetActive(currentState == GameStateSetter.GameState.PREGAME);

        mainMenu.gameObject.SetActive(currentState == GameStateSetter.GameState.INMENU);

        //inGameUI.gameObject.SetActive(currentState == GameStateSetter.GameState.RUNNING);

        pauseMenu.gameObject.SetActive(currentState == GameStateSetter.GameState.PAUSED);

        gameOverMenu.gameObject.SetActive(currentState == GameStateSetter.GameState.GAMEOVER);

        optionsMenu.gameObject.SetActive(false);
    }

    public void ToggleOptionsMenu() 
    {
        Debug.Log("Optons Toggle");
        if (optionsMenu.gameObject.activeInHierarchy)
            optionsMenu.gameObject.SetActive(false);
        else
            optionsMenu.gameObject.SetActive(true);
    }

    public void ToggleCreditsScreen()
    {
        Debug.Log("Credits Toggle");
        creditsScreen.gameObject.SetActive(!creditsScreen.gameObject.activeInHierarchy);
    }
}
