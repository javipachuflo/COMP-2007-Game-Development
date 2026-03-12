using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// in this class we get a random float from 0-1, we can assign the weight 
/// based on the procentage - 0.25f means 25% chance
/// </summary>
public class StepPercentageMover : MoverBase
{
    // Debug inspector settings
    [Header("Debug")]


#region RANDOM VALUE FIELD

    [SerializeField]
    private float randomValue;

#endregion RANDOM VALUE FIELD


    protected override void UpdateMover()
    {


#region RANDOM NUMBER GENERATION

        // generate random number
        randomValue = Random.Range(0.0f, 1.0f);

#endregion RANDOM NUMBER GENERATION


        // X and Y setup
        float currentX = 0;
        float currentZ = 0;


#region ALGORITHM
        // start algorithm code
        if (randomValue < 0.25f)        // 25%
        {
            currentX = moveDistance;
        }
        else if (randomValue < 0.5f)    // 50%
        {
            currentX = -moveDistance;
        }
        else if (randomValue < 0.75f)   // 75%
        {
            currentZ = moveDistance;
        }
        else                            // above 75%
        {
            currentZ = -moveDistance;
        }
        // end algorithm code

#endregion ALGORITHM




        // update the transform position
        UpdatePosition(currentX, currentZ);
    }
}
