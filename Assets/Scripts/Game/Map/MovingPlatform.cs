using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Movement Settings")]
    [SerializeField] private Vector2 startPoint; // Starting position (world coordinates)
    [SerializeField] private Vector2 endPoint;   // Ending position (world coordinates)
    [SerializeField] private float speed = 2f;   // Speed of the platform
    [SerializeField] private bool loop = false;  // Whether the platform loops
    [SerializeField] private bool pingPong = true; // Whether the platform moves back and forth

    private Vector2 targetPosition; // Current target position
    private bool movingToEnd = true; // Direction of movement (used for ping-pong)

    private void Start()
    {
        // Set the initial target position
        transform.position = startPoint;
        targetPosition = endPoint;
    }

    private void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            HandleTargetReached();
        }
    }

    private void HandleTargetReached()
    {
        if (pingPong)
        {
            // Reverse direction for ping-pong movement
            movingToEnd = !movingToEnd;
            targetPosition = movingToEnd ? endPoint : startPoint;
        }
        else if (loop)
        {
            // Loop back to the start
            targetPosition = targetPosition == endPoint ? startPoint : endPoint;
        }
        else
        {
            // Stop moving when the target is reached
            enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the start and end points for visualization in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(startPoint, 0.2f);
        Gizmos.DrawSphere(endPoint, 0.2f);
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
