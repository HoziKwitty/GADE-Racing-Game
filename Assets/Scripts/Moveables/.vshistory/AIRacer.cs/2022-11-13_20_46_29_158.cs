using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public int speed;

    public override void Start()
    {
        base.Start();

        nma.enabled = true;
        nma.destination = currentCheckpoint.transform.position;
        nma.speed = speed;
    }
}
