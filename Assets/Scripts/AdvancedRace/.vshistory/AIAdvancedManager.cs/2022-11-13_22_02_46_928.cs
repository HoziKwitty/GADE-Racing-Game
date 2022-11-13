using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ADTLinkedList;

public class AIAdvancedManager : MonoBehaviour
{
    // Singleton
    public static AIAdvancedManager instance;

    // UI References
    public Image resultsImage;
    private Text resultsText;

    public Image positionImage;
    public Text position;
    public List<Sprite> positionSprites;

    public Text lapText;

    // Object references
    public GameObject player;

    // Fields for holding checkpoints
    [SerializeField]
    ADTLinkedList.LinkedList<GameObject> AICheckpoints;

    public GameObject checkpointHolder;
    public int ckpCount = 50;
    private GameObject[] checkpoints;

    // Fields for holding racers
    ADTLinkedList.LinkedList<GameObject> racers;
    public GameObject racerHolder;
    public int rcCount;

    // Position tracker
    [SerializeField]
    private GameObject[] racerPositions;

    // Graph reference
    public Graph graph;
    private int gLength = 50;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Gather all racers
        racers = new ADTLinkedList.LinkedList<GameObject>();

        racers.AddToHead(racerHolder.transform.GetChild(0).gameObject);
        for (int i = 1; i < rcCount; i++)
        {
            racers.AddToTail(racerHolder.transform.GetChild(i).gameObject);
        }

        // Gather all checkpoints
        checkpoints = new GameObject[ckpCount];
        for (int i = 0; i < ckpCount; i++)
        {
            checkpoints[i] = checkpointHolder.transform.GetChild(i).gameObject;
        }

        // Reset graph
        graph = new Graph();

        CreateNodeArray(gLength);
        CreateEdgeArray();

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

        position = positionImage.transform.GetChild(0).gameObject.GetComponent<Text>();

        lapText.text = "1 / 3";
    }

    private void Update()
    {
        if (player.transform.position.y <= -10)
        {
            resultsImage.gameObject.SetActive(true);
            resultsText.text = "Out of Bounds!";

            Time.timeScale = 0;
        }
    }

    public void GetCurrentPositions()
    {


        DisplayPlayerPosition();
    }

    private void DisplayPlayerPosition()
    {
        string append = "";
        int playerPos = player.GetComponent<Racer>().position;

        switch (playerPos)
        {
            case 1:
                append = "ST";
                positionImage.sprite = positionSprites[0];
                break;
            case 2:
                append = "ND";
                positionImage.sprite = positionSprites[1];
                break;
            case 3:
                append = "RD";
                positionImage.sprite = positionSprites[2];
                break;
            default:
                append = "TH";
                positionImage.sprite = positionSprites[3];
                break;
        }

        position.text = playerPos + append;
    }

    public GameObject NextAICheckpoint(GameObject current)
    {
        GameObject nextCheckpoint = null;

        // Get all neighbours of current checkpoint
        ADTLinkedList.LinkedList<GraphNode> neighbours = graph.FindAllNeighbours(current.GetComponent<AICheckpoint>().value);

        // Choose random neighbour
        int rnd = Random.Range(0, neighbours.Size);
        Debug.Log(rnd);

        // Get the next GraphNode
        GraphNode next = neighbours.SearchForIndex(rnd);
        int nextIndex = next.Data;

        // Find matching checkpoint in array
        for (int i = 0; i < ckpCount; i++)
        {
            // Check if indices match
            if (checkpoints[i].GetComponent<AICheckpoint>().value == nextIndex)
            {
                nextCheckpoint = checkpoints[i];
            }
        }

        return nextCheckpoint;
    }

    public void UpdateLapCounter(int lapCount)
    {
        if (lapCount == 4)
        {
            resultsImage.gameObject.SetActive(true);
            resultsText.text = "Race Finished!";

            Time.timeScale = 0;
        }
        else
        {
            lapText.text = lapCount + " / 3";
        }
    }

    private void CreateNodeArray(int number)
    {
        // Create nodes
        for (int i = 1; i <= number; i++)
        {
            graph.CreateNode(i);
        }

        // Buffer node
        graph.CreateNode(-1);
    }

    private void CreateEdgeArray()
    {
        // First fork
        graph.CreateEdge(1, 2);
        graph.CreateEdge(1, 11);

        // Choice 1
        graph.CreateEdge(2, 3);
        graph.CreateEdge(3, 4);
        graph.CreateEdge(4, 5);
        graph.CreateEdge(5, 6);
        graph.CreateEdge(6, 7);
        graph.CreateEdge(7, 8);
        graph.CreateEdge(8, 9);
        graph.CreateEdge(9, 10);

        // Choice 2
        graph.CreateEdge(11, 12);
        graph.CreateEdge(12, 13);
        graph.CreateEdge(13, 14);
        graph.CreateEdge(14, 15);
        graph.CreateEdge(15, 16);
        graph.CreateEdge(16, 17);
        graph.CreateEdge(17, 18);
        graph.CreateEdge(18, 19);

        // First merge
        graph.CreateEdge(10, 20);
        graph.CreateEdge(19, 20);
        graph.CreateEdge(20, 21);
        graph.CreateEdge(21, 22);
        graph.CreateEdge(22, 23);
        graph.CreateEdge(23, 24);
        graph.CreateEdge(24, 25);
        graph.CreateEdge(25, 26);
        graph.CreateEdge(26, 27);
        graph.CreateEdge(27, 28);

        // Second fork
        graph.CreateEdge(28, 29);
        graph.CreateEdge(28, 40);

        // Choice 1
        graph.CreateEdge(29, 30);
        graph.CreateEdge(30, 31);
        graph.CreateEdge(31, 32);
        graph.CreateEdge(32, 33);
        graph.CreateEdge(33, 34);
        graph.CreateEdge(34, 35);
        graph.CreateEdge(35, 36);
        graph.CreateEdge(36, 37);
        graph.CreateEdge(37, 38);
        graph.CreateEdge(38, 39);

        // Choice 3
        graph.CreateEdge(40, 41);
        graph.CreateEdge(41, 42);
        graph.CreateEdge(42, 43);
        graph.CreateEdge(43, 44);
        graph.CreateEdge(44, 45);
        graph.CreateEdge(45, 46);
        graph.CreateEdge(46, 47);
        graph.CreateEdge(47, 48);
        graph.CreateEdge(48, 49);
        graph.CreateEdge(49, 50);

        // Second merge
        graph.CreateEdge(39, 1);
        graph.CreateEdge(50, 1);
    }
}
