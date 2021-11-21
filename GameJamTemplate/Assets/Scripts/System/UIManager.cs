using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager<UIManager>
{
    private GUIGroupsSetter gUI;
    private KeyInputGroupsSetter keyUI;

    private ExcitersSetter exciters;

    protected override void Awake()
    {
        base.Awake();
        gUI = GetComponent<GUIGroupsSetter>();
        keyUI = GetComponent<KeyInputGroupsSetter>();
        exciters = GetComponent<ExcitersSetter>();
    }
    private void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStateChanged.AddListener(gUI.HandleGameStateChanged);
            GameManager.Instance.OnGameStateChanged.AddListener(keyUI.HandleGameStateChanged);
        }
    }

    public void ApplyToggleGamePause()
    {
        GameManager.Instance.TogglePause();
    }

    public void ApplyGoToMainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
    public void ApplyStartNewGame()
    {
        GameManager.Instance.StartNewGame();
    }

    public void ApplyQuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void ToggleOptionsMenu()
    {
        Debug.Log("UImanager options");
        gUI.ToggleOptionsMenu();
    }

    public void ToggleCreditsScreen()
    {
        gUI.ToggleCreditsScreen();
    }

    public void ShowTextExciter(string text)
    {
        exciters.TextExciter.gameObject.SetActive(true);
        exciters.TextExciter.ShowExciter(text);
    }
}
