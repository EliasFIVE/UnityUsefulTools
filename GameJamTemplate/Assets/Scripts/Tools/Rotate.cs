using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Set In Inspectors")]
    public float angleSpeed = 30f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    void Update()
    {
        gameObject.transform.Rotate(rotationAxis, angleSpeed*Time.deltaTime);
    }
}
