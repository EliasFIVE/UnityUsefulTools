using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    private Transform targetTransform;
    private Transform thisTransform;
    public float distanceFromTarget = 10f;
    public float camHeight = 1f;
    public float rotationDamp = 4f;
    public float posDamp = 4f;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
        targetTransform = target.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 velocity = Vector3.zero;
        thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, targetTransform.rotation, rotationDamp * Time.deltaTime);
        Vector3 dest = thisTransform.position = Vector3.SmoothDamp(thisTransform.position, targetTransform.position, ref velocity, posDamp * Time.deltaTime);
        thisTransform.position = dest - thisTransform.forward * distanceFromTarget;
        thisTransform.position = new Vector3(thisTransform.position.x, camHeight, thisTransform.position.z);
        thisTransform.LookAt(dest);

    }

}
