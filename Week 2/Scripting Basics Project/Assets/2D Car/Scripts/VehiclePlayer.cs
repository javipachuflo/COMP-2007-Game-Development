/*
 * VehiclePlayer
 * 
 * public variables
 *  moveSpeed
 *      speed of left and right movement speed of the vehicle
 *      moveSpeed is a float, a type of decimal number
 *      higher values move the vehicle faster
 *      
 *  frontWheel, backWheel     
 *      the connection between the wheel and the vehicle
 *      are a type of WheelJoint2D
 *      WheelJoint2D allows a GameObject wheel rotation in 2D
 *      WheelJoint2D includes a suspension system and a "motor" to rotate the wheel
 *      link to online reference https://docs.unity3d.com/ScriptReference/WheelJoint2D.html
 *
 * private variables
 *  motor
 *      used to "drive" a WheelJoint2D by applying rotation
 *      is a type of JointMotor2D
 *      link to online reference https://docs.unity3d.com/ScriptReference/JointMotor2D.html
 *      has 2 values 
 *          "maxMotorTorque" to set the maximum rotation speed of the wheel
 *          "motorSpeed" to set the current rotation speed of the wheel
 *          
 *          
 * private methods 
 *  Start
 *      when the game begins, this method will run only once
 *      we create and setup the motor here, ready for use in the game
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
 *  
 *  Update
 *      Runs constantly while the GameObject this script is attached to is in the game
 *      Update runs as fast as the computer will allow, often 30-60 times per second or much more
 *      we get our movement input and turn the vehicles wheels using the motor in this method
 *      link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
*/

using UnityEngine;

public class VehiclePlayer : MonoBehaviour
{
    // speed of left and right movement speed of the vehicle
    // adjust this value in the Unity Editor
    public float moveSpeed = 100;

    // a reference to the front wheel "WheelJoint2D" component on this GameObject
    // in the scene this is the wheel on the right side of the vehicle
    // link to online reference https://docs.unity3d.com/ScriptReference/WheelJoint2D.html
    public WheelJoint2D frontWheel;

    // a reference to the back wheel "WheelJoint2D" component on this GameObject
    // in the scene this is the wheel on the left side of the vehicle
    public WheelJoint2D backWheel;

    // the motor used to drive both our wheels
    // link to online reference https://docs.unity3d.com/ScriptReference/JointMotor2D.html
    private JointMotor2D motor;

    // when the game begins, this method will run only once
    // we create and setup our motor here
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
    private void Start()
    {
        // create a new "JointMotor2D" and add it to the motor variable
        motor = new JointMotor2D();

        // set the "maxMotorTorque" of our motor to ten thousand
        // this is actually the default setting for "WheelJoint2D"
        motor.maxMotorTorque = 10000;
    }

    // this method runs constantly while the GameObject this script is attached to is in the game
    // link to online reference https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
    private void Update()
    {
        // get our left/right key presses using "GetAxis"
        // moveInput will be a number between -1 and 1
        // left key pressed will be -1
        // right key pressed will be 1
        // no keys pressed will be zero
        float moveInput = Input.GetAxis("Horizontal");

        // here we set the rotation speed of our motor "motor.motorSpeed"
        // we set the speed to minus moveInput (-moveInput) so the wheel rotates at clockwise for the left key and anti-clockwise for the right key
        // we multiply the moveInput by our moveSpeed variable, allowing the wheels to rotate quickly in both directions
        motor.motorSpeed = -moveInput * moveSpeed;

        // here we apply the motor to our front and rear wheels, driving their rotation speed
        // the "WheelJoint2D" component requires a "JointMotor2D" to apply rotation to the wheel
        // NOTE: we drive both wheels from the same motor, we don't have to do this, separate motors can be made for each wheel!
        frontWheel.motor = motor;
        backWheel.motor = motor;
    }
}
