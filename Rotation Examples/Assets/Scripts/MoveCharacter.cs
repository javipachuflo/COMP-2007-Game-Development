using UnityEngine;
using System.Collections;

/* Move Character
 * uses the CharacterController component for movement
 * moves and rotates a character
 * movement is in the characters facing direction
 */
 [RequireComponent(typeof(CharacterController))]
public class MoveCharacter : MonoBehaviour
{
    // sets the forward and backward movement speed 
    [SerializeField]
    private float moveSpeed = 5.0f;

    // sets rotation speed on the Y axis
    [SerializeField]
    private float rotationSpeed = 50.0f;
    
    // a reference to the character controller component used for movement
    private CharacterController controller;
    
    
    void Start()
    {
        // store the character controller component
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        // get input from the keyboard or joypad on the X and Y axis
        float inputX = Input.GetAxis("Horizontal"); // X axis
        float inputY = Input.GetAxis("Vertical");   // Y axis



        /******* ROTATION *******/
        // store our current Y rotation in degrees (eulerAngles is rotation in degrees)
        float currentYRotation = transform.rotation.eulerAngles.y;
        
        // calculate the turn speed in degrees - multiplied by Time.deltaTime to sync with the update
        // current Y rotation + rotation speed * input X
        float turnSpeed = currentYRotation + rotationSpeed * inputX * Time.deltaTime;

        // set the rotation from the turn speed
        // the Quaternion.Euler method takes degrees as parameters and returns a Quaternion (radians)
        // we can use the Euler method to apply degrees directly to our rotation as radians
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, turnSpeed, 0.0f));



        /******* MOVEMENT *******/
        // we need a forward facing speed, we can use transform.forward for the direction
        // multiply the transform forward by the movespeed and finally our input Y axis
        Vector3 forwardSpeed = transform.forward * moveSpeed * inputY;

        // the CharacterController has a move method to control movement over time
        // we mulliply our forward speed by time.deltaTime to syc with the update
        controller.Move(forwardSpeed * Time.deltaTime);
    }
}

