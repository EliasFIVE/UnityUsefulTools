using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Button resumeButton;

    void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
    }

    private void HandleResumeClicked()
    {
        UIManager.Instance.ToggleCreditsScreen();
    }
}
