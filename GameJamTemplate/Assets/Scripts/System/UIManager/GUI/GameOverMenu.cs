using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;

    void Start()
    {
        retryButton.onClick.AddListener(HandleRetryClicked);
        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
    }

    private void HandleMainMenuClicked()
    {
       UIManager.Instance.ApplyGoToMainMenu();
    }

    private void HandleRetryClicked()
    {
        UIManager.Instance.ApplyStartNewGame(); 
    }

}
