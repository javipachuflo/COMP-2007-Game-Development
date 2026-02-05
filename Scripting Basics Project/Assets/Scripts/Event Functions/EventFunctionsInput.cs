using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Mouse Input Event Functions
 * 
 * With these event functions we can
 * - interact with colliders in the scene with the mouse
 * 
 * OnMouseEnter()
 * - runs when the mouse cursor overlaps the collider on this gameobject
 * 
 * OnMouseExit()
 * - runs when the mouse cursor stops overlapping the collider on this gameobject
 * 
 * OnMouseDown()
 * - runs when the left mouse button is pressed while over the collider
 * 
 * OnMouseUp()
 * - runs when the left mouse button is released while over the collider
 * 
 */
public class EventFunctionsInput : MonoBehaviour
{
    public Color enterColour = Color.red;
    public Color exitColour = Color.white;
    public Color downColour = Color.green;
    public Color upColour = Color.magenta;

    // Called when the mouse enters a Collider
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnMouseEnter.html
    private void OnMouseEnter()
    {
        print("Mouse Enter");

        GetComponent<MeshRenderer>().material.color = enterColour;
    }

    // Called when the mouse leaves the Collider.
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnMouseExit.html
    private void OnMouseExit()
    {
        print("Mouse Exit");

        GetComponent<MeshRenderer>().material.color = exitColour;
    }

    // called when the user has pressed the mouse button while over the Collider.
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnMouseDown.html
    private void OnMouseDown()
    {
        print("Mouse Down");

        GetComponent<MeshRenderer>().material.color = downColour;
    }

    // called when the user has released the mouse button.
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnMouseUp.html
    private void OnMouseUp()
    {
        print("Mouse Up");

        GetComponent<MeshRenderer>().material.color = upColour;
    }

}
