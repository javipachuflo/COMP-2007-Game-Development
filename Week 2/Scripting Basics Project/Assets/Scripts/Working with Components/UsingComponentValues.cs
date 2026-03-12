using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingComponentValues : MonoBehaviour
{
    // Here we will place a reference to the Mesh Renderer in the inspector
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MeshRenderer.html
    public MeshRenderer meshRenderer;

    // enableRenderer is a boolean that will enable or disable the Mesh Renderer Component
    public bool enableRenderer = true;

    // meshColour will change the colour of the material on the Mesh Renderer
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Color.html
    public Color materialColour = Color.white;

    // position will set the transform components position value for x,y and z
    public Vector3 position = Vector3.zero;

    // scale will set the transofrm components scale value for x,y and z
    public Vector3 scale = Vector3.one;


    void Update()
    {
        // set the colour of the material on the mesh renderer
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Material-color.html
        meshRenderer.material.color = materialColour;

        // enable or disable the mesh renderer component using enable
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Renderer-enabled.html
        meshRenderer.enabled = enableRenderer;

        // set the scale of the transform component using localScale
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform-localScale.html
        transform.localScale = scale;

        // set the position of the transform component using position
        // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/Transform-position.html
        transform.position = position;

    }
}
