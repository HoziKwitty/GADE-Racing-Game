using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 90f;
    public float rightSpeed = 5f;
    public float brakeSpeed = 20f;

    public float forwardMove;
    public float rightMove;

    public Vector3 moveDelta;

    public float turnDegree = 0.2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            AICheckpointManager.instance.results.text = "Out of bounds!";

            Time.timeScale = 0;
        }

        forwardMove = 0;
        rightMove = 0;

        if (Input.GetKey(KeyCode.W))
        {
            forwardMove = forwardSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rightMove = -1 * rightSpeed;
            transform.Rotate(new Vector3(0f, -1f * turnDegree, 0f), Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rightMove = rightSpeed;
            transform.Rotate(new Vector3(0f, turnDegree, 0f), Space.Self);
        }
    }

    private void FixedUpdate()
    {
        moveDelta = transform.forward * forwardMove * Time.fixedDeltaTime + 
                    transform.right * rightMove * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDelta);
    }
}
