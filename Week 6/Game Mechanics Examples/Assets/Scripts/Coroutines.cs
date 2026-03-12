using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Coroutines
 * examples of how to use coroutines
 * 1. change colour sequence
 *      coroutines can perform a sequence of tasks with a custom delay time in between
 * 
 * 2. change colour for loop
 *      a for loop can be used to perform coroutine code a set number of times
 *      
 * 3. change colour while loop
 *      a coroutine can be continued until a while loop condition ends
 * 
 */
public class Coroutines : MonoBehaviour
{
    // used as the condition in the while loop example
    private bool isOn = true;

    void Start()
    {
        // 1. change colour sequence
        StartCoroutine(ChangeColourSequence());
        
        // 2. change colour for loop
        //StartCoroutine(ChangeColourForLoop());

        // 3. change colour while loop
        //StartCoroutine(ChangeColourWhileLoop());
    }

    private void Update()
    {
        // used in the while loop example to stop the coroutine
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ison stops the while loop coroutine example
            isOn = false;
        }
    }

    // 1. change colour sequence
    // a sequence of coroutine "waits"
    // can perform linear sequence of codde with custom wait times between each
    IEnumerator ChangeColourSequence()
    {
        // apply a random colour to the cubes material
        GetComponent<MeshRenderer>().material.color = GetRandomColour();

        // a coroutine "wait" - waits for 1 second
        // note: we use a yield to allow the unity engine to "wait" (this is a sub-process on the computers taks manager)
        yield return new WaitForSeconds(1);

        GetComponent<MeshRenderer>().material.color = GetRandomColour();

        yield return new WaitForSeconds(1);

        GetComponent<MeshRenderer>().material.color = GetRandomColour();

        yield return new WaitForSeconds(1);

        GetComponent<MeshRenderer>().material.color = GetRandomColour();

        yield return new WaitForSeconds(1);

        GetComponent<MeshRenderer>().material.color = GetRandomColour();
    }

    // 2. change colour for loop
    // run a set number of coroutines within a for loop
    IEnumerator ChangeColourForLoop()
    {
        // we can use a yield statement within a for loop to perform the "wait" every loop iteration
        for (int i = 0; i < 10; i++)
        {
            // apply a random colour to the cubes material
            GetComponent<MeshRenderer>().material.color = GetRandomColour();

            // the yield statement here is exactly the same as the previous example, just within a for loop
            yield return new WaitForSeconds(1);
        }
    }

    // 3. change colour while loop
    // run a coroutine until a condition is met within a while loop
    IEnumerator ChangeColourWhileLoop()
    {
        // we can use a yield statement within a while loop until the loop condition is met
        while(isOn == true)
        {
            // apply a random colour to the cubes material
            GetComponent<MeshRenderer>().material.color = GetRandomColour();

            // the yield statement here is exactly the same as the previous example
            yield return new WaitForSeconds(1);
        }
    }

    // returns a random colour
    private Color GetRandomColour()
    {
        // each part of the colour is randomised - red, green, blue
        return new Color(   Random.Range(0.0f, 1.0f),
                            Random.Range(0.0f, 1.0f),
                            Random.Range(0.0f, 1.0f));
    }
}
