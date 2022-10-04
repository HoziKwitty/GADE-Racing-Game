using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent nma;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }
}
