using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float rightSpeed = 5f;

    public float forwardMove;
    public float rightMove;

    public Vector3 moveDelta;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        forwardMove = 0;
        rightMove = 0;

        if (Input.GetKey(KeyCode.W))
        {
            forwardMove = rightSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forwardMove = -1 * rightSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rightMove = -1 * rightSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rightMove = rightSpeed;
        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * forwardMove * Time.fixedDeltaTime + 
                    transform.right * rightMove * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDelta);
    }
}
