using UnityEngine;
using System.Collections;

/* Gun
 * spawns a sphere when the mouse is pressed
 * offset to in front of the gameobject
 */ 
public class Gun : MonoBehaviour 
{
    // offset in front of the gun
    // used with transform.forward to calculate point
    [SerializeField]
    private float forwardOffset = 3;

    // prefab for the bullet
    [SerializeField]
    private GameObject bulletPrefab;
    
	void Update () 
    {
        // check the left mouse button was pressed
	    if(Input.GetMouseButtonDown(0))
        {
            // shoot the bullet
            Shoot();
        }
	}
    
    // shoot the bullet
    void Shoot()
    {
        // set a spawn position
        // we add a point in front using transform.forward and the forward offset field
        Vector3 spawnPosition = transform.position + (transform.forward * forwardOffset);

        // use instantiate to spawn in the bullet at the spawn position
        Instantiate(bulletPrefab, spawnPosition, transform.rotation);
    }
}
