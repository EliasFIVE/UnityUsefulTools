using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFieldView : MonoBehaviour
{
    public float angleView = 30f;
    public Transform target = null;
    private Transform thisTransform = null;

    private void Awake()
    {
        thisTransform = transform;
    }

    private void Update()
    {
        Vector3 forward = thisTransform.forward.normalized;
        Vector3 toObject = (target.position - thisTransform.position).normalized;
        float dotProduct = Vector3.Dot(forward, toObject);
        float angle = dotProduct * 180f;
        if (angle >= 180f - angleView)
        {
            Debug.Log("Object can be seen");
        }
    }
}
