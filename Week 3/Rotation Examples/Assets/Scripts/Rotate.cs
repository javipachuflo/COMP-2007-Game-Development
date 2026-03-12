using UnityEngine;
using System.Collections;

/* Rotate
 * three strategies for rotating transforms in unity
 * 
 * 1. local rotation
 * 2. world roation
 * 3. orbiting a target
 * 
 */ 
public class Rotate : MonoBehaviour
{
    // the target used for the orbiting example code
    [SerializeField]
    private Transform target;

    // the direction we wnat to rotate in
    // set an axis to 1 to rotate along that axis
    [SerializeField]
    private Vector3 direction = Vector3.zero;

    // rotation speed in degrees per update frame
    [SerializeField]
    private float rotationSpeed = 5.0f;

    // a reference for the child cylinder transform
    // this is the transform we will actually rotate
    // NOTE: it will have a different local rotation to the parent transform in the hierarchy
    private Transform child;

    private void Start()
    {
        // get the child transform by using GetChild with an index of zero to get the first child
        // NOTE: will cause errors if there is no child transform!
        child = transform.GetChild(0);
    }

    void Update()
    {
        // calculate the degrees moved per update using Time.deltaTime
        float degreesPerUpdate = rotationSpeed * Time.deltaTime;

        // normalise the direction for more precise movement
        // NOTE: the Normalize() method will calculate the normal values and apply them to our direction vector3
        direction.Normalize();

        // STRATEGY 1: rotate on the LOCAL direction
        // calculate the movement in the direction per update and apply using transform.Rotate
        // NOTE: Rotate takes values in degrees, not radians
        // NOTE: the rotation is LOCAL to the transform by default!
        //child.Rotate(direction * degreesPerUpdate);

        // STRATEGY 2: rotate on the WORLD direction
        // rotate using WORLD rotation
        // this ignores the local rotation of the child transform
        //child.Rotate(direction * degreesPerUpdate, Space.World);

        // STRATEGY 3: ORBIT a target position
        // rotate around a target point
        // RotateAround will ORBIT the target along our direction axis!
        child.RotateAround(target.position, direction, degreesPerUpdate);
    }
}

