using UnityEngine;
using com.game;

public class PickupTest : MonoBehaviour
{
    // method that captures and OnPickup events and displays the type of pickup
    void OnPickup(string pickupType)
    {
        print("Picked up: " + pickupType);
    }

    private void OnEnable()
    {
        // subscribe to the OnPickup event
        Pickup.OnPickup += OnPickup;
    }

    private void OnDisable()
    {
        // unsubscribe to the OnPickup event
        Pickup.OnPickup -= OnPickup;
    }
}
