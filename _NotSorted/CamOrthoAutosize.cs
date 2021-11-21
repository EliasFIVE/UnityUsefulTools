using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamOrthoAutosize : MonoBehaviour
{
    private Camera cam;
    public float pixelsToWorldUnits = 200f; //set according to sprite PixelsToUnits setting

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        cam.orthographicSize = Screen.height / 2f / pixelsToWorldUnits;
    }
}
