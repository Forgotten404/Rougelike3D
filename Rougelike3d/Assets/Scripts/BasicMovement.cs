using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public Rigidbody rb;
    float gravityModifier = 1.8f;
    Vector3 x, z;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //-----Inputs-----//
        x = transform.right * Input.GetAxisRaw("Horizontal");
        z = transform.forward * Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

 
    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        Vector3 movement = (x + z).normalized * playerSpeed;
        rb.AddForce(movement, ForceMode.Acceleration);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
