using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjFollowPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float moveSpeed = 3f;  // Speed at which the NPC follows the player
    public float followDistance = 3f;  // Desired distance between NPC and player

    private bool isFollowing = false;

    void Update()
    {
        if (isFollowing && player != null)
        {
            // Calculate the direction to the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;  // Keep the NPC at the same height as the player (optional)

            // Check if the distance between NPC and player is greater than followDistance
            if (direction.magnitude > followDistance)
            {
                // Rotate towards the player
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                // Move towards the player
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // When the player collides with the NPC, start following
            isFollowing = true;

            // Set the player as the target
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // When the player moves away, stop following
            isFollowing = false;

            // Clear the player reference
            player = null;
        }
    }
}
