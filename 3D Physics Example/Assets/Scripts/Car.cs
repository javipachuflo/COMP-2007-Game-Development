using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Car
 * A simple car controller using WheelCollider components
 * 
 */ 
public class Car : MonoBehaviour
{
    // the amount of forward rotational force applied to the wheel
    public float torque = 200;

    // the maximum angle the wheel can turn into corners
    public float steerAngleMax = 30;

    // the wheelColliders a required to be children of this transform
    private WheelCollider[] wheels;
    
    void Start()
    {
        // search the children of the transform for the WheelColliders
        wheels = transform.GetComponentsInChildren<WheelCollider>();
    }
    
    void FixedUpdate()
    {
        // forward input (or drive) applied to the wheels
        float accelInput = Input.GetAxis("Vertical");

        // turn input applied to the wheels
        // multiplied by the steer angle to get the degrees
        float turnInput = Input.GetAxis("Horizontal") * steerAngleMax;

        // loop through all of the wheels to apply acceleration and turn
        for (int i = 0; i < wheels.Length; i++)
        {
            // calculate the forward turn to move the vehicle
            float forwardTurn = torque * accelInput;
            
            // if the current wheel is a fron wheel, apply the steering turn input
            if (wheels[i].CompareTag("Front Wheel"))
            {
                // WheelCollider has a steering angle in degrees we can use to steer
                wheels[i].steerAngle = turnInput;
            }

            // apply the forward turn or torque input
            // WheelCollider has a motor torque setting to apply our current torque
            wheels[i].motorTorque = forwardTurn;

            // WheelCollider has a GetWorldPose method that calculates the correct position and rotation of the wheel
            // we can use this for our wheel graphics to position them exactly
            wheels[i].GetWorldPose(out Vector3 wheelPosition, out Quaternion wheelRotation);

            // get the current wheel graphics
            // will be the first child of our WheelCollider transform
            Transform wheelGraphics = wheels[i].transform.GetChild(0);

            // set the position of the wheel
            wheelGraphics.position = wheelPosition;

            // store the rotation so we adjust it
            Vector3 angles = wheelRotation.eulerAngles;

            // we add an offset here to roatate the wheel correctly on the Z Axis
            angles.z += 90;

            // apply the rotation to the wheel graphic
            wheelGraphics.eulerAngles = angles;
            
        }
    }
}
