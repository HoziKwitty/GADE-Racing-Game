using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //print("checkpoint");
        chechpointsss.instance.Nextcheckpoint(gameObject);
        timerScript.inst.IncrementTimer();
        Destroy(gameObject);
    }
}
