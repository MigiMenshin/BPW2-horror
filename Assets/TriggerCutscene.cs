using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject player; // Reference to the player GameObject
    public GameObject playerStandIn; // Optional: Reference to the stand-in GameObject
    public AudioSource[] audioSourcesToMute; // Array of AudioSources to mute during the timeline

    private bool hasTriggered = false; // Flag to ensure the timeline is triggered only once

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            if (playableDirector != null)
            {
                Debug.Log("Player entered the trigger zone, playing timeline.");

                // Disable the player GameObject and optionally enable a stand-in
                if (player != null)
                {
                    player.SetActive(false);
                }

                if (playerStandIn != null)
                {
                    playerStandIn.SetActive(true); // Enable the stand-in if used
                }

                // Mute specified audio sources
                MuteAudioSources(true);

                playableDirector.Play();
                playableDirector.stopped += OnPlayableDirectorStopped; // Subscribe to the stopped event
                hasTriggered = true;
            }
            else
            {
                Debug.LogWarning("PlayableDirector is not assigned in the inspector!");
            }
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Re-enable the player GameObject and disable the stand-in
        if (player != null)
        {
            player.SetActive(true);
        }

        if (playerStandIn != null)
        {
            playerStandIn.SetActive(false); // Disable the stand-in if used
        }

        // Unmute specified audio sources
        MuteAudioSources(false);

        // Unsubscribe from the event to avoid memory leaks
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }

    void MuteAudioSources(bool mute)
    {
        foreach (AudioSource source in audioSourcesToMute)
        {
            source.mute = mute;
        }
    }
}
// script made by Miguel Mensinga