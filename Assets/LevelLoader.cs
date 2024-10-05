using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private bool timelineEnded = false; // Flag to check if timeline has ended

    private void Update()
    {
        // Check for mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse click detected, attempting to load next level");
            LoadNextLevel();
        }
    }

    public void OnEndOfTimeline()
    {
        // Set the timelineEnded flag to true
        timelineEnded = true;
        Debug.Log("End of Timeline reached, loading next level immediately");

        // Immediately load the next level
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        // If the timeline has ended or the player presses the mouse button, load the scene
        if (!timelineEnded)
        {
            timelineEnded = true; // Prevent multiple triggers
        }

        StartCoroutine(LoadLevelCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevelCoroutine(int levelIndex)
    {
        // Play the transition animation
        transition.SetTrigger("Start");

        // Wait for the duration of the transition before loading the next scene
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }
}
