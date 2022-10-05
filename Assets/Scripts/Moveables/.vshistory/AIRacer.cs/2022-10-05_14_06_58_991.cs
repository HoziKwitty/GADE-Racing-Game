using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent nma;

    public GameObject currentCheckpoint;

    public bool entered = false;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint"))
        {
            Debug.Log("entered");

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);
            nma.destination = currentCheckpoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        //{
        //    entered = true;

        //    Debug.Log("entered");

        //    currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);
        //    nma.destination = currentCheckpoint.transform.position;
        //}
    }
}
