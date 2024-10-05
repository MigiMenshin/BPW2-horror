using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointSystem checkpointSystem; // Reference to the Checkpoint System

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointSystem.SetCheckpoint(transform.position);
            Debug.Log("Player reached checkpoint: " + transform.position);
        }
    }
}
