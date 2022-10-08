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

        results.text = "";
    }
    
    public GameObject NextAICheckpoint(GameObject current, int index)
    {
        return AICheckpoints.Search(current, index);
    }
}
