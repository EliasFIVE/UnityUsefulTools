using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Use on Text object to set blinkin text
/// Interpolate between two colors set in inspector
/// </summary>
public class TextBlink : MonoBehaviour
{
    [Header("Set In Inspector")]
    public Color color1;
    public Color color2;
    public float freq = 0.1f;

    private Text text;
    private float u = 0;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        u = Mathf.Abs(Mathf.Sin(freq * Time.time));
        text.color = Color.Lerp(color1, color2, u);
    }
}
