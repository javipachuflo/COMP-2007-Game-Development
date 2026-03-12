using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMovement : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    [SerializeField]
    private Transform endPoint;

    private Vector3 startPosition;
    private Vector3 finalPosition;
    private float graphValue;
    private float startTime = 0;

    void Start()
    {
        startPosition = transform.position;
        finalPosition = endPoint.position;
    }
    
    void Update()
    {
        startTime += Time.deltaTime;

        graphValue = curve.Evaluate(startTime);
        transform.position = finalPosition * graphValue;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetAnimation();
        }
    }

    public void ResetAnimation()
    {
        transform.position = startPosition;
        startTime = 0;
        GetComponent<TrailRenderer>().Clear();
    }
}
