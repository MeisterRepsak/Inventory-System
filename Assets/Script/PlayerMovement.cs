using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float speed;

    float xAxis;
    float zAxis; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {
        Vector3 movement = transform.forward * zAxis + transform.right * xAxis;
        movement.Normalize();
        movement *= speed;
        movement += new Vector3(0, rb.velocity.y, 0);
        rb.velocity = movement;
    }
}
