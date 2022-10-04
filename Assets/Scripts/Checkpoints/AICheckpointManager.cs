using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICheckpointManager : MonoBehaviour
{
    public static AICheckpointManager instance;

    public Text results;

    [SerializeField]
    List<GameObject> AICheckpoints;

    Stack<GameObject> AICheckpointsStack;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AICheckpointsStack = new Stack<GameObject>(AICheckpoints);

        results.text = "";
    }
    
    public void NextAICheckpoint(GameObject AICheckpoint)
    {
        if (AICheckpointsStack.Peek() == null)
        {
            return;
        }
        else if (AICheckpointsStack.Peek() == AICheckpoint)
        {
            AICheckpointsStack.Pop();
        }
    }
}
