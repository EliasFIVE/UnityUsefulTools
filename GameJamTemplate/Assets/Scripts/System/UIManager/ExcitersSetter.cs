using UnityEngine;

public class ExcitersSetter : MonoBehaviour
{
    [SerializeField] private TextExciterShower textExciter;

    public TextExciterShower TextExciter
    {
        get { return textExciter; }
    }
}
