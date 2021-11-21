using UnityEngine;
using UnityEngine.UI;

public class TextExciterShower : MonoBehaviour
{
    private Animator animator;
    private Text text;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<Text>();
    }

    public void ShowExciter(string newText)
    {
        text.text = newText;
        animator.SetTrigger("Excite");

        Invoke("HideExciter", 2f);
    }

    public void HideExciter()
    {
        gameObject.SetActive(false);
    }
}
