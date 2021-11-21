using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform focus;

    [Space]
    [SerializeField]
    private float smoothTime = 2;

    private Vector3 offset;

    void Start()
    {
        offset = focus.position - transform.position;
    }

    ///!!! Change to LateUpdate if you use this for camera controll
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, focus.position - offset, Time.deltaTime * smoothTime);
    }
}
