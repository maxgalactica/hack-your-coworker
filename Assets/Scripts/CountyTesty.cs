using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountyTesty : MonoBehaviour
{

    int[] set = new int[100];
    List<int> odds = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < set.Length; i++)
        {
            set[i] = i + 1;
        }

        foreach(int num in set)
        {
            if (num % 2 == 0) continue;
            else odds.Add(num);
        }

        foreach(int odd in odds)
        {
            Debug.Log(odd);
        }
    }
}