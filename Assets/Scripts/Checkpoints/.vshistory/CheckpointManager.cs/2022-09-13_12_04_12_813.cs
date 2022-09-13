using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public int count = 0;

    [SerializeField]
    List<GameObject> checkpoints;

    Stack<GameObject> checkpointsStack;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        checkpointsStack = new Stack<GameObject>(checkpoints);
    }

    public void NextCheckpoint(GameObject checkpoint)
    {
        if (checkpointsStack.Peek() == checkpoint)
        {
            checkpointsStack.Pop();
        }
    }
}
