using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    private int[] sortArray = { 78, 55, 45, 98, 13 };

    private void Start()
    {
        bbSort();
    }

    private void bbSort()
    {
        int temp = 0;

        for (int i = 0; i < sortArray.Length; i++)
        {
            for (int j = 0; j < sortArray.Length-1; j++)
            {
                if (sortArray[j] > sortArray[j + 1])
                {
                    temp = sortArray[j+1];
                    sortArray[j + 1] = sortArray[j];
                    sortArray[j] = temp;
                }
            }
        }
    }
}
