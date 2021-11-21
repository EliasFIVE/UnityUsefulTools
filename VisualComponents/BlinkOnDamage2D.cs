using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkOnDamage2D : MonoBehaviour,IDamagable

{
    [SerializeField] Color blinkColor = Color.red;
    [SerializeField] float blinkTime = 0.05f;
    Dictionary<SpriteRenderer, Color> initialColors;
    WaitForSeconds wait;
    public void Damage()
    {
        StartCoroutine(BlinkCoroutine(wait));
    }
    private void Awake()
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer renderer in renderers)
        {
            initialColors.Add(renderer, renderer.color);
        }

        wait = new WaitForSeconds(blinkTime);
    }

    IEnumerator BlinkCoroutine(WaitForSeconds wait)
    {
        foreach (var item in initialColors)
            item.Key.color = blinkColor;

        yield return wait;

        foreach (var item in initialColors)
            item.Key.color = item.Value;
    }
}
