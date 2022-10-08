using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ADTLinkedList;

public class AICheckpointManager : MonoBehaviour
{
    // Singleton
    public static AICheckpointManager instance;

    // UI References
    public Image resultsImage;
    private Text resultsText;

    // Fields for holding checkpoints
    [SerializeField]
    ADTLinkedList.LinkedList<GameObject> AICheckpoints;
    public GameObject checkpointHolder;
    public int count = 17;

    ADTLinkedList.LinkedList<GameObject> racers;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AICheckpoints = new ADTLinkedList.LinkedList<GameObject>();

        AICheckpoints.AddToHead(checkpointHolder.transform.GetChild(0).gameObject);

        for (int i = 1; i < count; i++)
        {
            AICheckpoints.AddToTail(checkpointHolder.transform.GetChild(i).gameObject);
        }

        resultsImage.gameObject.SetActive(false);
        resultsText = resultsImage.transform.GetChild(0).gameObject.GetComponent<Text>();
        resultsText.text = "";
    }
    
    public GameObject NextAICheckpoint(GameObject current)
    {
        return AICheckpoints.Search(current);
    }
}
