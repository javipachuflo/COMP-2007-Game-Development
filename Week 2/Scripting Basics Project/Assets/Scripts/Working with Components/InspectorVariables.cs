using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectorVariables : MonoBehaviour
{
    // A header can help to group sets of values together
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/HeaderAttribute.html
    [Header("Simple Values")]
    // A simple string of text value
    public string stringValue = "";

    // float is a decimal number
    public float floatValue = 1.2f;

    // int is a whole number
    public int intValue = 3;

    // is a true/false value
    public bool boolValue = true;


    [Header("Ranged Values")]
    // Range is used to make a float or int variable in a script be restricted to a specific range.
    // Range( MIN, MAX )
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/RangeAttribute.html
    [Range(-8, 4)]
    public float floatRange = 3.5f;

    // Example of a ranged int
    // Range will detect the type of number from the type of the property below
    [Range(-5, 5)]
    public int intRange = 4;


    [Header("Selectable Values")]
    // an enum is a list of pre-defined values, shown as a selectable dropdown menu in the inspector
    // see "EnumValues" code at the bottom of the file for implementation
    public EnumValues enumValues;

    [Header("Composite Values")]
    // Representation of RGBA colors, each value from a range of 0.0 - 1.0
    // Color( RED, GREEN, BLUE, ALPHA ) 
    // ALPHA = transparency
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Color.html
    public Color colourValue = new Color();

    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Vector2.html
    public Vector2 vector2Value = Vector2.zero;

    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Vector3.html
    public Vector3 vector3Value = Vector3.zero;


    [Header("Arrays of Values")]
    // We can also have arrays or lists of values for editing in the inspector
    public float[] floatArray;
    public Vector2[] vector2Array;


    [Header("Private values")]
    // You can specify private fields that can still be edited in the inspector by serializing the field
    // NOTE: this technique is essential for good OOP practice!
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/SerializeField.html
    [SerializeField]
    private string privateStringValue = "Private String";

    [Header("Components")]
    // Component values are references to other components, we can access and manipulate their values using the reference
    // Component values are often referenced from items in the scene
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Camera.html
    public Camera cameraValue;

    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MeshRenderer.html
    public MeshRenderer meshRendererValue;


    [Header("Files and Assets")]
    // Files and assets are references to files on the disk drive such as textures, audio files, text files
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Texture2D.html
    public Texture2D textureValue;

    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/AudioClip.html
    public AudioClip audioClipValue;

    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/TextAsset.html
    public TextAsset testAssetValue;


    [Header("Events")]
    // UnityEvents are used to send messages between components
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Events.UnityEvent.html
    public UnityEvent unityEventValue;



}

// An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
public enum EnumValues
{
    One,
    Two,
    Three
}
