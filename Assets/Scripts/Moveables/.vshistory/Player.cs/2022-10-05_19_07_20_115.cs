using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    public float forwardSpeed = 700f;
    public float brakeSpeed = 1400f;
    public float steerSpeed = 60f;
    //public float rightSpeed = 5f;

    public float forwardInput;
    public float sidewaysInput;

    public bool isBreaking;

    //public float forwardMove;
    //public float rightMove;

    //public Vector3 moveDelta;

    //public float turnDegree = 0.2f;

    // References
    private Rigidbody rb;

    public WheelCollider frontLeftCol;
    public WheelCollider frontRightCol;
    public WheelCollider backLeftCol;
    public WheelCollider backRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get forwards/backwards and sideways inputs
        forwardInput = Input.GetAxis("Vertical");
        sidewaysInput = Input.GetAxis("Horizontal");

        // Check if braking
        if (Input.GetKey(KeyCode.LeftShift))
        {
            brakeSpeed = 1400f;
        }
        else
        {
            brakeSpeed = 0f;
        }

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
        // Apply engine force (only to front wheels)
        frontLeftCol.motorTorque = forwardInput * forwardSpeed;
        frontRightCol.motorTorque = forwardInput * forwardSpeed;

        // Apply brake force
        frontLeftCol.brakeTorque = brakeSpeed;
        frontRightCol.brakeTorque = brakeSpeed;
        backLeftCol.brakeTorque = brakeSpeed;
        backRight.brakeTorque = brakeSpeed;

        // Apply steering (only to front wheels)
        steerSpeed *= sidewaysInput;
        frontLeftCol.steerAngle = steerSpeed;
        frontRightCol.steerAngle = steerSpeed;

        // Update each wheel's direction
        UpdateWheelRotation(frontLeftCol, frontLeftCol.gameObject.transform);
        UpdateWheelRotation(frontRightCol, frontRightCol.gameObject.transform);
        UpdateWheelRotation(backLeftCol, backLeftCol.gameObject.transform);
        UpdateWheelRotation(backRight, backRight.gameObject.transform);

        //moveDelta = transform.forward * forwardMove * Time.fixedDeltaTime + 
        //            transform.right * rightMove * Time.fixedDeltaTime;

        //rb.MovePosition(rb.position + moveDelta);
    }

    private void UpdateWheelRotation(WheelCollider col, Transform trans)
    {
        Vector3 inPosition;
        Quaternion inRotation;

        col.GetWorldPose(out inPosition, out inRotation);
        trans.rotation = inRotation;
        trans.position = inPosition;
    }
}
