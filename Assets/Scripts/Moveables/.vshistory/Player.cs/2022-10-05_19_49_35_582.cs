using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.transform.GetChild(0).transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position = rb.transform.position;
    }
}
