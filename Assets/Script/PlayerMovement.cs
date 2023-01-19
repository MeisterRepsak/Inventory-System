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

    public bool isInterrupted;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        if(isInterrupted && !Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!isInterrupted && Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (isInterrupted)
            return;
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (isInterrupted)
            return;
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
