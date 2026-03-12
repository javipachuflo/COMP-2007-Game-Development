using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropdownTest : MonoBehaviour
{
    public List<Dropdown.OptionData> optionData = new List<Dropdown.OptionData>();

    private Dropdown dropdown;



    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.options = optionData;
    }

    public void OnDropdownChanged(int value)
    {
        print("Value: " + value + ", Option: " + optionData[value].text);
    }

}
