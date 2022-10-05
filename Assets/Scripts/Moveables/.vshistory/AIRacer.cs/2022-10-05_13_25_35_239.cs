using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent nma;

    public Transform currentCheckpoint;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AICheckpoint"))
        {
            AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);
        }
    }
}
