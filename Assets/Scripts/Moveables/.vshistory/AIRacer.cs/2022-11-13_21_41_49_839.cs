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

        //Debug.Log(nma.Warp(new Vector3(0, 1.45f, 5.3f)));
        nma.destination = currentCheckpoint.transform.position;
        nma.speed = speed;
    }
}
