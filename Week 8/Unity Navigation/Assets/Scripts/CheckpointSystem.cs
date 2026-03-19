using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private int currentPointIndex = 0;

    public Vector3 CurrentPoint {
        get {
            return currentPoint;
        }
    }
    private Vector3 currentPoint = Vector3.zero;

    private void Awake()
    {
        currentPoint = transform.GetChild(0).position;
    }

    // next point calculates the next point in the checkpoints
    // when the last point is reached, current point index resets to zero - the first checkpoint
    public void NextPoint()
    {
        // increase current point index
        currentPointIndex++;

        // if index is greater than the number of checkpoints, reset to first checkpoint
        if (currentPointIndex >= transform.childCount)
        {
            // reset to first point
            currentPointIndex = 0;
        }

        // set the current point from the index
        currentPoint = transform.GetChild(currentPointIndex).position;
    }

}
