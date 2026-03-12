using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("ToggleDoor", SendMessageOptions.DontRequireReceiver);
    }
}
