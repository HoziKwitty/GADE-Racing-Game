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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AICheckpoints = new ADTLinkedList.LinkedList<GameObject>();

        AICheckpoints

        results.text = "";
    }
    
    public void NextAICheckpoint(GameObject AICheckpoint)
    {
        
    }
}
