using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float driveSpeed = 200f;
    public float brakeSpeed = 50f;
    public float turnSpeed = 30f;

    public float vertMove;
    public float horizMove;

    private Rigidbody rb;

    private void Start()
    {
        rb = transform.GetChild(0).transform.GetComponent<Rigidbody>();

        rb.transform.parent = null;
    }

    private void Update()
    {
        vertMove = Input.GetAxis("Vertical");
        horizMove = Input.GetAxis("Horizontal");

        if (vertMove > 0)
        {
            vertMove *= driveSpeed;
        }
        else
        {
            vertMove *= brakeSpeed;
        }

        transform.position = rb.transform.position;

        transform.Rotate(0f, 0, 0f, Space.World);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }
}
