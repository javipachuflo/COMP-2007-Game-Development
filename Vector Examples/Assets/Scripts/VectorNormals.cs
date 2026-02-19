using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class VectorNormals : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 normalisedDirection;

    [SerializeField]
    private float range = 1;


    void Update()
    {
        // store our normalised direction between the target and the transform
        Vector3 direction = target.position - transform.position;

        // a normalised direction will always have a magnitude (distance) of 1
        normalisedDirection = direction.normalized;

        // a debug line will display a line that will always be 1 unit long between the two positions
        //Debug.DrawRay(transform.position, normalisedDirection);

        // we can multiply the direction by a float to get exact distances
        //Vector3 rangedDirection = normalisedDirection * range;

        // the debug line will display a line the length of the range between the two positions
        //Debug.DrawRay(transform.position, rangedDirection);
    }
}
