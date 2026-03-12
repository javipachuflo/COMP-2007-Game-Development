using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorInteract : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        bool isOpen = anim.GetBool("IsOpen");

        anim.SetBool("IsOpen", !isOpen);
    }
}
