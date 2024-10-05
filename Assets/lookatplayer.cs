using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5f; // Speed at which the object rotates towards the player

    void Start()
    {
        // Optionally find the player by tag if not assigned in the Inspector
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }

        if (player == null)
        {
            Debug.LogError("Player not found. Please assign the player object or ensure it has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Get the direction to the player
            Vector3 direction = player.position - transform.position;

            // Only apply rotation if there is a valid direction (to prevent errors)
            if (direction != Vector3.zero)
            {
                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Smoothly rotate towards the player
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
