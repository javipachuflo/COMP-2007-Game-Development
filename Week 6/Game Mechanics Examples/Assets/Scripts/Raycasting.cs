using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Raycasting
 * examples of raycasting and spherecasting in unity
 * raycasting:
 *      shoots a "laser" into the scene, returns any targets hit
 *  
 * spherecasting:
 *      shoots a "wide laser" - a sphere "shape" and returns any targets hit
 * 
 * there are other types of "shape" casting similar to sphere - cube and cylinder
 * 
 * 1. a single raycast
 *      can store a single target
 * 
 * 2. multiple raycast
 *      can store any number of targets 
 * 
 * 3. raycast alloc
 *      can store a set number of targets
 * 
 * 4. single spherecast
 *      stores a single target
 * 
 * 5. multiple spherecast
 *      stores any number of targets
 * 
 * 6. spherecast alloc
 *      can store a set number of targets
 * 
 */
public class Raycasting : MonoBehaviour 
{
    // a ray is a position and direction
    // we use the transform position and forward direction for every example
    private Ray ray;

    // RaycastHit stores a hit gameobject from a raycast
    // also stores the distance and the exact point of contact
    private RaycastHit hit;

    // an array of hits, used in the multiple examples
    private RaycastHit[] hits;
     
    // an array of hits with a pre-set size
    // used in the alloc examples
    private RaycastHit[] allocatedHits = new RaycastHit[10]; // max number of targets it can save
     
    void Start() 
    { 
        // create the ray for use in all examples
        // uses the transform position and forward direction
        ray = new Ray
        {
            // the origin is the starting point of the ray
            origin = transform.position,

            // the direction is the heading of the laser
            direction = transform.forward
        };

        // 1. a single raycast
        //SingleRaycast();

        // 2. multiple raycast
        //MultipleRaycast();

        // 3. raycast alloc
        RaycastAlloc();

        // 4. single spherecast
        //SingleSpherecast();

        // 5. multiple spherecast
        //MultipleSpherecast();

        // 6. spherecast alloc
        //SpherecastAlloc();

        // a debug ray for the scene view
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100);
    }

    // 1. a single raycast
    void SingleRaycast()
    {
        // single raycast
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.transform);
        }
        
    }

    // 2. multiple raycast
    void MultipleRaycast()
    {
        // multiple raycast
        // returns an array of Raycast hit objects
        hits = Physics.RaycastAll(ray);

        // output the total number of hits in the array
        print("Hits: " + hits.Length);

        for (int i = 0; i < hits.Length; i++)
        {
            print(hits[i].transform);
        }
        
    }

    void RaycastAlloc()
    {
        int numberOfHits = Physics.RaycastNonAlloc(ray, allocatedHits, 100);

        if (numberOfHits > 0)
        {
            for (int i = 0; i < numberOfHits; i++)
            {
                print(allocatedHits[i].transform);
            }
        }
    }

    void SingleSpherecast()
    {
        if(Physics.SphereCast(ray, 0.5f, out hit))
        {
            print(hit.transform);
        }
    }

    void MultipleSpherecast()
    {
        hits = Physics.SphereCastAll(ray, 0.5f, 10);

        print("Hits: " + hits.Length);

        for (int i = 0; i < hits.Length; i++)
        {
            print(hits[i].transform);
        }
    }

    void SpherecastAlloc()
    {
        int numberOfHits = Physics.SphereCastNonAlloc(ray, 0.5f, allocatedHits, 100);

        if (numberOfHits > 0)
        {
            for (int i = 0; i < numberOfHits; i++)
            {
                print(allocatedHits[i].transform);
            }
        }
    }

}
