using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vertMove;
    public float vertSpeed;

    public float horizMove;
    public float horizSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = transform.GetChild(0).transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        vertMove = vertSpeed * Input.GetAxis("Vertical");
        horizMove = horizSpeed * Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // Align car to FollowObj
        transform.position = rb.transform.position;
    }
}
