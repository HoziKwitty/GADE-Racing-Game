using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float driveSpeed = 200f;
    public float brakeSpeed = 400f;

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
        vertMove = driveSpeed * Input.GetAxis("Vertical");
        //horizMove = horizSpeed * Input.GetAxis("Horizontal");

        if (vertMove > 0)
        {
            vertMove = driveSpeed;
        }
        else
        {
            vertMove = brakeSpeed;
        }
    }

    private void FixedUpdate()
    {
        transform.position = rb.transform.position;

        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }
}
