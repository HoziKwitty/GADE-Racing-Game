using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Material nextCheckpoint;

    private GameObject leftBarrier;
    private GameObject rightBarrier;

    public Text results;

    [SerializeField]
    List<GameObject> checkpoints;

    Stack<GameObject> checkpointsStack;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        checkpointsStack = new Stack<GameObject>(checkpoints);

        ChangeCheckpointColour();

        results.text = "";
    }

    public void NextCheckpoint(GameObject checkpoint)
    {
        if (checkpointsStack.Peek() == null)
        {
            return;
        }
        else if (checkpointsStack.Peek() == checkpoint)
        {
            checkpointsStack.Pop();

            if (checkpointsStack.Count == 0)
            {
                results.text = "You win!";

                Time.timeScale = 0;
            }
            else
            {
                ChangeCheckpointColour();
            }
        }
    }

    public void ChangeCheckpointColour()
    {
        leftBarrier = checkpointsStack.Peek().transform.GetChild(0).gameObject;
        rightBarrier = checkpointsStack.Peek().transform.GetChild(1).gameObject;

        leftBarrier.GetComponent<MeshRenderer>().material = nextCheckpoint;
        rightBarrier.GetComponent<MeshRenderer>().material = nextCheckpoint;
    }
}
