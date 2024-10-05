using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public float exitDelay = 1f;  // Duration to wait before exiting the game

    // Call this method to start the coroutine that exits the game
    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }

    private IEnumerator ExitGameCoroutine()
    {
        // Optional: Play exit sound or animation here
        // Example: PlayExitSound();

        // Wait for the specified delay
        yield return new WaitForSeconds(exitDelay);

        // Exit the game
        Application.Quit();

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
