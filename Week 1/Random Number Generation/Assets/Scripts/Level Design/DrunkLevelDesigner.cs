using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrunkLevelDesigner : MonoBehaviour
{
    [Header("Cell Settings")]
    [SerializeField]
    private GameObject cellPrefab;

    // randomSeed sets the Random system to produce the same list of random numbers each time 
    // set to -1 to ignore
    [SerializeField]
    private int randomSeed = -1;
    
    [SerializeField]
    public int cellMaxCount = 20;

    [SerializeField]
    private float cellSize = 1;

    [SerializeField]
    private float cellHeight = 0;
    
    [Header("Debug")]
    [SerializeField]
    // a debug total of all unique positions added
    private int uniquePositionsCount;

    // our cell positions for our level
    // HasSet is a type of collection, like arrays or Lists
    // HashSet can only contain unique values, so we have no repeat data in our positions
    private HashSet<Vector3> uniquePositions = new HashSet<Vector3>();

    void Start()
    {
        // set the random number generation to use a seed
        // this will produce the same list of random numbers each time
        if (randomSeed > -1)
        {
            Random.InitState(randomSeed);
        }

        // get a sarting position for our transform so we can reset it after the walk
        Vector3 oldPosition = transform.position;

        // run the algorithm!
        DoDrunkWalk();
        
        // reset to old position
        transform.position = oldPosition;
        
        // get a total count of unique positions for debugging
        uniquePositionsCount = uniquePositions.Count;

        // loop through and place a prefab at each position
        foreach (Vector3 position in uniquePositions)
        {
            Instantiate(cellPrefab, position, Quaternion.identity, transform);
        }
    }
    

    void DoDrunkWalk()
    {
        int count = cellMaxCount;

        // a "do while" loop allows us to continue doing something until we want to stop
        // also it allows us to "do" one operation before starting the loop!
        // a count will go down only when a unique position is added in the loop
        do
        {
            // random setup:
            // 0 = Right, 1 = Left, 2 = Forward, 3 = Back
            // NOTE Random.Range for int values are "exclusive" - it wont return the max number
            int randomIndex = Random.Range(0, 4);

            float currentX = 0;
            float currentZ = 0;
            
            // Movement
            if (randomIndex == 0)       // Right (X + 1)
            {
                currentX = cellSize;
            }
            else if (randomIndex == 1)  // Left (X - 1)
            {
                currentX = -cellSize;
            }
            else if (randomIndex == 2)  // Forward (Z + 1)
            {
                currentZ = cellSize;
            }
            else                        // Back (Z - 1)
            {
                currentZ = -cellSize;
            }
            
            // move our walker to the new position
            transform.position += new Vector3(currentX, 0, currentZ);

            // only add a position if it is unique
            // HashSet can only contain unique values, it will return false if we try to add a duplicate value 
            bool isUniquePosition = uniquePositions.Add(transform.position);

            // only decrease count down if a unique position was added
            if (isUniquePosition)
            {
                count--;
            }
            
        }
        while (count > 0); // loop until we have created the set number of unique cells
    }
}
