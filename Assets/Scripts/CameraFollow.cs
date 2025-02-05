using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject playerToFollow;
    [SerializeField] private float smoothSpeed = 3f; // the higher the smoothSpeed, the faster the camera catches up
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -20); // need a z offset so camera isn't "in" player

    void Start()
    {
        transform.position = playerToFollow.transform.position + offset; // make sure the camera doesn't need to follow the player when the game is started
    }

    void LateUpdate()
    {
        if (playerToFollow == null) return; // in case player object is destroyed

        Vector3 targetPosition = playerToFollow.transform.position + offset; // get the player's position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); // make the camera's position go to the player's position
    }
}