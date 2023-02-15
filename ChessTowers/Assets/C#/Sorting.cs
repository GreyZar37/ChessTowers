using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{

    int[] arr = { 800, 100, 50, 700, 123, 546, 10 };

    int temp = 0;


    // Start is called before the first frame update
    void Start()
    {
        sorting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sorting()
    {
        for (int write = 0; write < arr.Length; write++)
        {
            for (int sort = 0; sort < arr.Length - 1; sort++)
            {
                if(arr[sort] > arr[sort + 1])
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            print(arr[i] + " ");
        }
    }
   
}
