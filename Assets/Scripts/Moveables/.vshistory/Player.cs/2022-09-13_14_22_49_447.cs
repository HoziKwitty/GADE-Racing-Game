using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float horizSpeed = 5f;

    public float horizMove;
    public Vector3 moveDelta;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizMove = 1;

        if (Input.GetKeyDown(KeyCode.A))
        {
            horizMove = -1 * horizSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            horizMove = horizSpeed;
        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * speed * Time.fixedDeltaTime;
        moveDelta += transform.right * horizMove * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDelta);
    }
}
