using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneLoaderspecific : MonoBehaviour
{
    // This will hold a reference to the SceneAsset, set this in the Unity Inspector
#if UNITY_EDITOR
    [SerializeField] private SceneAsset sceneAsset;
#endif

    // This will store the scene name for runtime use
    [SerializeField] private string sceneName;

    private void OnValidate()
    {
#if UNITY_EDITOR
        // If a scene asset is assigned, update the scene name to the asset's name
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;
        }
#endif
    }

    // This function will be called when the button is pressed
    public void LoadScene()
    {
        // Check if the scene name is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is empty. Please specify a scene in the Inspector.");
        }
    }
}
