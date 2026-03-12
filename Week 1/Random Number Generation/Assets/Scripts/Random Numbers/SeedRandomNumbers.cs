using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* SeedRandomNumbers
 * Create a list of predictable random numbers from a seed
 * 
 */

public class SeedRandomNumbers : MonoBehaviour
{
    public Text randomNumberText;

    // the Random class can be initialised with a number, called a 'seed'
    // the Random.Range method will give a predictable list of numbers if a seed is used
    public int seed = 0;

    // the amount of random numbers we want to create
    public int amountOfNumbers = 5;

    //public Random.State state;

    public List<int> listOfRandomNumbers = new List<int>();
    
    void Start()
    {
        // here we call InitState on the Random class to give it the seed
        // Random.Range will now always create the same numbers in the same order
        Random.InitState(seed);

        listOfRandomNumbers.Clear();

        for (int i = 0; i < amountOfNumbers; i++)
        {
            // every time we call Random.Range, it will give the next number in the predictable list
            int randomNumber = Random.Range(0, 100);

            randomNumberText.text += randomNumber.ToString() + "\n";

            listOfRandomNumbers.Add(randomNumber);
        }

        //state = Random.state;
    }
}
