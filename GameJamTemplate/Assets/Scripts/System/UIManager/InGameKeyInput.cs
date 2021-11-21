using UnityEngine;

public class InGameKeyInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleEscapeKeyDown();
        }
    }

    private void HandleEscapeKeyDown()
    {
        GameManager.Instance.TogglePause();
    }
}
