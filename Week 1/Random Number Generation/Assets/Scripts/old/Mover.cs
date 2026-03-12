using UnityEngine;
using System.Collections;

namespace Marius
{
    public class Mover : MonoBehaviour
    {
        public float updateSeconds = 1;
        public float moveAmount = 0.1f;

        //animation curve with a serialised value(shows in the editor but still private - not accessible from anywhere else)
        [SerializeField]
        private AnimationCurve m_curve;

        //refrence to object's transform 
        private Transform m_transform;

        // Use this for initialization
        void Start()
        {
            m_transform = transform;
            InvokeRepeating(nameof(UpdateMover), 0, updateSeconds);
        }
        
        void UpdateMover()
        {
            //Step();
            //StepArrayProbability();
            //StepPercentage();
            //StepCurve();
            StepVectorProbability();
        }

        /// <summary>
        /// randomly asigns a value form 0-3 and based on that value we
        /// assign values to the float variables
        /// </summary>
        private void Step()
        {
            int randomValue = Random.Range(0, 4);

            float xValue = 0;
            float zValue = 0;

            //we assign value to only ONE float
            if (randomValue == 0)
            {
                xValue = moveAmount;
            }
            else if(randomValue == 1)
            {
                xValue = -moveAmount;
            }
            else if(randomValue == 2)
            {
                zValue = moveAmount;
            }
            else
            {
                zValue = -moveAmount;
            }

            //we build a vector out of the floats, we kkep it 0 on y so we move only in x & z planes
            m_transform.position += new Vector3(xValue, 0.0f, zValue);
        }

        /// <summary>
        /// we create a probability value using an array. If we want a value too have more weight
        /// we assign it twice in the array
        /// </summary>
        private void StepArrayProbability()
        {
            int[] arrayOfInts = new int[5];

            //option 0 is assigned to the first 2 elements in the array
            arrayOfInts[0] = 0;
            arrayOfInts[1] = 0;
            arrayOfInts[2] = 1;
            arrayOfInts[3] = 2;
            arrayOfInts[4] = 3;

            //similar to the Step() method, we call a random number and we assign the float,
            //the only difference is the fact that we have a 40% chance to hit 0
            int arrayIndex = Random.Range(0, 5);
            int randomValue = arrayOfInts[arrayIndex];

            //the rest is similar to Step() method

            float xValue = 0;
            float zValue = 0;

            if (randomValue == 0)
            {
                xValue = moveAmount;
            }
            else if (randomValue == 1)
            {
                xValue = -moveAmount;
            }
            else if (randomValue == 2)
            {
                zValue = moveAmount;
            }
            else
            {
                zValue = -moveAmount;
            }

            m_transform.position += new Vector3(xValue, 0.0f, zValue);
        }


        /// <summary>
        /// in this method we get a random float from 0-1, we can assign the weight 
        /// based on the procentage - 0.25f means 25% chance
        /// </summary>
        private void StepPercentage()
        {
            float randomValue = Random.Range(0.0f, 1.0f);
            float xValue = 0;
            float zValue = 0;

            if (randomValue < 0.25f)//here we change the weight
            {
                xValue = moveAmount;
            }
            else if (randomValue < 0.5f)//here we change the weight
            {
                xValue = -moveAmount;
            }
            else if (randomValue < 0.75f)//here we change the weight
            {
                zValue = moveAmount;
            }
            else //this is what's lef all the way to 1
            {
                zValue = -moveAmount;
            }

            m_transform.position += new Vector3(xValue, 0.0f, zValue);
        }

        /// <summary>
        /// we use a curve to get the random value. Tha advantage with a curve is the fact that we can control 
        /// probability very easily.
        /// 1. Add an animation curve variable to the script.
        /// 2. Make it private but serializable(so we can modify it in the inspector)
        /// 3. Generate a random float between 0-1 and avaluate it on the curve
        /// 4. It will return a value based on the curve shape
        /// NOTE: 
        /// x axis - random value generated 
        /// y axis - evaluated value returned from the curve
        /// </summary>
        private void StepCurve()
        {
            //generate a random number and evaluate the curve
            float randomCurve = Random.Range(0.0f, 1.0f);
            float randomValue = m_curve.Evaluate(randomCurve);

            //the rest is the same as the previous methods
            float xValue = 0;
            float zValue = 0;

            //make sure the weights are equaly distributed so we have a uniform picking,
            //the probability will come from the shape of the curve
            if (randomValue < 0.25f)
            {
                xValue = moveAmount;
            }
            else if (randomValue < 0.5f)
            {
                xValue = -moveAmount;
            }
            else if (randomValue < 0.75f)
            {
                zValue = moveAmount;
            }
            else
            {
                zValue = -moveAmount;
            }

            m_transform.position += new Vector3(xValue, 0.0f, zValue);
        }

        /// <summary>
        /// step with probability, using a vector, modifying the range will influence the direction
        /// of travel. x axis: -0.1 means left, 0.1 means right, 0 means no movement
        /// z axis: -0.1 means down, 0.1 means up, 0 means no movement
        /// </summary>
        private void StepVectorProbability()
        {
            //generate the random value on the 2 axis
            float xValue = Random.Range(-moveAmount, moveAmount);
            float zValue = Random.Range(-moveAmount, moveAmount);

            //apply the movement to the player 
            m_transform.position += new Vector3(xValue, 0.0f, zValue);
        }
    }
}
