using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // STEP 1: Create the "Laser Beam" (The Ray)
        // We ask the camera: "If I shot a laser through my mouse cursor, which way would it go?"
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // STEP 2: Create a container to hold the info of what we hit
        RaycastHit hitInfo;

        // STEP 3: Fire the Laser!
        // Physics.Raycast sends the laser out. 
        // If it hits something (returns true), we run the code inside.
        if (Physics.Raycast(cameraRay, out hitInfo))
        {

            // STEP 4: Look at the hit point
            // hitInfo.point is the exact X,Y,Z world position where the laser hit the floor.
            //transform.LookAt(hitInfo.point);

            // 1. Calculate the direction to the spot we hit
            // "Target Point" minus "My Position" equals "The Direction Vector"
            Vector3 direction = hitInfo.point - transform.position;

            // 2. Rotate the Y-Axis (Vector3.up) to face that direction
            // "Take my UP axis, and twist me until it matches the Direction."
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        }
    }
}
