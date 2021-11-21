using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetter : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string[] levelsScenesNames;

    string currentLevelName = string.Empty;

    public void LoadMainMenuScene()
    {
        LoadLevel(mainMenuSceneName);
    }

    public void LoadFirstLevel()
    {
        LoadLevel(levelsScenesNames[0]);
    }

    private void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete;
        currentLevelName = levelName;
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (currentLevelName == mainMenuSceneName)
            GameManager.Instance.SetInMenuState();
        else if (levelsScenesNames.Contains(currentLevelName))
            GameManager.Instance.SetGameRunningState();
        else
            Debug.LogWarning("Load undefined scene. Game state was not updated.");
    }
}
