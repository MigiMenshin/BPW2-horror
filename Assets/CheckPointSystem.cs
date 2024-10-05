using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;

    void Start()
    {
        // Set the initial checkpoint position to the player's start position
        lastCheckpointPosition = transform.position;
    }

    // This method will be called whenever the player reaches a new checkpoint
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
        Debug.Log("Checkpoint set at: " + checkpointPosition);
    }

    // This method will be called when the player dies to respawn them
    public void RespawnPlayer(Transform player)
    {
        player.position = lastCheckpointPosition;
        Debug.Log("Player respawned at: " + lastCheckpointPosition);
    }
}
