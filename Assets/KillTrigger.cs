using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public DeathHandler deathHandler; // Reference to the DeathHandler script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the death sequence
            deathHandler.HandlePlayerDeath();
        }
    }
}
