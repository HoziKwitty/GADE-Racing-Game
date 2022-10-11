using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Racer : MonoBehaviour
{
    public int position;

    protected NavMeshAgent nma;

    public GameObject currentCheckpoint;
    public int currentInt;

    public bool entered = false;

    public virtual void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        {
            StartCoroutine(WaitToEnter());

            entered = true;

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

            if (gameObject.CompareTag("AI"))
            {
                nma.destination = currentCheckpoint.transform.position;
            }

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
