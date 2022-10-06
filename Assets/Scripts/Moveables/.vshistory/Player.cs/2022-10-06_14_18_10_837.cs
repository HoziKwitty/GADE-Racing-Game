using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vertMove;
    public float vertSpeed;

    public float horizMove;
    public float horizSpeed;

    public Vector2 deltaMove;

    private Rigidbody rb;

    private void Start()
    {
        rb = transform.GetChild(0).transform.GetComponent<Rigidbody>();

        rb.transform.parent = null;
    }

    private void Update()
    {
        vertMove = vertSpeed * Input.GetAxis("Vertical");
        horizMove = horizSpeed * Input.GetAxis("Horizontal");

        deltaMove = new Vector2(vertSpeed, horizSpeed);
    }

    private void FixedUpdate()
    {
        transform.position = rb.transform.position;

        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }
}
