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

        if (vertMove > 0)
        {
            vertMove *= driveSpeed;
        }
        else
        {
            vertMove *= brakeSpeed;
        }
    }

    private void FixedUpdate()
    {
        transform.position = rb.transform.position;

        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }
}
