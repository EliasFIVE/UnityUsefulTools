using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make This Object to follow the Focus Object.
/// Usefull for camera follower but not only.
/// Saves the offset from the focus position when started, 
/// and preserves that offset when following the focus.
/// </summary>
public class Follower : MonoBehaviour
{
    [SerializeField]
    private Transform focus;

    [Space] [SerializeField]
    private float smoothTime = 2;

    private Vector3 offset;

    void Start()
    {
        offset = focus.position - transform.position;
    }

    ///!!! Change to LateUpdate if you use this for camera controll
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, focus.position - offset, Time.deltaTime * smoothTime);
    }
}
