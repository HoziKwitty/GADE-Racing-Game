using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : Racer
{
    //public int position;

    //private NavMeshAgent nma;

    //public GameObject currentCheckpoint;
    //public int currentInt;

    //public bool entered = false;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        nma.destination = currentCheckpoint.transform.position;
    }
}
