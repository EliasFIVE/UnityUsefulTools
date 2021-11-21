using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private Transform thisTransform;

    public float shakeTime = 2f;
    public float shakeAmount = 3f;
    public float shakeSpeed = 2f;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        Vector3 origPosition = thisTransform.localPosition;
        float elapsedTime = 0f;
        while(elapsedTime < shakeTime)
        {
            Vector3 randomPoint = origPosition + Random.insideUnitSphere * shakeAmount;
            thisTransform.localPosition = Vector3.Lerp(thisTransform.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        thisTransform.localPosition = origPosition;

    }
}
