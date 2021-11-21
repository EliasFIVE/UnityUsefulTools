using UnityEngine;

public class KeyInputGroupsSetter : MonoBehaviour
{
    [SerializeField] private InGameKeyInput inGameInput;
    [SerializeField] private BootScreenKeyInput bootScreenInput;
    public void HandleGameStateChanged(GameStateSetter.GameState currentState, GameStateSetter.GameState previousState)
    {
        bootScreenInput.gameObject.SetActive(currentState == GameStateSetter.GameState.PREGAME);
        inGameInput.gameObject.SetActive(currentState == GameStateSetter.GameState.RUNNING || currentState == GameStateSetter.GameState.PAUSED);
    }
}
