using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* BasicMovement
 * Demonstrates movment using the Transform component
 * 
 */

public class BasicMovement : MonoBehaviour
{
    // the direction of movement along the x, y and z planes
    [SerializeField]
    private Vector3 direction = new Vector3();

    // a debugging field for the current delta time.
    //[SerializeField]
    //private float timeDebug;

    void Update()
    {
        //timeDebug = Time.deltaTime;

        // calculate our movement direction
        Vector3 updatedDirection = direction * Time.deltaTime;

        // move all directions
        transform.position += updatedDirection;


        // translate all directions 
        //transform.Translate(updatedDirection);


        // move on each direction - split into three parts
        // 1 copy the current position of the transform
        //Vector3 currentPosition = transform.position;

        // 2 set each direction seprately on the copy
        //currentPosition.x = currentPosition.x + updatedDirection.x;
        //currentPosition.y = currentPosition.y + updatedDirection.y;
        //currentPosition.z = currentPosition.z + updatedDirection.z;

        // 3 apply changed values back to the transform
        //transform.position = currentPosition;

    }
}


public interface IInterface
{
}

public class BaseClass
{
}

public class MyClass : BaseClass, IInterface
{
}
