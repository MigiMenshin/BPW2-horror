using UnityEngine;
using TMPro;
using UnityEngine.UI; // Include if your panel is an Image component
using System.Collections;

public class Subtitles : MonoBehaviour
{
    public SubtitleLine[] subtitleLines; // Array of subtitle lines to display
    public TextMeshProUGUI subtitlesText; // Reference to the TextMeshProUGUI component for displaying subtitles
    public GameObject panel; // Reference to the panel UI element

    private AudioSource audioSource; // Reference to the AudioSource component
    public bool subtitlesOnTriggerEnter = false; // Checkbox to choose trigger enter or object enable
    private bool subtitlesStarted = false; // Flag to track if subtitles have been started

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the same GameObject

        if (!subtitlesOnTriggerEnter)
        {
            StartSubtitles();
        }
    }

    void OnEnable()
    {
        if (!subtitlesStarted && !subtitlesOnTriggerEnter)
        {
            StartSubtitles();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (subtitlesOnTriggerEnter && !subtitlesStarted)
        {
            StartSubtitles();
        }
    }

    void StartSubtitles()
    {
        subtitlesStarted = true;
        StartCoroutine(SubtitleCoroutine());
    }

    IEnumerator SubtitleCoroutine()
    {
        foreach (var line in subtitleLines)
        {
            if (subtitlesText != null)
            {
                subtitlesText.text = line.text; // Display the subtitle text
                subtitlesText.gameObject.SetActive(true); // Show the subtitle
            }

            if (panel != null)
            {
                panel.SetActive(true); // Show the panel
            }

            yield return new WaitForSecondsRealtime(line.duration); // Wait for the duration

            if (subtitlesText != null)
            {
                subtitlesText.gameObject.SetActive(false); // Hide the subtitle
            }

            if (panel != null)
            {
                panel.SetActive(false); // Hide the panel
            }
        }

        subtitlesStarted = false; // Reset subtitles started flag for potential reuse
    }
}

[System.Serializable]
public class SubtitleLine
{
    public string text; // The subtitle text to display
    public float duration; // Duration (in seconds) for which this subtitle should be displayed
}
