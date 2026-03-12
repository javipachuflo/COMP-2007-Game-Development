using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// we create a probability value using an array. If we want a value too have more weight
/// we assign it twice in the array
/// </summary>
public class StepArrayMover : MoverBase
{
    [Header("Debug")]


#region RANDOM VALUE FIELD

    [SerializeField]
    private int randomValue;

#endregion RANDOM VALUE FIELD



    [SerializeField]
    private int randomArrayIndex;
    
    protected override void UpdateMover()
    {



#region RANDOM NUMBER GENERATION


        // create an array of 5 int values
        int[] arrayOfInts = new int[5];

        //option 0 is assigned to the first 2 elements in the array
        arrayOfInts[0] = 0;
        arrayOfInts[1] = 0;
        arrayOfInts[2] = 1;
        arrayOfInts[3] = 2;
        arrayOfInts[4] = 3;

        //similar to the Step() method, we call a random number and we assign the float,
        //the only difference is the fact that we have a 40% chance to hit 0
        randomArrayIndex = Random.Range(0, 5);
        randomValue = arrayOfInts[randomArrayIndex];

#endregion RANDOM NUMBER GENERATION


        
        // X and Y setup
        float currentX = 0;
        float currentZ = 0;



#region ALGORITHM

        if (randomValue == 0)
        {
            currentX = moveDistance;
        }
        else if (randomValue == 1)
        {
            currentX = -moveDistance;
        }
        else if (randomValue == 2)
        {
            currentZ = moveDistance;
        }
        else
        {
            currentZ = -moveDistance;
        }

#endregion ALGORITHM


        UpdatePosition(currentX, currentZ);
    }
}
