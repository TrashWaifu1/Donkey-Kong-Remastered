using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 3;
    public float speed = 10;
    public float JumpHight = 3;
    public float nockBack = 30;
    public Rigidbody RB;
    public LayerMask groundMask;
    public GameObject pos;

    Vector3 Velocity;
    public bool isGrounded;
    float Gravity = -9.81f * 3;
    float groundDistace = 0.4f;

    void Update()
    {
        #region Movement
        #region directional movment
        Velocity = RB.velocity;
        Velocity += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        RB.velocity = Velocity;
        #endregion
        #region Jump
        isGrounded = Physics.CheckSphere(pos.transform.position, groundDistace, groundMask);

        if (isGrounded && Velocity.y < 0)
            Velocity.y = -2;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHight * -2f * Gravity);
            RB.velocity = Velocity;
        }
        #endregion
        #endregion

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Drum")
        {
            --Health;
            Destroy(collision.transform.gameObject);
            Velocity += Vector3.back * nockBack;
        }
    }
}
