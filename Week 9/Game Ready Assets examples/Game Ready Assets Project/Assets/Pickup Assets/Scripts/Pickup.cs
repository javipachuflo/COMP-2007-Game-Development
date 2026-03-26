using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Pickup
 * allows a gameobject to be "collected"
 * will destroy itself on contact with the specified gameobject
 * uses a tag to recognise a "collector"
 * a delegate/event system is used for registering the collection and type
 */
namespace com.game
{
    public class Pickup : MonoBehaviour
    {
        // the tag of the gameobject that can collect
        public string collectorTag = "Player";

        // the type of pickup this object is
        public string type = "Cube Pickup";

        // the delegate for our pickup collected method
        public delegate void OnPickupCollected(string type);

        // the static method we will use in our other classes
        // the OnPickup method can be used to "listen" for a pickup
        public static OnPickupCollected OnPickup;

        private void OnTriggerEnter(Collider other)
        {
            // if the colliding object has our collector tag
            if (other.CompareTag(collectorTag))
            {
                // invoke the OnPickup delegate
                // NOTE: the ? symbol is an "is null" condition checking if the OnPickup delegate has any subscribers
                OnPickup?.Invoke(type);

                // we destroy the pickup after is has sent its payload
                Destroy(gameObject);
            }
        }
    }
}