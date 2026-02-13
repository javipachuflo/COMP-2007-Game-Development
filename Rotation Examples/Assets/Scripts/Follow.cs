using UnityEngine;
using System.Collections;

/* Follow
*  rotates towards the mouse position on the Y axis
*  follow the steps in the code the create your own mouse follower
*/
public class Follow : MonoBehaviour
{
    void Update()
    {
        // STEP 1: transform position to screen position
        // World to screen point takes a point in world space and translates it to the screen X Y coordinates ← this makes a lot of sense if you think about it.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //Debug.Log(screenPosition);


        // STEP 2: get a heading to the mouse position
        // minus the mouse position from our screen position to get a heading or direction ← Basically, how far is the cursor from the object, and in which direction.
        Vector3 direction = Input.mousePosition - screenPosition;
        //Debug.Log("Position of mouse: " + Input.mousePosition + " And overall direction (i.e. mousePosition - screenPosition): " + direction);

        // STEP 3: calculate the angle between the mouse and screen position
        // Mathf.Atan2 uses trigonometry to calculate the angle ← Yes. From where you start drawing the line x to where you finish drawing the line of y.
        // we use the utility method Mathf.Rad2Deg to converts from radians to degrees ← Atan2 just translates coordinates x and y to radians (face wherever x and y lead you. if x was adjacent and y was the opposite, the Atan2 gives you the hypotenuse line(the direction its facing, that is). then Mathf.Rad2Deg just converts it to degrees instead of radians
        float degrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log("Degrees: " + degrees);

        // STEP 4: create a Quaternion for our rotation
        // AngleAxis converts an angle in degress with an axis to a Quaternion (radians based rotation)
        // NOTE: to get the correct angle, we minus the degrees and add 90 to it (unitys zero degrees actually faces right!)
        // the axis we are facing is Vector3.up - the WORLD up axis ← The chicken pole
        Quaternion radiansRotation = Quaternion.AngleAxis((-degrees) + 90, Vector3.up);
        Debug.Log(radiansRotation);

        // STEP 5: apply the rotation directly to the rotation field on the transform
        // NOTEL rotation is radians based
        transform.rotation = radiansRotation;
    }
}

