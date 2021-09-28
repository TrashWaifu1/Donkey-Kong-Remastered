using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumFall : MonoBehaviour
{
    public AudioClip bang;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fall")
        {
            Debug.Log("bang");
        }
    }
}
