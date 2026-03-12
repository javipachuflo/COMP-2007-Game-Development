using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupTest : MonoBehaviour
{
    ToggleGroup group;


    void Start()
    {
        group = GetComponent<ToggleGroup>();

        
    }

    public void OnToggle(bool isOn)
    {
        Toggle active = group.GetFirstActiveToggle();

        print(active.transform.name);
    }
}
