using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent nma;

    public GameObject currentCheckpoint;
    private GameObject nextCheckpoint;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AICheckpoint"))
        {
            nextCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);
            nma.destination = nextCheckpoint.transform.position;
            currentCheckpoint = nextCheckpoint;
        }
    }
}
