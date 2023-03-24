using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPrimitivesInView : MonoBehaviour
{
    public Camera cam;

    int primitivesInView = 0;
    Quaternion lastCameraRotation;
    List<Renderer> visibleRenderers = new List<Renderer>(); // Declare the list of visible renderers

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        if (cam != null && cam.transform.rotation != lastCameraRotation) // Check if the camera's rotation has changed
        {
            printVisiblePrimitiveCount();
        }
    }

    /// <summary>
    /// Counts the number of primitives in view of the main camera and outputs the count to the Debug Log.
    /// Also highlights Primitives in viewing-Frustum
    /// </summary>
    /// adapted from https://docs.unity3d.com/ScriptReference/GeometryUtility.TestPlanesAABB.html
    void printVisiblePrimitiveCount()
    {
        lastCameraRotation = cam.transform.rotation;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam); // Get the camera's frustum planes
        Renderer[] renderers = FindObjectsOfType<Renderer>(); // Find all renderers in the scene

        primitivesInView = 0;
        foreach (Renderer renderer in renderers)
        {
            if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds)) // Check if the renderer is within the frustum
            {
                primitivesInView++;
                foreach (Material material in renderer.materials)
                {
                    material.color = Color.yellow; // Change the color of the material to yellow
                }
                if (!visibleRenderers.Contains(renderer))
                {
                    visibleRenderers.Add(renderer); // Add the renderer to the list of visible renderers
                }
            }
            else
            {
                if (visibleRenderers.Contains(renderer))
                {
                    visibleRenderers.Remove(renderer); // Remove the renderer from the list of visible renderers
                    foreach (Material material in renderer.materials)
                    {
                        material.color = Color.white; // Restore the color of the material to white
                    }
                }
            }
        }

        Debug.Log("Primitives in view: " + primitivesInView);
    }

}
