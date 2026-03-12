using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// step with probability, using a vector, modifying the range will influence the direction
/// of travel. x axis: -0.1 means left, 0.1 means right, 0 means no movement
/// z axis: -0.1 means down, 0.1 means up, 0 means no movement
/// </summary>
public class StepVectorProbability : MoverBase
{
    [Header("Debug")]
    [SerializeField]
    private float randomX;

    [SerializeField]
    private float randomZ;

    protected override void UpdateMover()
    {
        //generate the random value on the 2 axis
        randomX = Random.Range(-moveDistance, moveDistance);
        randomZ = Random.Range(-moveDistance, moveDistance);

        //apply the movement to the player 
        UpdatePosition(randomX, randomZ);
    }
}
