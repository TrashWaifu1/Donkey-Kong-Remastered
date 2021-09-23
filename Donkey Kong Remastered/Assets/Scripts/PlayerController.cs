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
    Quaternion Rotation;

    void Update()
    {

        Velocity = RB.velocity;
        Velocity.z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Velocity.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        RB.velocity = Velocity;



        Rotation = transform.rotation;
        Rotation.y = Input.mousePosition.x * Sensitivity * Time.deltaTime;

        print(Rotation);

        transform.rotation = Rotation;
    }
}
