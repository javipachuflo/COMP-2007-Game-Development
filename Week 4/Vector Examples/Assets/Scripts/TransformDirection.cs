using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// you can indirectly influence the rotation of a transform using the direction properties:
// transform.right, transform.up, transform.forward

[SelectionBase]
public class TransformDirection : MonoBehaviour
{
    // the relative or facing direction transform are the rotation expressed at vector 3 directions

    // the right direction is the red arrow or x axis
    [SerializeField]
    private Vector3 rightX;

    // the up direction is the green arrow or y axis
    [SerializeField]
    private Vector3 upY;

    // the forward direction is the blue arrow or z axis
    [SerializeField]
    private Vector3 forwardZ;

    void Start()
    {
        rightX = transform.right;
        upY = transform.up;
        forwardZ = transform.forward;
    }
    
    void Update()
    {
        // transform.right returns a direction facing right, relative to the transform
        rightX = transform.right;

        // transform.up returns a direction facing up, relative to the transform
        upY = transform.up;

        // transform.forward returns a direction facing forward, relative to the transform
        forwardZ = transform.forward;


        // we can also set any of the facing directions
        //transform.right = rightX;

        //transform.up = upY;

        //transform.forward = forwardZ;
    }
}
