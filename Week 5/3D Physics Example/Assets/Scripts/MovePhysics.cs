using UnityEngine;
using System.Collections;

/* 
 * MovePhysics
 * add a force to a Rigidbody using standard input
 * 
 */ 
[RequireComponent(typeof(Rigidbody))]
public class MovePhysics : MonoBehaviour 
{
    // the movement speed of the Rigidbody
    [SerializeField]
    private float speed = 5.0f;

    // a reference to the Rigidbody
    private Rigidbody body;
    
    void Start () 
    {
        // store our Rigidbody reference
        // NOTE: we ensure this with the RequireComponent attribute
        body = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () 
    {
        // input values from a keyboard or joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // create a vector3 for the input direction
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);

        // normalise our input direction to keep the values below zero
        inputDirection.Normalize();

        // create a force vector3 by multiplying the input direction by the speed field
        Vector3 force = inputDirection * speed;

        // here we use the AddForce method on the Rigidbody to add a force in a direction
        // NOTE: we use Time.deltaTime to sync the force to the update
        body.AddForce(force * Time.deltaTime);
	}
}
