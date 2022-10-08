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
    public Text position;

    // Fields for holding checkpoints
    [SerializeField]
    ADTLinkedList.LinkedList<GameObject> AICheckpoints;
    public GameObject checkpointHolder;
    public int ckpCount = 17;

    // Fields for holding racers
    ADTLinkedList.LinkedList<GameObject> racers;
    public GameObject racerHolder;
    public int rcCount = 3;

    // Position tracker
    [SerializeField]
    private GameObject[] racerPositions;

    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Gather all checkpoints
        AICheckpoints = new ADTLinkedList.LinkedList<GameObject>();

        AICheckpoints.AddToHead(checkpointHolder.transform.GetChild(0).gameObject);
        for (int i = 1; i < ckpCount; i++)
        {
            AICheckpoints.AddToTail(checkpointHolder.transform.GetChild(i).gameObject);
        }

        // Gather all racers
        racers = new ADTLinkedList.LinkedList<GameObject>();

        racers.AddToHead(racerHolder.transform.GetChild(0).gameObject);
        for (int i = 1; i < rcCount; i++)
        {
            racers.AddToTail(racerHolder.transform.GetChild(i).gameObject);
        }

        // Reset position tracking
        racerPositions = new GameObject[rcCount];

        // Populate array
        for (int i = 0; i < rcCount; i++)
        {
            racerPositions[i] = racers.SearchForIndex(i);
        }

        // Reset UI
        resultsImage.gameObject.SetActive(false);
        resultsText = resultsImage.transform.GetChild(0).gameObject.GetComponent<Text>();
        resultsText.text = "";
    }

    public void GetCurrentPositions()
    {
        GameObject temp;

        // Order array
        for (int i = rcCount; i >= 0; i--)
        {
            for (int j = 0; j < rcCount - 1; j++)
            {
                // Check current checkpoint values
                if (racerPositions[j].GetComponent<Racer>().currentInt < racerPositions[j + 1].GetComponent<Racer>().currentInt)
                {
                    temp = racerPositions[j];
                    racerPositions[j] = racerPositions[j + 1];
                    racerPositions[j + 1] = temp;
                }
            }
        }

        for (int i = 1; i <= rcCount; i++)
        {
            racerPositions[i - 1].GetComponent<Racer>().position = i;
        }

        DisplayPlayerPosition();
    }

    private void DisplayPlayerPosition()
    {
        string append = "";
        int playerPos = player.GetComponent<Racer>().position;

        switch (playerPos)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            default:

                break;
        }
    }

    public GameObject NextAICheckpoint(GameObject current)
    {
        return AICheckpoints.SearchForNext(current);
    }
}
