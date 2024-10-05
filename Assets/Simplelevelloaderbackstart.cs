using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class SimpleLevelLoaderback : MonoBehaviour
{
    public string sceneName; // Name of the scene to load
    public float delayBeforeLoading = 2f; // Duration of the delay in seconds

    public void LoadSpecificScene()
    {
        // Start the coroutine to load the scene after a delay
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeLoading);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
