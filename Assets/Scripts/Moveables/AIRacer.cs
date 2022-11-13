using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    public int speed;

    private Vector3 spawnAdvanced = new Vector3(0, 1.45f, 5.3f);

    public override void Start()
    {
        base.Start();

        nma.Warp(spawnAdvanced);
        nma.destination = currentCheckpoint.transform.position;
        nma.speed = speed;
    }
}
