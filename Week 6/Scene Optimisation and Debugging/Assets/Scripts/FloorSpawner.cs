using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FloorSpawner : MonoBehaviour
{
    public GameObject floorPrefab;

    public int rows = 10;
    public int columns = 10;

    
    void Start()
    {
        for (int z = 0; z < columns; z++)
        {
            for (int x = 0; x < rows; x++)
            {
                Vector3 position = new Vector3(x, 0, z);
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
            }
        }
    }

}
