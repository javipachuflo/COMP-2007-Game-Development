using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour
{
    public void OnSliderChanged(float value)
    {
        print("Slider: " + value);
    }
}
