using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.game.characters
{
    public class TestDamage : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }
}