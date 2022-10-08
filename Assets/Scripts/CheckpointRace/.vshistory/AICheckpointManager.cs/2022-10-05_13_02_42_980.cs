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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        results.text = "";
    }
    
    public void NextAICheckpoint(GameObject AICheckpoint)
    {
        
    }
}
