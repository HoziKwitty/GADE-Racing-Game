using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    public float horizMove;
    public Vector3 moveDelta;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        horizMove = 0;

        if (Input.GetKey(KeyCode.A))
        {
            horizMove = -1 * sideSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizMove = sideSpeed;
        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        moveDelta += transform.right * horizMove * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDelta);
    }
}
