using UnityEngine;
using System.Collections;

/* Gun
 * fires a gameobject from the forward direction of the transform
 * fires on mouse press
 */
public class Gun : MonoBehaviour 
{
    // the bullet prefab to fire
    public GameObject bulletPrefab;
    
	void Update () 
    {
        // fire on mouse press
	    if(Input.GetMouseButtonDown(0))
        {
            // spawn the bullet gameobject using instantiate
            // set the position 3 units in front, same rotation as transform
            Instantiate(bulletPrefab, transform.position + transform.forward * 3, transform.rotation);
        }
	}
}
