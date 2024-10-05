using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the Inspector with the Audio Source component

    private bool isPlaying = false; // Flag to track if audio is playing

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("Audio Source is not assigned!");
        }
    }

    public void PlayAudio()
    {
        if (!isPlaying && audioSource != null)
        {
            StartCoroutine(PlayAudioCoroutine());
        }
    }

    IEnumerator PlayAudioCoroutine()
    {
        isPlaying = true; // Set the flag to true to indicate audio is playing
        audioSource.Play(); // Play the audio

        // Wait until the audio has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        isPlaying = false; // Reset the flag to allow for retriggering
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayAudio();
        }
    }
}
