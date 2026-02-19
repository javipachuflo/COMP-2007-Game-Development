using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScale : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;

    [SerializeField]
    private Vector3 endScale;

    private Vector3 startScale;
    private Vector3 finalScale;
    private float graphValue;
    private float startTime = 0;

    void Start()
    {
        startScale = transform.localScale;
        finalScale = endScale;
    }
    
    void Update()
    {
        startTime += Time.deltaTime;

        graphValue = curve.Evaluate(startTime);
        transform.localScale = finalScale * graphValue;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetAnimation();
        }
    }

    public void ResetAnimation()
    {
        transform.localScale = startScale;
        startTime = 0;
    }
}
