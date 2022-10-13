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
    public int currentLap;

    public bool entered = false;

    public virtual void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        {
            entered = true;
            StartCoroutine(WaitToEnter(0.3f));

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

            // Give the AI the new destination
            if (gameObject.CompareTag("AI"))
            {
                nma.destination = currentCheckpoint.transform.position;
            }

            // Get the current lap
            int parsedCheckpoint = int.Parse(currentCheckpoint.name);
            if (parsedCheckpoint == 26)
            {
                currentLap++;

                if (gameObject.CompareTag("Hero"))
                {
                    AICheckpointManager.instance.UpdateLapCounter(currentLap);
                }
            }
            currentInt = parsedCheckpoint - 1;

            // Update the racers' positions
            AICheckpointManager.instance.GetCurrentPositions();
        }
    }

    private IEnumerator WaitToEnter(float time)
    {
        yield return new WaitForSeconds(time);

        entered = false;
    }
}
