using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherYatesShuffle : MonoBehaviour
{
    private void Start()
    {
        Shuffle();
    }

    private void Shuffle()
    {
        int[] numberArray = { 0,1,2,3,4,5,6,7,8,9 };

        int i = 10;

        while (i>0)
        {
            int randomNumber = Random.Range(0, i-1);
           
            // if
            // temp = 9
            int temp = numberArray[i-1];
            // numberArray[9] = numberArray[8]
            numberArray[i - 1] = numberArray[randomNumber];
            // numberArray[8] = temp
            numberArray[randomNumber] = temp;

            i--;
        }
        foreach (int n in numberArray)
        {
            Debug.Log(numberArray[n]);
        }
    }
}
