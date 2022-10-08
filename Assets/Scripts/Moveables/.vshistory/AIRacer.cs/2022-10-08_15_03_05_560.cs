using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public int position;

    private NavMeshAgent nma;

    public GameObject currentCheckpoint;
    public int currentInt;

    public bool entered = false;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        {
            StartCoroutine(WaitToEnter());

            entered = true;

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);
            nma.destination = currentCheckpoint.transform.position;

            currentInt = int.Parse(currentCheckpoint.name) - 1;

            AICheckpointManager.instance.GetCurrentPositions();
        }
    }

    private IEnumerator WaitToEnter()
    {
        yield return new WaitForSeconds(0.3f);

        entered = false;
    }
}
