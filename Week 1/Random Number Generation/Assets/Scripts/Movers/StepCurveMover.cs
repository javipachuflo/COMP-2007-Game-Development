using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// we use a curve to get the random value. Tha advantage with a curve is the fact that we can control 
/// probability very easily.
/// 1. Add an animation curve variable to the script.
/// 2. Make it private but serializable(so we can modify it in the inspector)
/// 3. Generate a random float between 0-1 and avaluate it on the curve
/// 4. It will return a value based on the curve shape
/// NOTE: 
/// x axis - random value generated 
/// y axis - evaluated value returned from the curve
/// </summary>
public class StepCurveMover : MoverBase
{
    [Header("Custom Settings")]

    //animation curve with a serialised value(shows in the editor but still private - not accessible from anywhere else)
    [SerializeField]
    private AnimationCurve curve;


    // Debug inspector settings
    [Header("Debug")]



#region RANDOM VALUE FIELD

    [SerializeField]
    private float randomValue;

#endregion RANDOM VALUE FIELD




    protected override void UpdateMover()
    {



#region RANDOM NUMBER GENERATION

        //generate a random number and evaluate the curve
        float randomCurve = Random.Range(0.0f, 1.0f);
        randomValue = curve.Evaluate(randomCurve);

#endregion RANDOM NUMBER GENERATION



        // X and Y setup
        float currentX = 0;
        float currentZ = 0;




#region ALGORITHM

        //make sure the weights are equaly distributed so we have a uniform picking,
        //the probability will come from the shape of the curve
        if (randomValue < 0.25f)       // 25%
        {
            currentX = moveDistance;
        }
        else if (randomValue < 0.5f)   // 50%
        {
            currentX = -moveDistance;
        }
        else if (randomValue < 0.75f)   // 75%
        {
            currentZ = moveDistance;
        }
        else                            // 75%+
        {
            currentZ = -moveDistance;
        }

#endregion ALGORITHM



        // update the position using our current x and z
        // UpdatePosition method is part of the parent class, MoverBase
        UpdatePosition(currentX, currentZ);
    }
}
