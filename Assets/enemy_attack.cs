using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;           // Reference to the player's Transform
    public float attackDistance = 2f;  // Distance at which the enemy will attack
    public float speed = 5f;           // Speed of the enemy

    private NavMeshAgent agent;        // NavMeshAgent component for movement
    private bool playerInTrigger = false; // Flag to determine if the player has entered the trigger zone

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (playerInTrigger)
        {
            // Calculate distance between enemy and player
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackDistance)
            {
                // If within attack distance, attack the player
                AttackPlayer();
            }
            else
            {
                // Move towards the player if not within attack distance
                agent.SetDestination(player.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            Debug.Log("Player entered trigger zone");
            // Start the attack behavior immediately upon entering the zone
            StartAttack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            Debug.Log("Player exited trigger zone");
        }
    }

    void StartAttack()
    {
        // Implement logic to start attacking behavior here
        Debug.Log("Starting to attack player!");
        // Optional: You can add logic here to immediately start the attack
    }

    void AttackPlayer()
    {
        // Implement attack behavior here
        Debug.Log("Attacking player!");
    }
}
