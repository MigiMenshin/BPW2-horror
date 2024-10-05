using UnityEngine;

public class LookAtCameraCenter : MonoBehaviour
{
    private Camera activeCamera;

    void Start()
    {
        // Find and assign the active camera
        UpdateActiveCamera();
    }

    void Update()
    {
        if (activeCamera != null)
        {
            // Calculate direction from the object to the camera
            Vector3 direction = activeCamera.transform.position - transform.position;

            // Create a rotation that makes the object face the camera
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Apply the rotation to the object
            transform.rotation = rotation;
        }
    }

    public void UpdateActiveCamera()
    {
        Camera[] cameras = Camera.allCameras;
        foreach (Camera cam in cameras)
        {
            if (cam.isActiveAndEnabled)
            {
                activeCamera = cam;
                return;
            }
        }

        Debug.LogError("No active camera found. Please ensure there is an active camera.");
    }
}
