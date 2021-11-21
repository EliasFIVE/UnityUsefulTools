using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button creditsButton;

    private void Start()
    {
        startButton.onClick.AddListener(HandleStartClicked);
        optionsButton.onClick.AddListener(HandleOptionsClicked);
        quitButton.onClick.AddListener(HandleQuitClicked);
        creditsButton.onClick.AddListener(HandleCreditsClicked);
    }

    private void HandleQuitClicked()
    {
        UIManager.Instance.ApplyQuitGame();
    }
    private void HandleOptionsClicked()
    {
        UIManager.Instance.ToggleOptionsMenu();
    }
    private void HandleStartClicked()
    {
        UIManager.Instance.ApplyStartNewGame();
    }

    private void HandleCreditsClicked()
    {
        UIManager.Instance.ToggleCreditsScreen();
    }
}
