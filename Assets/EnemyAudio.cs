using UnityEngine;

public class EnemyAudioTrigger : MonoBehaviour
{
    public AudioSource[] audioSources; // Array of AudioSources
    public AudioClip[] attackAudioClips; // Array of audio clips
    private bool hasPlayed = false; // Flag to check if audio has been triggered

    private void Start()
    {
        // Ensure the number of AudioSources matches the number of audio clips
        if (audioSources.Length != attackAudioClips.Length)
        {
            Debug.LogWarning("Number of AudioSources and AudioClips must be the same.");
        }

        // Ensure each AudioSource is set up correctly
        foreach (var source in audioSources)
        {
            source.playOnAwake = false; // Prevent audio from playing automatically
            source.loop = true; // Set to loop
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Set the flag to true to ensure the audio only starts once
            hasPlayed = true;

            // Play each audio clip on its corresponding AudioSource
            for (int i = 0; i < audioSources.Length; i++)
            {
                if (i < attackAudioClips.Length)
                {
                    audioSources[i].clip = attackAudioClips[i];
                    audioSources[i].Play();
                }
            }
        }
    }
}
