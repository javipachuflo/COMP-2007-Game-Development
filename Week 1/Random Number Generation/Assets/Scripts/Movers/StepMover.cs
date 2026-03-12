using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// randomly asigns a value form 0-3 and based on that value we
/// assign values to the float variables
/// </summary>
public class StepMover : MoverBase
{
    [Header("Debug")]


#region RANDOM VALUE FIELD

    [SerializeField]
    private int randomValue;

#endregion RANDOM VALUE FIELD



    protected override void UpdateMover()
    {


#region RANDOM NUMBER GENERATION

        // random setup:
        // 0 = Right, 1 = Left, 2 = Forward, 3 = Back
        randomValue = Random.Range(0, 4);

#endregion RANDOM NUMBER GENERATION



        // X and Y setup
        float currentX = 0;
        float currentZ = 0;



#region ALGORITHM

        // start algorithm code
        if (randomValue == 0)       // Move Right (X + 1)
        {
            currentX = moveDistance;
        }
        else if (randomValue == 1)  // Move Left (X - 1)
        {
            currentX = -moveDistance;
        }
        else if (randomValue == 2)  // Move Forward (Z + 1)
        {
            currentZ = moveDistance;
        }
        else                        // Move Back (Z - 1)
        {
            currentZ = -moveDistance;
        }
        // end algorithm code

#endregion ALGORITHM


        UpdatePosition(currentX, currentZ);
    }
}
