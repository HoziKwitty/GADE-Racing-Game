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
            StartCoroutine(WaitToEnter(0.3f));
            entered = true;

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

            if (gameObject.CompareTag("AI"))
            {
                nma.destination = currentCheckpoint.transform.position;
            }

            currentInt = int.Parse(currentCheckpoint.name) - 1;

            AICheckpointManager.instance.GetCurrentPositions();
        }
        else if (other.gameObject.CompareTag("LapIterator") && !entered)
        {
            StartCoroutine(WaitToEnter(5));
            entered = true;

            AICheckpointManager.instance.UpdateLapCounter();
        }
    }

    private IEnumerator WaitToEnter(float time)
    {
        yield return new WaitForSeconds(time);

        entered = false;
    }
}
