using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ADTLinkedList;

public class AICheckpointManager : MonoBehaviour
{
    public static AICheckpointManager instance;

    public Text results;

    [SerializeField]
    ADTLinkedList.LinkedList<GameObject> AICheckpoints;

    public GameObject checkpointHolder;
    public int count = 17;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AICheckpoints = new ADTLinkedList.LinkedList<GameObject>();

        AICheckpoints.AddToHead(checkpointHolder.transform.GetChild(0).gameObject);

        for (int i = 1; i < count - 1; i++)
        {
            AICheckpoints.AddToTail(checkpointHolder.transform.GetChild(i).gameObject);
        }

        AICheckpoints.Display();

        results.text = "";
    }
    
    public void NextAICheckpoint(Transform current)
    {

    }
}
