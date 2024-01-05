using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncontrollableCameraFloat : MonoBehaviour
{
    // Movement parameters
    public float freeRoamSpeed = 0.1f;     // Adjust speed of free-roaming movement
    public float turnSpeed = 10f;          // Adjust speed of free-roaming turning
    public float desiredHeight = 5f;       // Set desired camera height

    // Movement variables
    private Vector3 freeRoamVelocity;

    // Initialize nextMovementTime in Start() instead of the constructor
    private float nextMovementTime = 2f; // Initial value, will be updated in Start()
    private float movementInterval = 2f;  // Minimum interval between direction changes

    void Start()
    {
        // Set initial random velocity for free-roaming
        freeRoamVelocity = Random.insideUnitSphere * freeRoamSpeed;

        // Initialize nextMovementTime using Time.time here
        nextMovementTime = Time.time + movementInterval;
    }

    void Update()
    {
        // Randomly change direction every few seconds
        if (Time.time > nextMovementTime)
        {
            freeRoamVelocity = Random.insideUnitSphere * freeRoamSpeed;
            nextMovementTime = Time.time + movementInterval;
        }

        // Apply free-roaming movement and maintain desired height
        transform.position = new Vector3(transform.position.x, desiredHeight, transform.position.z) + freeRoamVelocity * Time.deltaTime;

        // Rotate camera to face direction of movement
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(freeRoamVelocity), turnSpeed * Time.deltaTime);

        // (Optional) Limit movement area (uncomment and adjust as needed)
        /*
        Vector3 minBounds = new Vector3(-10f, 5f, -10f);
        Vector3 maxBounds = new Vector3(10f, 5f, 10f);

        transform.position = Vector3.Clamp(transform.position, minBounds, maxBounds);
        */
    }
}
