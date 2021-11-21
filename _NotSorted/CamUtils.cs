using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamUtils : MonoBehaviour
{
    //Checks object for being in camera view 
    public static bool IsRenderedInCameraFrustum (Renderer Renderable,Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, Renderable.bounds);
    }
    //Checks poin for being in camera view, set poin coordinates in camerf view screen system
    public static bool IsPointInCameraFrustum (Vector3 point, Camera cam, out Vector3 ViewPortLoc)
    {
        Bounds b = new Bounds(point, Vector3.zero);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        bool isVisible = GeometryUtility.TestPlanesAABB(planes, b);
        ViewPortLoc = Vector3.zero;
        if (isVisible)
        {
            ViewPortLoc = cam.WorldToViewportPoint(point);
        }
        return isVisible;
    }

    //Check visibility of object for camera

    public static bool IsVisible (Renderer rend, Camera cam)
    {
        if (!CamUtils.IsRenderedInCameraFrustum(rend, cam))
        {
            return false;            
        }

        if (Physics.Linecast(rend.transform.position, cam.transform.position)) //may send false positive check when an object moves away from the camera
        {
            return false;
        }

        return true;
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.width, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }
}
