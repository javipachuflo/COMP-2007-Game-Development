using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* EXERCISE 
 * Add code to make the rigidbody rotate and jump from user input
 * 
 * TASK 1:
 * - Get the Rigidbody component
 * - At the bottom of the Start method use GetComponent to get the Rigidbody component and assign it to the field named "body"
 * - Look at the documentation link below for instructions on using GetComponent
 *  https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Component.GetComponent.html
 * - HINT: body = GetComponent Rigidbody
 * 
 * 
 * TASK 2 part a and b:
 * - In the Update method, Get the Horizontal and Vertical Input from Unity's Input Manager
 * - Look at the GetAxis method link below for instructions
 *   https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Input.GetAxis.html
 * - inputs are set from the editor (Edit -> Project Settings -> Input Manager)
 *   https://docs.unity3d.com/2021.2/Documentation/Manual/class-InputManager.html
 * - HINT: xInput = Input GetAxis Horizontal
 *  
 *  
 *  TASK 3:
 *  - In the Update method, Add the torque variable to the Rigidbody component using AddTorque
 *  - Look at the AddTorque method link below for instructions
 *    https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody.AddTorque.html
 *  - HINT: body AddTorque torque
 * 
 * 
 * TASK 4:
 * - In the Update method, get the Fire1 Button Input from Unity's Imput Manager
 * - Look at the GetButton method link below for instructions
 *   https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Input.GetButton.html
 * - inputs are set from the editor (Edit -> Project Settings -> Input Manager)
 *   https://docs.unity3d.com/2021.2/Documentation/Manual/class-InputManager.html
 * - HINT: fire1Pressed = Input GetButton Fire1
 * 
 * 
 * TASK 5:
 * - In the Update method, Add the jumpForce variable to the Rigidbody component using AddForce
 * - Look at the GetButton method link below for instructions
 *   https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody.AddForce.html
 * - Use ForceMode.Impulse as the second parameter
 *   https://docs.unity3d.com/2021.2/Documentation/ScriptReference/ForceMode.html
 * - HINT: body AddForce jumpForce ForceMode.Impulse
 * 
 */
public class ControllerEXERCISE : MonoBehaviour
{
    // This field sets the move speed of the player ball
    [Range(0, 50f)]
    public float speed = 0.5f;

    // this field sets the jump power
    [Range(0, 15)]
    public float jumpPower = 0.5f;

    // stores a reference to the rigidbody component
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody.html
    public Rigidbody body;

    // stores the movement input on the horizontal axis
    private float xInput = 0;

    // stores the movement input on the vertical axis
    private float yInput = 0;

    // stores the jump button input
    private bool fire1Pressed = false;

    void Start()
    {
        // TASK 1: use GetComponent to fill our "body" field in the code below
        // NOTE: specify the type of the component in the angle backets <Rigibody>
        body = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // TASK 2:
        // part a: get the Horizontal axis input and assign it to xInput below
        // HINT: xInput = Input GetAxis Horizontal


        

        // TASK 2:
        // part b: get the Vertical axis input and assign it to yInput below
        // HINT: yInput = Input GetAxis Vertical




        // torque is a vector 3 for the rotational force in each direction (x,y,z) created from our input above
        // NOTE: we are swapping and adjusting the x and y values to get the correct direction of rotational force
        Vector3 torque = new Vector3(yInput, 0, -xInput);


        // TASK 3:
        // add the torque to our rigidbody as a rotational force using AddTorque below
        // HINT: body AddTorque torque



        // TASK 4:
        // get the Fire1 Button input from and assign it to fire1Pressed below
        // HINT: fire1Pressed = Input GetButton Fire1



        // If Fire1 is pressed, apply the jump force to the rigidbody
        if (fire1Pressed)
        {
            // jumpForce is a vector 3 for the upwards force to be applied for jumping in (x,y,z)
            // NOTE: we only add a value for the Y (upward) direction, which is the jumpPower field 
            Vector3 jumpForce = new Vector3(0, jumpPower, 0);


            // TASK 5:
            // add the jump force to our rigidbody as a positional force using AddForce below
            // Use ForceMode.Impulse as the second parameter to add a strong, instant force, suitable for jumping
            // HINT: body AddForce jumpForce ForceMode.Impulse



        }
    }
}
