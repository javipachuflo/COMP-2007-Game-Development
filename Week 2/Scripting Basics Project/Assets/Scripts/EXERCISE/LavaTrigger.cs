using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Lava Trigger
 * moves a rigidbody to the start position when the trigger is entered
 * 
 * NOTE: we use the players Rigidbody so it's velocity can be reset after triggering
 */ 

public class LavaTrigger : MonoBehaviour
{
    // We get the players rigidbody component from the scene here
    public Rigidbody player;

    // position the player will be placed at when the trigger is entered
    public Transform startPoint;

    // when something overlaps this collider, the player rigidbody will be reset to the start position
    // we also reset the player rigidbody's velocity to zero
    private void OnTriggerEnter(Collider other)
    {
        // reset the player rigidbody's velocity to zero
        //https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody-velocity.html
        player.velocity = Vector3.zero;

        // reset the player rigidboy's rotational velocity to zero
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody-angularVelocity.html
        player.angularVelocity = Vector3.zero;

        // set the player rigidbody position to the start position
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Rigidbody-position.html
        // NOTE: Rigidbody has a position property, this will set the transform position as well
        player.position = startPoint.position;
    }
}
