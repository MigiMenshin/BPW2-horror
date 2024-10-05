using UnityEngine;

public class OneTimeAudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Assign this in the Inspector
    private bool hasPlayed = false; // Flag to track if the audio has already played

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is from the player or any other specific object
        if (other.CompareTag("Player") && !hasPlayed)
        {
            if (audioSource != null)
            {
                audioSource.Play(); // Play the audio
                hasPlayed = true;   // Set the flag to true so it won’t play again
            }
            else
            {
                Debug.LogError("Audio Source is not assigned!");
            }
        }
    }
}
