using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTest : MonoBehaviour
{
    public void OnToggle(bool isOn)
    {
        print("Toggled: " + isOn);
    }
}
