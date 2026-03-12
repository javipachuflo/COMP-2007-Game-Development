using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorBasics : MonoBehaviour
{
    [SerializeField]
    private Vector3 vectorA;

    [SerializeField]
    private Vector3 vectorB;

    [SerializeField]
    private float value;

    void Start()
    {
        // adding two vectors
        transform.position = vectorA + vectorB;


        // subtracting two vectors
        //transform.position = vectorA - vectorB;

        // multiplying two vectors
        //Vector3 multiplyVector = new Vector3
        //{
        //    x = vectorA.x * vectorB.x,
        //    y = vectorA.y * vectorB.y,
        //    z = vectorA.z * vectorB.z,
        //};
        //transform.position = multiplyVector;

        // multiplying by a float
        //transform.position = vectorA * value;

        // dividing by a float
        // NOTE: unity do not like dividing by zero, may give warnings
        //transform.position = vectorA / value;

    }

}
