using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/* Wave
 * create a 'caterpillar' of sections and animate them oscillating
 * the osciallation uses Mathf.Sin - a sine wave in the update method
 * the oscillation is applied to the X position axis of each section
 */
public class Wave : MonoBehaviour
{
    // provide a prefab for the sections of the wave
    [SerializeField]
    private GameObject section; //template section

    // the "strength" of the oscillation - higher numbers is more distance
    [SerializeField]
    private float amplitude = 0.6f;  //the distance from the centre of motion to either extreme

    // the speed a section moves from left to right
    [SerializeField, Range(0, 20)]
    private float oscillationSpeed = 1;
    
    // array of sections to create a wave
    private Transform[] wave;  

    //how quickly the angle grows
    private float angleVel = 100.0f;  

    // we increase this angle in order to generate values between -1 and 1
    private float angle = 0.0f;  

    // calculate the speed to a gooe movement range (1000 to 1020)
    private float calculatedSpeed;

    void Start()
    {
        // start the wave creation
        CreateWave(); 
    }

    // create a wave of sections to animate
    private void CreateWave()
    {
        //new array with number of sections
        wave = new Transform[10];

        // loop through the array 
        for (int i = 0; i < 10; i++)
        {
            // instantiate a scetion and return the transform using CreateSection
            wave[i] = CreateSection();

            //here we position the section
            wave[i].position = new Vector3(0.0f, 0.0f, i * 0.25f);
        }
    }

    // method to insantiate a prefab and return the transform
    private Transform CreateSection()
    {
        // instantiate prefab - we set the postion/rotation later
        GameObject tempObj = Instantiate(section);

        // get the transform component
        Transform tempTransform = tempObj.GetComponent<Transform>();

        // return the transform
        return tempTransform;
    }

    void Update()
    {
        // add 1000 to the speed to stabilise between useful values
        // NOTE: the raw ascillation speed will move faster than unity can calculate and will cause errors!
        calculatedSpeed = oscillationSpeed + 1000;

        // loop through the sections and calculate their X position
        for (int i = 0; i < wave.Length; i++)
        {
            // first we work out the angle, in degrees
            // Mathf.PI x 2 converts the angle to radians multiplied by our angle
            float currentAngle = (Mathf.PI * 2 * angle) / calculatedSpeed;

            // the sine value can now be calculated from the current angle
            float sinX = Mathf.Sin(currentAngle); // use Sine
            
            // the x value is our sine X multiplied by the amplitude
            // the amplitude is the distance the X value will travel between oscillations
            float xValue = sinX * amplitude;

            //we position the x value
            wave[i].position = new Vector3(xValue, 0.0f, wave[i].position.z);
            
            //we increase the angle, moving each section a little each update
            angle += angleVel;
        }
    }
    
}

