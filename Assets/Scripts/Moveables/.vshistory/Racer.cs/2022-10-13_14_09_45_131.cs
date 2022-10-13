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

        currentCheckpoint = GameObject.Find("1");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        {
            entered = true;
            StartCoroutine(WaitToEnter(0.3f));

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

            if (gameObject.CompareTag("AI"))
            {
                nma.destination = currentCheckpoint.transform.position;
            }

            int parsedCheckpoint = int.Parse(currentCheckpoint.name);
            if (parsedCheckpoint == 26)
            {
                currentLap++;
            }
            currentInt = parsedCheckpoint - 1;

            AICheckpointManager.instance.GetCurrentPositions();
        }
        else if (other.gameObject.CompareTag("LapIterator") && gameObject.CompareTag("Hero") && !entered)
        {
            entered = true;
            StartCoroutine(WaitToEnter(5f));

            AICheckpointManager.instance.UpdateLapCounter();
        }
    }

    private IEnumerator WaitToEnter(float time)
    {
        yield return new WaitForSeconds(time);

        entered = false;
    }
}
