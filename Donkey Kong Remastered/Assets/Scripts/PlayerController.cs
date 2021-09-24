using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float JumpHight = 3;
    public float Sensitivity = 50;
    public Rigidbody RB;

    Vector3 Velocity;

    void Update()
    {

        Velocity = RB.velocity;
        Velocity.z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Velocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        RB.velocity = Velocity;


        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseX);
    }
}
