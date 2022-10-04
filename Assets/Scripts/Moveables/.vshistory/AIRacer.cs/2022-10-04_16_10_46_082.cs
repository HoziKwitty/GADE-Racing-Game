using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    public float speed = 70f;
    public float turnSpeed = 5f;

    private NavMeshAgent nma;

    public Transform checkpoint;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();

        nma.speed = speed;
        nma.angularSpeed = turnSpeed;
    }

    private void Update()
    {
        nma.destination = checkpoint.position;
    }
}
