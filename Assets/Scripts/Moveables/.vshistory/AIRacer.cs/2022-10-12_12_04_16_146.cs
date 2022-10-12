using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public float speed;

    public float min = 50f;
    public float max = 80f;

    public override void Start()
    {
        base.Start();

        speed = Random.Range(min, max);

        nma.destination = currentCheckpoint.transform.position;
    }
}
