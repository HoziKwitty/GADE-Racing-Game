using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public int count = 0;

    [SerializeField]
    List<GameObject> checkpoints;

    [SerializeField]
    Stack<GameObject> checkpointsStack;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
