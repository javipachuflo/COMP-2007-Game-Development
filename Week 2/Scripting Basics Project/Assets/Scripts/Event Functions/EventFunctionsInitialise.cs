using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Initialise Event Functions
 * 
 * With these event functions we can
 *  - run code when the component is enabled or disabled
 *  - run code only once when the component is created in the scene
 *  
 *  OnEnable()
 *  - runs every time the component is enabled
 *  - also runs first when the component is first created in the scene
 *  
 *  Start()
 *  - runs only once when the component is created in the scene
 *  
 *  OnDisable()
 *  - runs every time the component is disabled
 * 
 */
public class EventFunctionsInitialise : MonoBehaviour
{
    // OnEnable is first called before start
    // OnEnable runs every time the component is enabled thereafter
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnEnable.html
    private void OnEnable()
    {
        print("On Enable");
    }

    // Start is called after OnEnable, before the first frame update
    // Start is only called once, upon creation
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.Start.html
    void Start()
    {
        print("Start");
    }

    // OnDisable runs every time the component is disabled
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.OnDisable.html
    private void OnDisable()
    {
        print("On Disable");
    }
}
