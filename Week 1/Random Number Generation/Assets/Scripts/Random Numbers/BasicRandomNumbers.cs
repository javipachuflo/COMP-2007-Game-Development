using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRandomNumbers : MonoBehaviour
{
    public float min = 0;
    public float max = 1;
    
    private void Start()
    {
        float randomNum = Random.Range(min, max);

        Vector3 newPosition = transform.position;
        newPosition.x = randomNum;

        transform.position = newPosition;
    }
}
