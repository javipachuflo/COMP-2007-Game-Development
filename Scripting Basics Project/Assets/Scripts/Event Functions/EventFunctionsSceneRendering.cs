using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Scene Rendering Event Functions
 * 
 * With these event functions we can
 *  - run code when the mesh is no longer visible to any cameras in the scene
 *  - NOTE: requires a Renderer component on the gameobject to run
 *  
 *  OnBecameVisible()
 *  - runs once when the renderer is visible to any camera
 *  
 *  OnBecameInvisible()
 *  - runs once when the renderer is no longer visible to any camera 
 * 
 *  
 */
public class EventFunctionsSceneRendering : MonoBehaviour
{
    // OnBecameVisible is called when the renderer became visible by any camera.
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnBecameVisible.html
    private void OnBecameVisible()
    {
        print("Visible");
    }

    // OnBecameInvisible is called when the renderer is no longer visible by any camera.
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnBecameInvisible.html
    private void OnBecameInvisible()
    {
        print("Invisible");
    }
}
