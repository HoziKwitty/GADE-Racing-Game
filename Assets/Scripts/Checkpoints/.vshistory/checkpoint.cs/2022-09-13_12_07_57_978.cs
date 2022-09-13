using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("checkpoint");
        CheckpointManager.instance.NextCheckpoint(gameObject);
        timerScript.inst.IncrementTimer();
        Destroy(gameObject);
    }
}
