using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverBase : MonoBehaviour
{
    [Header("Mover Settings")]
    // how many times per second a move will occur
    [SerializeField]
    protected float movesPerSecond = 1;

    // the distance in Unity units to move by
    // this will be used by child classes to adjust position
    [SerializeField]
    protected float moveDistance = 0.1f;

    // a "cached" reference for the transform component - minor optimisation
    // for frequent use in the UpdateMover method 
    private Transform thisTransform;

    protected virtual void Start()
    {
        // get a reference to the transform
        // we will use this a lot in the UpdateMover method
        thisTransform = transform;

        // calculate the time in seconds from the moves per seond field
        float timeInSeconds = 1 / movesPerSecond;

        // setup a repeating timer (InvokeRepeating) to run the UpdateMover method
        // we use the time in seconds to set the update speed 
        // 
        InvokeRepeating(nameof(UpdateMover), 0, timeInSeconds);
    }

    // child classes will implement this method to apply their movement algorithm
    // this method runs repeatedly using the InvokeRepeating code above
    protected abstract void UpdateMover();
    
    protected void UpdatePosition(float x, float z)
    {
        thisTransform.position += new Vector3(x, 0.0f, z);
    }
}
