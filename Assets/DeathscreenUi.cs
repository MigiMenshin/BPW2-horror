using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement namespace

public class DeathHandler : MonoBehaviour
{
    public GameObject deathScreenUI; // Reference to the Death Screen UI

    private bool isDead = false; // Flag to check if the player is dead

    void Start()
    {
        // Ensure the death screen is not visible at the start
        deathScreenUI.SetActive(false);
    }

    public void HandlePlayerDeath()
    {
        if (!isDead)
        {
            isDead = true;
            // Activate the death screen UI
            deathScreenUI.SetActive(true);
            // Pause the game
            Time.timeScale = 0f;
        }
    }

    public void ReloadScene()
    {
        // Deactivate the death screen UI
        deathScreenUI.SetActive(false);
        // Unpause the game
        Time.timeScale = 1f;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isDead = false;
    }
}
