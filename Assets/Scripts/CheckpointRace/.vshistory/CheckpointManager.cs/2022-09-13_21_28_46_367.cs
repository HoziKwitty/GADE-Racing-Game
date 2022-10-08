using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Material nextCheckpoint;

    public GameObject leftBarrier;
    public GameObject rightBarrier;

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

        leftBarrier = checkpointsStack.Peek().transform.GetChild(0).gameObject;
        rightBarrier = checkpointsStack.Peek().transform.GetChild(1).gameObject;

        results.text = "";
    }

    public void NextCheckpoint(GameObject checkpoint)
    {
        if (checkpointsStack.Peek() == checkpoint)
        {
            checkpointsStack.Pop();

            if (checkpointsStack.Peek() == null)
            {
                results.text = "You win!";

                Time.timeScale = 0;
            }
        }
    }
}
