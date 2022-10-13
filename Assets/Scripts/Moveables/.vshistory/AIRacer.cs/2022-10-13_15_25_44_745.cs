using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public float speed;

    public override void Start()
    {
        base.Start();

        nma.destination = currentCheckpoint.transform.position;
        nma.speed = speed;
    }
}
