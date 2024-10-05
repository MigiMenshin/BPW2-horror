using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{
    public Transform Player;
    public CinemachineVirtualCamera activeCam;
    public CinemachineVirtualCamera followCam;
    private static List<CinemachineVirtualCamera> allCams = new List<CinemachineVirtualCamera>();

    private void Awake()
    {
        // Add the camera to the list of all cameras if it's not null and not already in the list
        if (activeCam != null && !allCams.Contains(activeCam))
        {
            allCams.Add(activeCam);
        }
    }

    private void Start()
    {
        if (followCam != null)
        {
            followCam.Priority = 10;
        }
        if (activeCam != null)
        {
            activeCam.Priority = 0;
        }

        // Check if the player is within the camera's trigger zone at the start
        Collider[] colliders = Physics.OverlapSphere(Player.position, 0.1f);
        foreach (var collider in colliders)
        {
            if (collider == GetComponent<Collider>())
            {
                SetActiveCamera();
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone: " + gameObject.name);
            SetActiveCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone: " + gameObject.name);
            ResetFollowCamera();
        }
    }

    private void SetActiveCamera()
    {
        if (activeCam == null)
        {
            Debug.LogWarning("Active camera is not set.");
            return;
        }

        // Set the priority of all cameras to 0
        foreach (var cam in allCams)
        {
            if (cam != null)
            {
                cam.Priority = 0;
            }
        }

        // Set the priority of the active camera to 1
        activeCam.Priority = 1;
        if (followCam != null)
        {
            followCam.Priority = 0;
        }
        Debug.Log("Active camera set to: " + activeCam.name);
    }

    private void ResetFollowCamera()
    {
        if (followCam != null)
        {
            followCam.Priority = 10;
        }
        if (activeCam != null)
        {
            activeCam.Priority = 0;
        }
        Debug.Log("Follow camera reset.");
    }
}
