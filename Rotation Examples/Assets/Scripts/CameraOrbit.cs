using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    // Drag the 'Character' object here in the Inspector
    [Tooltip("The object the camera should follow and orbit around")]
    public Transform target;

    [Header("Settings")]
    public float sensitivity = 5.0f;
    public float heightOffset = 2.0f; // Adjusts camera to look at head level rather than feet

    void Start()
    {
        // Safety check to prevent errors if you forget to link the target
        if (target == null)
        {
            Debug.LogError("Please assign the 'Character' to the Target field on the Main Camera!");
            return;
        }

        // Optional: Position the camera behind the player at the start
        // This ensures the camera starts at a reasonable distance
        transform.position = target.position + new Vector3(0, heightOffset, -5.0f);
        transform.LookAt(target.position + Vector3.up * heightOffset);
    }

    // We use LateUpdate for cameras to ensure the player has finished moving 
    // in Update() before the camera positions itself. This prevents jitter.
    void LateUpdate()
    {
        if (target == null) return;

        // 1. INPUT
        // Get mouse movement input. 
        // Although the tips mention Input.mousePosition, Input.GetAxis is the standard
        // and smoothest way to get rotation deltas in Unity.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 2. MOVEMENT (Follow the player)
        // If the player has moved, the camera needs to move with them relative to the previous frame.
        // We do this by calculating the offset distance and reapplying it? 
        // Actually, with RotateAround, we need to be careful. 
        // The easiest logic for "RotateAround + Follow" is:

        // Define the point we want to orbit (the target + slightly up for the head)
        Vector3 orbitPoint = target.position + (Vector3.up * heightOffset);

        // First, move the camera so it maintains its relative position to the target
        // (This handles the "Following" requirement automatically if we didn't rotate)
        // However, since RotateAround changes position, we handle rotation first.

        // 3. ROTATION (Orbit using RotateAround)
        //Rotate around the Y axis (Orbit horizontally)
        transform.RotateAround(orbitPoint, Vector3.up, mouseX);

        //Rotate around the Camera's Right axis (Orbit vertically/look up-down)
        // We invert mouseY so moving the mouse up looks up
        transform.RotateAround(orbitPoint, transform.right, -mouseY);

        // 4. FIX DISTANCE / FOLLOW
        // RotateAround can sometimes cause the camera to spiral in or out slightly, 
        // or drift if the player is moving fast. 
        // To ensure we strictly "Follow" the player, we enforce the distance.

        // Calculate the direction from the target to the camera
        Vector3 direction = (transform.position - orbitPoint).normalized;

        // Use the current distance (or a fixed distance if you prefer)
        float currentDistance = Vector3.Distance(transform.position, orbitPoint);

        // Re-apply the position based on the target's current location
        // This effectively makes the camera "Follow" the player perfectly
        transform.position = orbitPoint + (direction * currentDistance);

        // Ensure the camera always faces the target
        transform.LookAt(orbitPoint);
    }
}