using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Racer
{
    public float driveSpeed = 400f;
    public float brakeSpeed = 50f;
    public float turnSpeed = 100f;

    public float vertMove;
    public float horizMove;

    public Vector3 gravityForce = new Vector3(0f, -1f, 0f);

    //public int position;
    //public GameObject currentCheckpoint;
    //public bool entered = false;
    //public int currentInt;

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
        rb.AddForce(gravityForce, ForceMode.Impulse);
        rb.AddForce(transform.forward * vertMove, ForceMode.Acceleration);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("AICheckpoint") && !entered)
    //    {
    //        StartCoroutine(WaitToEnter());

    //        entered = true;

    //        currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

    //        currentInt = int.Parse(currentCheckpoint.name) - 1;

    //        AICheckpointManager.instance.GetCurrentPositions();
    //    }
    //}

    //private IEnumerator WaitToEnter()
    //{
    //    yield return new WaitForSeconds(0.3f);

    //    entered = false;
    //}
}
