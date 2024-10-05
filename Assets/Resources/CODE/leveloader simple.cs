using System.Collections;
using UnityEngine;

public class SimpleLevelLoader : MonoBehaviour
{
    public LevelLoader levelLoader; // Reference to your original LevelLoader script
    public float delayBeforeLoading = 2f; // Duration of the delay in seconds

    public void LoadNextLevel()
    {
        if (levelLoader != null)
        {
            StartCoroutine(LoadNextLevelAfterDelay());
        }
        else
        {
            Debug.LogError("LevelLoader reference is missing!");
        }
    }

    private IEnumerator LoadNextLevelAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeLoading);

        // Call the LoadNextLevel method from the LevelLoader script
        levelLoader.LoadNextLevel();
    }
}
