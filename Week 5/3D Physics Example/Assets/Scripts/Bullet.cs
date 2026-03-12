using UnityEngine;
using System.Collections;

/* Bullet
 * move the Rigidbody forward as soon as it spawns
 * applied using the AddForce method on the Rigidbody
 */
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour 
{
    // the amount of power applied to the force
    [SerializeField]
    private float power = 100;
    
	void Start () 
    {
        // the force to apply to the Rigidbody
        // the forward direction multipled by the power
        Vector3 force = transform.forward * power;

        // use the AddForce method on the Rigidbody
        // ForceMode.Impulse will apply the force directly
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        // destroy the gameobject after 5 seconds
        Destroy(gameObject, 5.0f);
	} 
} 
 