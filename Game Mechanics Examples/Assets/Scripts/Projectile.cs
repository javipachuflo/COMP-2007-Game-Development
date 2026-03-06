using UnityEngine;
using System.Collections;

/* Projectile
 * Angry Birds style aim and fire mechanism
 * show a 2D (X and Y) predicted trajectory before firing
 */
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour 
{
    // the total force applied to the shot
    public float force = -8;

    // the trajectory dots prefab
    public GameObject dotPrefab;

    // an override for gravity
    // default set to real world gravity
    public float gravity = 9.8f;

    // an array for all of the dots in the trajectory
    private GameObject[] trajectoryDots;

    // a reference to the main camera
    // we will be using the main camera in the update loop a lot
    private Camera mainCam;

    // the current aim direction, used in the trajectory algorithm
    private Vector3 direction;

    // a reference to the rigidbody component
    private Rigidbody body;
    

	void Start () 
    {
        // we will have a total of 10 points in the trajectory
        // add more if you wish to have more precision
        trajectoryDots = new GameObject[30];

        // store a reference to the main camera
        mainCam = Camera.main;

        // store the rigidbody component
        body = GetComponent<Rigidbody>();
        
        // create the dots for the trajectory and store them in dot line array
        for (int i = 0; i < trajectoryDots.Length; i++)
        {
            // create the dot
            GameObject dot = Instantiate(dotPrefab) as GameObject;

            // disable the dot gameobject
            dot.SetActive(false);

            // store the dot in the dot line array
            trajectoryDots[i] = dot;
        }
	}
	

	void Update () 
    {
        // while the mouse button is down, calculate the trajectory
	    if(Input.GetMouseButton(0))
        {
            // get the position of the transform on the screen
            Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);

            // reset the z axis so our trajectory is in 2D (X and Y axis)
            screenPos.z = 0;

            // calculate the facing direction from the mouse cursor to the transform
            // normalise the direction so we can use it elsewhere
            direction = (Input.mousePosition - screenPos).normalized;

            // the Aim method will show our predicted trajectory using the direction provided
            Aim(direction);
        }

        // when the mouse button is released, hide the trajectory points and fire the projectile
        if(Input.GetMouseButtonUp(0))
        {
            // fire the projectile using the direction and the force field
            body.velocity = direction * force;

            // disable all of the trajectory dots
            for (int i = 0; i < trajectoryDots.Length; i++)
            {
                //trajectoryDots[i].SetActive(false);
            }
        }
	}

    // arranges the trajectory dots to form a predicted trajectory
    // uses our adjusted gravity field for the prediction
    private void Aim(Vector3 direction)
    {
        Vector2 velocity = new Vector2
        {
            x = direction.x * force,
            y = direction.y * force
        };

        // arrange the dots according to a decay algorithm using the graivty field
        for (int i = 0; i < trajectoryDots.Length; i++)
        {
            // calculate the spacing between the dots
            float spacing = i * 0.1f;

            // x position is the velocity * spacing, evenly spacing the dots out
            float x = transform.position.x + (velocity.x * spacing);

            // calculate the y position using spacing
            float yPosition = transform.position.y + (velocity.y * spacing);

            // calculate the y gravity
            float yGravity = ((-gravity * spacing) * spacing) / 2.0f;

            // minus the y position from the provided gravity field
            float y = yPosition - yGravity;

            // set the final position of the dot
            trajectoryDots[i].transform.position = new Vector3(x, y, 0.0f);

            // enable the dot gameobject
            trajectoryDots[i].SetActive(true);
        }
    }
}
