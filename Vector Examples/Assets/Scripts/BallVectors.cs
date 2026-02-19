using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smooth top down movement without Rigidbodies
public class BallVectors : MonoBehaviour
{
    // the maximum speed we can travel at
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    // the maxumim acceleration we get achieve
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    // our current velocity
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // create a Vector2 for input from a joystick or keys
        Vector2 playerInput = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
        
        // here we make sure the magnitude of player input to 1
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        

        // create a vector3 for the desired velocity
        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y);

        // multiply by our max speed field
        desiredVelocity *= maxSpeed;

        // store our change in speed over time
        // this will clamp our velocity to match our max speed
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        // apply the velocity from our current to desired velocity for the X and Z axes
        // Mathf.MoveTowards limits the amount we can move per update using a delta (maxSpeedChange)
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        // make sure our Y velocity is zero for top down movement
        velocity.y = 0;
        
        // store the calulated velocity over time
        Vector3 displacement = velocity * Time.deltaTime;

        // apply our calculated velocty to the transform
        transform.position += displacement;
        
    }
    
}
