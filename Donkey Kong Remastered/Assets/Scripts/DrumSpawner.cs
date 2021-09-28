using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class DrumSpawner : MonoBehaviour
{
    public GameObject drum;
    public float maxRandom = 2;
    public float minRandom;
    public float random;

    void Update()
    {
        if (random <= 0)
        {
            Instantiate(drum, transform);
            RandomNum();
        }

        random -= 1 * Time.deltaTime;
    }

    void RandomNum()
    {
        random = Random.Range(minRandom, maxRandom);
    }
}
