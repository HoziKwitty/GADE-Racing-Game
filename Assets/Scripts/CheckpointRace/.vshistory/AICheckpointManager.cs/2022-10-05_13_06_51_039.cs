using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICheckpointManager : MonoBehaviour
{
    public static AICheckpointManager instance;

    public Text results;

    [SerializeField]
    LinkedList<GameObject> AICheckpoints;

    public GameObject checkpointHolder;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AICheckpoints = new LinkedList<GameObject>();

        results.text = "";
    }
    
    public void NextAICheckpoint(GameObject AICheckpoint)
    {
        
    }
}
