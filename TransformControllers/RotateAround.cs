using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Rotates This Object around Focus Object by user Input.
///  Usefull for camera controll but not only.
///  Use Arrow Keys to rotate.
/// </summary>
public class RotateAround : MonoBehaviour
{
    [Range(0,100)] [SerializeField]
    private float rotationSpeed=50;

    [Space] [SerializeField]
    private Transform focusObject;

    void Start()
    {
        transform.LookAt(focusObject);
    }

    ///!!! Change to LateUpdate if you use this for camera controll
    void Update()
    {
        transform.LookAt(focusObject);
        RotateByInput();
    }

    private void RotateByInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 focusPoint = focusObject.position;

        transform.RotateAround(focusPoint, Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        transform.RotateAround(focusPoint, transform.right, rotationSpeed * verticalInput * Time.deltaTime);
    }

}

