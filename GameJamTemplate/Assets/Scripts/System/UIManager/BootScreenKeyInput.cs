using UnityEngine;

public class BootScreenKeyInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleSpaceKeyDown();
        }
    }

    void HandleSpaceKeyDown()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
