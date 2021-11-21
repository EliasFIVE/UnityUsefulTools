using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitToMenuButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
        optionsButton.onClick.AddListener(HandleOptionsClicked);
        exitToMenuButton.onClick.AddListener(HandleExitToMenuClicked);
    }

    private void HandleResumeClicked()
    {
        UIManager.Instance.ApplyToggleGamePause();
    }

    private void HandleOptionsClicked()
    {
        UIManager.Instance.ToggleOptionsMenu();
    }

    private void HandleExitToMenuClicked()
    {
        UIManager.Instance.ApplyGoToMainMenu();
    }
}
