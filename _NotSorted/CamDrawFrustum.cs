using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CamDrawFrustum : MonoBehaviour
{
    private Camera Cam = null;
    public bool ShowCamGizmo = true;

    private void Awake()
    {
        Cam = GetComponent<Camera>();
    }

    private void OnDrawGizmos()
    {
        if (!ShowCamGizmo) return;

        //Get Game Window size
        Vector2 v = CamDrawFrustum.GetGameViewSize();
        float GameAspect = v.x / v.y; //Calculate window borders ratio
        float FinalAspect = GameAspect / Cam.aspect;

        Matrix4x4 LocalToWorld = transform.localToWorldMatrix;
        Matrix4x4 ScaleMatrix = Matrix4x4.Scale(new Vector3(Cam.aspect * (Cam.rect.width / Cam.rect.height), FinalAspect, 1));
        Gizmos.matrix = LocalToWorld * ScaleMatrix;
        Gizmos.DrawFrustum(transform.position, Cam.fieldOfView, Cam.nearClipPlane, Cam.farClipPlane, FinalAspect);
        Gizmos.matrix = Matrix4x4.identity; //set default matrix
    }

    public static Vector2 GetGameViewSize()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView, UnityEditor");
        System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        return (Vector2)GetSizeOfMainGameView.Invoke(null, null);
    }
}
