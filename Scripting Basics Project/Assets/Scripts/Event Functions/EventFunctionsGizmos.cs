using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gizmos Event Functions
 * 
 * With these event functions we can
 *  - add graphics as debugging or visual aids
 *  - reset all fields on a component
 *  - NOTE: Gizmos are editor only, they will not be part of a build
 *  
 *  OnDrawGizmos()
 *  - draws pickable gizmos that are always drawn
 *  
 *  OnDrawGizmosSelected()
 *  - draws pickable gizmos that are drawn when the gameobject is selected
 *  
 *  Reset()
 *  - resets all fields to default values
 *  - NOTE: can be run from the inspector - right click the component name and select Reset
 *  
 */
public class EventFunctionsGizmos : MonoBehaviour
{
    public Color cubeColour = Color.red;
    public Color wireColour = Color.blue;

    public float wireSize = 1;
    public float solidSize = 1;


    // Implement OnDrawGizmos if you want to draw custom gizmos in the scene view that are also pickable and always drawn.
    // NOTE: Gizmos are only used in the editor, not built games
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnDrawGizmos.html
    private void OnDrawGizmos()
    {
        Gizmos.color = wireColour;

        // Draw a wire Cube
        Gizmos.DrawWireCube(transform.position, Vector3.one * wireSize);

        // Draw a wire Sphere
        // Gizmos.DrawWireSphere(transform.position, wireSize);
    }

    // Implement OnDrawGizmosSelected to draw a gizmo if the object is selected.
    // NOTE: Gizmos are only used in the editor, not built games
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = cubeColour;

        // Draw a solid Cube
         Gizmos.DrawCube(transform.position, Vector3.one * solidSize);

        // Draw a solid Sphere
        // Gizmos.DrawSphere(transform.position, solidSize);
    }

    // Reset is called when the component is attached in the Inpector panel
    // Reset will reset ALL settings on the component to default values, you can override the reset values inside the method
    // You can also use Reset in the editor by right clicking on the component in the inspector panel
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.Reset.html
    private void Reset()
    {
        print("Reset");

        // override default colour for the cube on reset
        // cubeColour = Color.green;
    }
}
