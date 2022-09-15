using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 moveDelta;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton(KeyCode.A))
        {

        }
        else if ()
        {

        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDelta);
    }
}
