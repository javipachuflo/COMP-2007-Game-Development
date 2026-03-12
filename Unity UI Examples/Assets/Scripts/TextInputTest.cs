using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class TextInputTest : MonoBehaviour
{

    public void OnTextChanged(string value)
    {
        print("Changed: " + value);
    }

    public void OnTextEditEnd(string value)
    {
        print("End Edit: " + value);
    }
}
