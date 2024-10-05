using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISoundManager : MonoBehaviour
{
    public AudioSource navigationSoundSource;
    public AudioSource selectionSoundSource;

    public AudioClip navigationClip;  // Assign in Inspector
    public AudioClip selectionClip;   // Assign in Inspector

    private void Start()
    {
        // Ensure the AudioSources are set up
        if (navigationSoundSource != null)
        {
            navigationSoundSource.clip = navigationClip;
        }

        if (selectionSoundSource != null)
        {
            selectionSoundSource.clip = selectionClip;
        }
    }

    private void Update()
    {
        // Detect navigation between buttons (based on EventSystem's selected object)
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            PlayNavigationSound();
        }

        // Detect button selection (e.g., pressing "Submit" button)
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            PlaySelectionSound();
        }
    }

    public void PlayNavigationSound()
    {
        if (navigationSoundSource != null && navigationSoundSource.clip != null)
        {
            navigationSoundSource.Play();
        }
    }

    public void PlaySelectionSound()
    {
        if (selectionSoundSource != null && selectionSoundSource.clip != null)
        {
            selectionSoundSource.Play();
        }
    }
}
