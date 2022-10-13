using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public int speed;

    public int min = 50;
    public int max = 80;

    public override void Start()
    {
        base.Start();

        speed = Random.Range(min, max);

        nma.destination = currentCheckpoint.transform.position;
        nma.speed = speed;
    }

    public override void Update()
    {
        base.Update();
    }
}
