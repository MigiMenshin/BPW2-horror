using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class TimelineCameraController : MonoBehaviour
{
    public PlayableDirector timeline; // Assign this in the Inspector
    public CinemachineVirtualCamera[] virtualCameras; // Assign the Cinemachine virtual cameras used in the Timeline

    void Start()
    {
        // Subscribe to the Timeline's stopped event
        timeline.stopped += OnTimelineStopped;
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        // Deactivate all Cinemachine virtual cameras
        foreach (CinemachineVirtualCamera vcam in virtualCameras)
        {
            if (vcam != null)
            {
                vcam.gameObject.SetActive(false);
            }
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to avoid potential memory leaks
        timeline.stopped -= OnTimelineStopped;
    }
}
