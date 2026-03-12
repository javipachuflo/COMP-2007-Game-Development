using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Game Logic Event Functions
 * 
 * With these event functions we can
 *  - run code on every frame, from 30 to 120 times per second
 *  - run code at exact time intervals in line with the physics system
 *  - NOTE: heavy processing code in these methods can cause performance issues!
 *  
 *  Update()
 *  - runs code on every frame
 *  - use this method for general purposes, like user input or animation
 *  
 *  FixedUpdate()
 *  - runs code on every physics time step interval
 *  - recoemmend to use this method for anything physics related
 * 
 */
public class EventFunctionsGameLogic : MonoBehaviour
{
    // Update is called once per frame, if the monobehviour is enabled
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.Update.html
    void Update()
    {
        print("Update");
    }

    // FixedUpdate is part of the Unity Physics system
    // FixedUpdate is called at the frequency set by the "Fixed Timestep" setting in the "Time" section of the project settings
    // User this method for updating physics items in the scene
    // https://docs.unity3d.com/2021.2/Documentation/ScriptReference/MonoBehaviour.FixedUpdate.html
    private void FixedUpdate()
    {
        print("Fixed Update");
    }
}
