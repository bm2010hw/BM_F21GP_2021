using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movements : MonoBehaviour
{

    public CharacterController controller;

    public float MoveSpeed = 10f;
    public float gravity = -20f;
    public float jumpHeight = 0.8f;

    public Transform groundCheck;
    public float groundDistance = 0.15f;
    public LayerMask groundMask;
    public LayerMask trapMask;

    Vector3 velocity;
    bool isGrounded;
    bool isDead;

    float x;
    float z;

    // Update is called once per frame
    void Update()
    {

        //Detect if the player move forward or backward
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            z = 1f;
        } else if (Input.GetKey(KeyCode.S))
        {
            z = -1f;
        } else
        {
            z = 0f;
        }

        //Detect if the player move left or right
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            x = -1f;
        }else if (Input.GetKey(KeyCode.D))
        {
            x = 1f;
        } else
        {
            x = 0f;
        }

        Vector3 moveXZ = this.transform.right * x + this.transform.forward * z;


        //Detect if the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        //Detect if the player is on the ground and if so reduce its y velocity to -8 to make him stick to the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -8f;
        }


        //Move the player, move is for its x and z axis and velocity for its y axis
        controller.Move(moveXZ * MoveSpeed * Time.deltaTime + velocity * Time.deltaTime);

        //here detects death by falling or touching trap
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, trapMask) || this.transform.position.y < -1f;

        if (isDead)
        {
            GetComponent<movements>().enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }


    }
}
