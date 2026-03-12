using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelDesigner : MoverBase
{
    [Header("Custom Settings")]
    [SerializeField]
    private GameObject cellPrefab;

   
#region RANDOM VALUE FIELD

    // INSERT YOUR randomValue FIELD CODE HERE

#endregion RANDOM VALUE FIELD



    protected override void UpdateMover()
    {

#region RANDOM NUMBER GENERATION

        // INSERT YOUR RANDOM NUMBER GENERATION CODE HERE

#endregion RANDOM NUMBER GENERATION



        // setup code for the X and Z values
        float currentX = 0;
        float currentZ = 0;


#region ALGORITHM

        // INSERT YOUR ALGORITH CODE HERE

#endregion ALGORITHM



        // apply the new position to the transform
        UpdatePosition(currentX, currentZ);
        
        // spawn a new Cell Prefab GameObject here using Instantiate
        Instantiate(cellPrefab, transform.position, Quaternion.identity);

    }
}
