using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    public float forwardSpeed = 90f;
    public float brakeSpeed = 0f;
    //public float rightSpeed = 5f;

    public float forwardInput;
    public float sidewaysInput;

    //public float forwardMove;
    //public float rightMove;

    //public Vector3 moveDelta;

    //public float turnDegree = 0.2f;

    // References
    private Rigidbody rb;

    private WheelCollider frontLeft;
    private WheelCollider frontRight;
    private WheelCollider backLeft;
    private WheelCollider backRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        sidewaysInput = Input.GetAxis("Horizontal");

        //if (transform.position.y <= 0)
        //{
        //    AICheckpointManager.instance.results.text = "Out of bounds!";

        //    Time.timeScale = 0;
        //}

        //forwardMove = 0;
        //rightMove = 0;

        //if (Input.GetKey(KeyCode.W))
        //{
        //    forwardMove = forwardSpeed;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    rightMove = -1 * rightSpeed;
        //    transform.Rotate(new Vector3(0f, -1f * turnDegree, 0f), Space.Self);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    rightMove = rightSpeed;
        //    transform.Rotate(new Vector3(0f, turnDegree, 0f), Space.Self);
        //}
    }

    private void FixedUpdate()
    {
        frontLeft.motorTorque = forwardInput * forwardSpeed;
        frontRight.motorTorque = forwardInput * forwardSpeed;

        //moveDelta = transform.forward * forwardMove * Time.fixedDeltaTime + 
        //            transform.right * rightMove * Time.fixedDeltaTime;

        //rb.MovePosition(rb.position + moveDelta);
    }
}
