using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAt : MonoBehaviour
{
    public GameObject go;
    private Transform goTransform;


    private void Awake()
    {
        goTransform = go.GetComponent<Transform>();
    }


    void Update()
    {
        transform.LookAt(goTransform.position);
    }
}
