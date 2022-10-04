using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    public float speed = 70f;

    private NavMeshAgent nma;

    public Transform checkpoint;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();

        nma.speed = this.speed;
    }

    private void Update()
    {
        nma.destination = checkpoint.position;
    }
}
