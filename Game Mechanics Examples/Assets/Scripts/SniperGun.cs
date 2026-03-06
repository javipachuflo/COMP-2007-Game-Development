using UnityEngine; 
using System.Collections; 
 
/* SniperGun
 * uses a raycast to fire a bullet hole prefab
 * the bullet hole will align itself to the surface it hits
 */
public class SniperGun : MonoBehaviour  
{
    // the prefab for the bullet hole mesh
    public GameObject bulletHolePrefab; 

    // distance in units for the raycast to travel
    private float rayDistance = 20.0f;

    // a ray is a position and direction
    // stores transform position and forward direction of the camera
    private Ray ray;

    // stores the object hit 
    // we can get a distance and an exact point where collision happenned
    private RaycastHit hit;

	void Update ()  
    {
        // ViewportPointToRay creates a ray using the camera position and forward direction
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        // use the ray with the ray distance field in a raycast
        // the first object hit is stored in the hit field
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // a debug line mathing our ray cast
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red); 
            
            // check for mouse press
            if(Input.GetMouseButtonDown(0)) 
            {
                // raycast hit has a point field for the impact point
                Vector3 impactPoint = hit.point;

                // get the direction of the face we hit
                // this will rotate the bullet hole to face away from the impact point 
                // FromToRotation will give us a rotation from an initial direction
                // here we get a rotation from the world forward (Vector3.forward)
                // the to direction is minus hit.normal - the normal of the surface we hit
                Quaternion facingRotation = Quaternion.FromToRotation(Vector3.forward, -hit.normal);

                // spawn a bullet hole at the exact point of collision
                Instantiate(bulletHolePrefab, impactPoint, facingRotation);
            } 
        } 
        else 
        {
            // a debug ray from our original ray calculation
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
        } 
	} 
} 
 