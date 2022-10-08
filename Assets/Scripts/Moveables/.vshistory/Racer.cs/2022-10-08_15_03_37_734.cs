using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
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
}
