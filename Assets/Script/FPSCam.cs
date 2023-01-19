using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
    public float sensitivity;

    float targetXRotation;
    float targetYRotation;

    Transform parent;
    Transform cam;

    PlayerMovement pm;
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main.transform;
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isInterrupted)
            return;
        targetXRotation -= Input.GetAxisRaw("Mouse Y");
        targetYRotation += Input.GetAxisRaw("Mouse X");

        parent.eulerAngles = new Vector3(0, targetYRotation, 0);
        cam.localEulerAngles = new Vector3(targetXRotation, 0, 0);
    }
}
