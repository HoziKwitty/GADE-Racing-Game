using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent nma;

    public Transform checkpoint;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.destination = 
    }
}
