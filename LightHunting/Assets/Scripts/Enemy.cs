using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float wanderTimer;
    private float timeToChangeDirection = 4f;
    public float detectionRange = 3f;
    public float attackRange = 1f;
    public float moveSpeed = 1f;
    public float chasingSpeed = 2f;
    public float damage;

    public Collider boundaries;
    public Light flashlight;

    private Transform player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within detection range
        if (distanceToPlayer < detectionRange && flashlight.enabled)
        {
            // Player is within detection range

            // Check if the player is within attack range
            if (distanceToPlayer < attackRange)
            {
                // Player is within attack range
                AttackPlayer();
            }
            else
            {
                // Player is within detection range but not attack range
                ChasePlayer();
            }
        }
        else
        {
            // Player is out of detection range
            WanderRandomly();
        }
    }

    private void WanderRandomly()
    {
        if (IsWithinBoundary(transform.position + transform.forward * moveSpeed * Time.deltaTime))
        {
            // Reduce the wander timer
            wanderTimer -= Time.deltaTime;

            if (wanderTimer <= 0f)
            {
                // Generate a random direction for the enemy to move
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

                // Set the enemy's new rotation to face the random direction
                transform.rotation = Quaternion.LookRotation(randomDirection);

                // Reset the wander timer
                wanderTimer = timeToChangeDirection;
            }

            // Move the enemy forward in its current direction
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Update the animator to play the walking animation
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
            animator.SetBool("attack", false);
        }
        else
        {
            // Set the enemy's new rotation
            transform.Rotate(Vector3.up, 180f);

            // Reset the wander timer
            wanderTimer = timeToChangeDirection;

            // Move the enemy forward in its current direction
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void ChasePlayer()
    {
        // Check if the next position is within the boundary
        if (IsWithinBoundary(transform.position + transform.forward * chasingSpeed * Time.deltaTime))
        {
            // Face the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z));

            // Move towards the player
            transform.Translate(Vector3.forward * chasingSpeed * Time.deltaTime);

            // Update the animator to play the running animation
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
            animator.SetBool("attack", false);
        }
        else
        {
            animator.SetBool("walk", true);
            animator.SetBool("run", false);
            animator.SetBool("attack", false);
        }
    }


    private void AttackPlayer()
    {
        // Update the animator to play the attack animation
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
        animator.SetBool("attack", true);
    }

    public void DealDamage()
    {
        player.GetComponent<Health>().Damage(damage);
    }

    private bool IsWithinBoundary(Vector3 position)
    {
        // Check if the position is within the boundary collider
        return boundaries.bounds.Contains(position);
    }

}
