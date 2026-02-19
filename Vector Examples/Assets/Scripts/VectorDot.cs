using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class VectorDot : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField, Range(0, 360)]
    private float detectAngle = 30;

    [SerializeField]
    private float degrees;

    public UnityEvent onDetect;

    public UnityEvent onLost;

    void Update()
    {

        // we get the direction between the transform and target
        Vector3 direction = target.position - transform.position;
        
        // use Vector3.Dot to tell if we are facing the target or not
        // 1 = facing target, 0 = perpendicular to target, -1 = target is behind us
        // the angle is in radians, not degrees!
        float radians = Vector3.Dot(direction.normalized, transform.forward);
        
        // we can convert the angle from radians into degrees
        // multiply by two so the angle covers left and right side
        degrees = (Mathf.Acos(radians) * Mathf.Rad2Deg) * 2;

        // if the degrees are less than our detect angle
        if (degrees < detectAngle)
        {
            onDetect.Invoke();
        }
        else
        {
            onLost.Invoke();
        }

    }
}
