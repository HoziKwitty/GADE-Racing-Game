using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public float rightSpeed = 5f;

    public float rightMove;
    public Vector3 moveDelta;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rightMove = 0;

        if (Input.GetKey(KeyCode.A))
        {
            rightMove = -1 * rightSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rightMove = rightSpeed;
        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * speed * Time.fixedDeltaTime + 
                    transform.right * rightMove * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDelta);
    }
}
