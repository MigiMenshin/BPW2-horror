using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;             // Reference to the player's Transform
    public float attackDistance = 2f;    // Distance at which the enemy will attack
    public float speed = 5f;             // Speed of the enemy
    public float stoppingDistance = 1f;  // Distance at which the enemy stops moving towards the player while attacking

    private NavMeshAgent agent;          // NavMeshAgent component for movement
    private Animator animator;           // Animator component
    private bool isChasing = false;      // Flag to determine if the enemy should chase the player

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isChasing)
        {
            // Calculate distance between enemy and player
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackDistance)
            {
                // If within attack distance, attack the player
                AttackPlayer();

                // Ensure enemy continues to move closer until within stopping distance
                if (distance > stoppingDistance)
                {
                    agent.SetDestination(player.position);
                    animator.SetBool("isWalking", true);  // Set walking animation
                }
                else
                {
                    agent.ResetPath();  // Stop moving when close enough
                    animator.SetBool("isWalking", false); // Stop walking animation
                }
            }
            else
            {
                // Move towards the player if not within attack distance
                agent.SetDestination(player.position);
                animator.SetBool("isWalking", true);  // Set walking animation
            }
        }
        else
        {
            animator.SetBool("isWalking", false); // Stop walking animation
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            Debug.Log("Player entered trigger zone. Start chasing!");
        }
    }

    void AttackPlayer()
    {
        // Implement attack logic here
        Debug.Log("Attacking player!");
        animator.SetBool("isWalking", false); // Stop walking animation when attacking
        // You can also trigger attack animation here
    }
}
