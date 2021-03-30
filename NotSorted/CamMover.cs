using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMover : MonoBehaviour
{
    public float totalTime = 5f;
    public float totalDistance = 30f;

    public AnimationCurve xCurve;
    public AnimationCurve yCurve;
    public AnimationCurve zCurve;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(PlayAnim());
    }

    public IEnumerator PlayAnim()
    {
        float timeElapsed = 0f;
        while (timeElapsed < totalTime)
        {
            float normalTime = timeElapsed / totalTime;
            Vector3 newPos = thisTransform.right.normalized * xCurve.Evaluate(normalTime) * totalDistance;
            newPos += thisTransform.up.normalized * yCurve.Evaluate(normalTime) * totalDistance;
            newPos += thisTransform.forward.normalized * zCurve.Evaluate(normalTime) * totalDistance;
            thisTransform.position = newPos;

            yield return null;

            timeElapsed += Time.deltaTime;
        }
    }
}
