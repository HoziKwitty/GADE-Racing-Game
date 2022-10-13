using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Racer : MonoBehaviour
{
    public int position;

    protected NavMeshAgent nma;

    [HideInInspector]
    public GameObject currentCheckpoint;
    public int currentInt;
    public int currentLap;

    public bool entered = false;

    public virtual void Start()
    {
        nma = GetComponent<NavMeshAgent>();

        currentCheckpoint = GameObject.Find("1");
        currentLap = 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICheckpoint") && !entered)
        {
            StartCoroutine(WaitToEnter(1f));

            currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

            // Give the AI the new destination
            if (gameObject.CompareTag("AI"))
            {
                nma.destination = currentCheckpoint.transform.position;
            }

            // Get the current lap
            if (other.gameObject.name.Equals("26"))
            {
                currentLap++;

                if (gameObject.CompareTag("Hero"))
                {
                    AICheckpointManager.instance.UpdateLapCounter(currentLap);
                }
            }
            currentInt = int.Parse(other.gameObject.name) - 1;

            // Update the racers' positions
            AICheckpointManager.instance.GetCurrentPositions();
        }
    }

    private IEnumerator WaitToEnter(float time)
    {
        entered = true;

        yield return new WaitForSeconds(1f);

        entered = false;
    }
}
