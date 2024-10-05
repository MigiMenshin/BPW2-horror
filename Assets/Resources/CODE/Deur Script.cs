using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public LevelLoader levelLoader;     // Reference to the LevelLoader script
    public AudioSource doorAudio;       // Audio source for the door sound
    public float audioPlayTime = 2f;    // Time to wait for the audio to play
    public GameObject worldSpaceText;   // Reference to the world space text object

    private bool playerNear = false;    // To check if the player is near the door

    private void Start()
    {
        // Ensure the text is hidden at the start
        if (worldSpaceText != null)
        {
            worldSpaceText.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player is near and presses either the "E" key or the "Square" button (joystick button 0)
        if (playerNear && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            StartCoroutine(PlayAudioAndLoadScene());
        }
    }

    private IEnumerator PlayAudioAndLoadScene()
    {
        // Play the door audio
        if (doorAudio != null)
        {
            doorAudio.Play();
        }

        // Wait for the audio to finish or a specified time
        yield return new WaitForSeconds(audioPlayTime);

        // Call the LoadNextLevel method from LevelLoader to start the transition
        levelLoader.LoadNextLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Player near the door");

            // Show the world space text
            if (worldSpaceText != null)
            {
                worldSpaceText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            Debug.Log("Player left the door area");

            // Hide the world space text
            if (worldSpaceText != null)
            {
                worldSpaceText.SetActive(false);
            }
        }
    }
}
