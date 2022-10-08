using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Text results;

    private int count = 0;
    public int GetCount 
    { 
        get { return count; } 
        set { count = value; } 
    }

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

        results.text = "";
    }

    public void NextCheckpoint(GameObject checkpoint)
    {
        if (checkpointsStack.Peek() == checkpoint)
        {
            checkpointsStack.Pop();
        }
        else if ()
        {
            checkpoint == null;
        }
    }
}
