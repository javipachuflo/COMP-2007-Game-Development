using UnityEngine;
using System.Collections;

/* Bullet
 * controls a bullet gameobject
 * adds a force to move the rigidbody component
 */
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour 
{
    // speed of the bullet
    public float force = 100;
    
	void Start () 
    {
        // move rigidbody using addforce
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);

        // destroy after a short time if the bullet didn't hit anything
        Destroy(gameObject, 5.0f);
	}
}
