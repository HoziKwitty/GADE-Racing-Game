using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.transform.position;
    }
}
