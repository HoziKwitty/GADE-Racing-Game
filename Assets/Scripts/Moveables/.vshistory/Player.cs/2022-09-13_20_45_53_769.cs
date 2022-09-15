using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    public float forwardMove;
    public float sideMove;
    public Vector3 moveDelta = new Vector3();

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        forwardMove = 0;
        sideMove = 0;

        if (Input.GetKey(KeyCode.W))
        {
            forwardMove = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forwardMove = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            sideMove = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sideMove = 1;
        }
    }

    private void FixedUpdate()
    {
        moveDelta += transform.forward * forwardMove * Time.fixedDeltaTime;
        moveDelta += transform.right * sideMove * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDelta);
    }
}
