using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CheckpointManager.instance.NextCheckpoint(gameObject);

        Timer.instance.GetCurrentTime += 3f;

        Destroy(gameObject);
    }
}
