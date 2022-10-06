using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float driveSpeed = 400f;
    public float brakeSpeed = 50f;
    public float turnSpeed = 100f;

    public float vertMove;
    public float horizMove;

    public Vector3 gravityForce = new Vector3(0f, -1f, 0f);

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

        transform.Rotate(0f, horizMove * turnSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void FixedUpdate()
    {
        rb.AddForce(0f, -1f, 0f, ForceMode.Impulse);
        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }
}
