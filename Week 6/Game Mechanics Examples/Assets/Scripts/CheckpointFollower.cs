using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CheckpointFollower
 * follows a set of checkpoints from a separate transform
 * movement will loop over the checkpoints
 */
public class CheckpointFollower : MonoBehaviour
{
    // movement speed
    public float speed = 1;

    // the checkpoint holder
    // contains child transforms used for the checkpoints movement
    public Transform checkPoints;

    // current transform index for the checkpoints
    [SerializeField] private int currentPointIndex = 0;

    // the current position from the checkpoints
    [SerializeField] private Vector3 currentPoint = Vector3.zero;

    void Start()
    {
        // set the position at the first checkpoint
        transform.position = checkPoints.GetChild(0).position;

        // start moving from the first point to the next
        NextPoint();
    }

    void Update()
    {
        // we use the move towards method to move towards the next checkpoint
        transform.position = Vector3.MoveTowards(transform.position, currentPoint, Time.deltaTime * speed);

        // move to next points if we have arrived at the current position
        if (transform.position == currentPoint)
        {
            // next point will set the current point to move towards
            NextPoint();
        }
    }

    // next point calculates the next point in the checkpoints
    // when the last point is reached, current point index resets to zero - the first checkpoint
    void NextPoint()
    {
        // increase current point index
        currentPointIndex++;

        // if index is greater than the number of checkpoints, reset to first checkpoint
        if (currentPointIndex >= checkPoints.childCount)
        {
            // reset to first point
            currentPointIndex = 0;
        }

        // set the current point from the index
        currentPoint = checkPoints.GetChild(currentPointIndex).position;
    }

}
