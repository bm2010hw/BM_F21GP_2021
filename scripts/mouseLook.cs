using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSens = 80f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        
        xRotation -= mouseY;

        //It's interesting to clamp the xRotation so the player cannot look over its head behind them
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        //make the player rotate with the mouse moving
        playerBody.Rotate(Vector3.up * mouseX);      
        this.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        



    }
}
