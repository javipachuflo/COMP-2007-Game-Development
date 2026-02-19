using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class VectorDirections : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float targetRange = 2;

    [SerializeField]
    private Vector3 heading;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float distance;

    void Update()
    {
        // look at the target - calculates the direction for you!
        //transform.LookAt(target);

        // distance using Vector3 distance
        //distance = Vector3.Distance(transform.position, target.position);

        //if (distance < targetRange)
        //{
        //    print("In Range");
        //}

        //Debug.DrawLine(transform.position, target.position);


        // heading between two points
        // NOTE: put target position first to get a facing direction
        //heading = target.position - transform.position;

        // distance using magnitude
        //distance = heading.magnitude;

        //if (distance < targetRange)
        //{
        //    print("In Range");
        //}

        // we can get a direction from the heading
        //direction = heading / distance;

        // we can control which direction our transform looks at
        //direction.y = 0;
        
        // we can set the transform to rotate towards a direction
        //transform.forward = direction;

        // or any other direction
        // X
        //transform.right = direction; // right
        //transform.right = -direction; // left

        // Y
        //transform.up = direction; // up
        //transform.up = -direction; // down

        // Z
        //transform.forward = -direction; // backward



    }

    private void OnTriggerStay(Collider other)
    {
        print("In Collider Range");
    }
}
