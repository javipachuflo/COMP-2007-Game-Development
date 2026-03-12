using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlidingDoorInteract : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("IsOpen", false);
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("IsOpen", true);
    }
}
