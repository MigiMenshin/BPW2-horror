using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform spawnPointUpstairs; // Assign this in the Inspector
    public GameObject player; // Assign this in the Inspector

    public void SpawnPlayerUpstairs()
    {
        if (player != null && spawnPointUpstairs != null)
        {
            // Move the player to the spawn point's position and rotation
            player.transform.position = spawnPointUpstairs.position;
            player.transform.rotation = spawnPointUpstairs.rotation;
        }
        else
        {
            Debug.LogError("Player or Spawn Point is not assigned.");
        }
    }
}
