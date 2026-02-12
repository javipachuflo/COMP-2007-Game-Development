using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private Vector3 rotationDirection;
    [SerializeField] private float _speed;

    void Update()
    {
        //local rotation
        transform.Rotate(rotationDirection * _speed * Time.deltaTime);

        //world rotation
        //transform.Rotate(rotationDirection * _speed * Time.deltaTime, Space.World);
    }
}
