using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Physics Event Functions
 * 
 * With these event functions we can
 *  - detect collisions or overlaps with other objects in the scene
 *  - NOTE: these functions require a collider component attached to the gameobject
 *  - NOTE: at least one of the the gameobjects needs a Rigidbody component to use the functions
 *  
 *  OnTriggerEnter(Collider)
 *  - runs when another collider overlaps the collider on this gameobject
 *  - the other collider is provided in the parameter
 *  
 *  OnTriggerExit(Collider)
 *  - runs when another collider stops overlapping the collider on this gameobject
 *  - the other collider is provided in the parameter
 * 
 *  OnCollisionEnter(Collision)
 *  - runs when another collider touches the collider on this gameobject
 *  - data about the collision is provided in the parameter
 *  
 *  OnCollisionExit(Collision)
 *  - runs when another collider stops touching the collider on this gameobject
 *  - data about the collision is provided in the parameter
 *  
 */
public class EventFunctionsPhysics : MonoBehaviour
{
    // OnTriggerEnter is called when the collider component attached overlaps with another collider in the scene
    // NOTE: OnTriggerEnter has a "Collider" parameter, this is the "other" collider we overlapped in the scene
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Collider.OnTriggerEnter.html
    private void OnTriggerEnter(Collider other)
    {
        print("On Trigger Enter");
    }


    // OnTriggerExit is called when collider component attached stops overlapping with another collider in the scene.
    // NOTE: OnTriggerExit has a "Collider" parameter, this is the "other" collider we stopped overlapping in the scene
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Collider.OnTriggerExit.html
    private void OnTriggerExit(Collider other)
    {
        print("On Trigger Exit");
    }

    // OnCollisionEnter is called when the collider component attached touches another collider in the scene
    // NOTE: OnCollisionEnter has a "Collision" parameter, this is an object containing data about the collision
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Collider.OnCollisionEnter.html
    private void OnCollisionEnter(Collision collision)
    {
        print("On Collision Enter");
    }

    // OnCollisionExit is called when collider component attached stops touching another collider in the scene
    // NOTE: OnCollisionExit has a "Collision" parameter, this is an object containing data about the collision
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Collider.OnCollisionExit.html
    private void OnCollisionExit(Collision collision)
    {
        print("On Collision Exit");
    }
}
