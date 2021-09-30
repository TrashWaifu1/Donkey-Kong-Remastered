using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumFall : MonoBehaviour
{
    public GameObject bang;
    public AudioSource roll;
    public Rigidbody rb;

    private void Update()
    {
        roll.volume = Mathf.Clamp(Mathf.Abs(rb.velocity.z), 0, 1);

        if (transform.position.y < -20)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fall")
        {
            var objec = Instantiate(bang, transform);
            objec.transform.parent = transform;
        }
    }
}