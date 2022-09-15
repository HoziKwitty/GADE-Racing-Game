using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            CheckpointManager.instance.NextCheckpoint(gameObject);

            Timer.instance.GetCurrentTime += 3f;

            Destroy(gameObject, 3f);
        }
    }
}
