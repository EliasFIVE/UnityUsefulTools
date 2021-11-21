using UnityEngine;

public class CameraFollower : MonoBehaviour
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
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IfGameInRunningState())
                FollowTarget();
        }
        else
            FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 dest = thisTransform.position = Vector3.SmoothDamp(thisTransform.position, targetTransform.position, ref velocity, posDamp * Time.deltaTime);
        thisTransform.position = dest - thisTransform.forward * distanceFromTarget;
        thisTransform.position = new Vector3(thisTransform.position.x, camHeight, thisTransform.position.z);
        thisTransform.LookAt(dest);
    }

}
