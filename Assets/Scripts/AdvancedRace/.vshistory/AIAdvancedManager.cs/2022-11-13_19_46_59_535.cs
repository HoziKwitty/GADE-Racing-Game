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

    // Fields for holding racers
    ADTLinkedList.LinkedList<GameObject> racers;
    public GameObject racerHolder;
    public int rcCount;

    // Position tracker
    [SerializeField]
    private GameObject[] racerPositions;

    // Graph reference
    public Graph graph = GraphCreator.graph;

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
        if (player.transform.position.y <= 48)
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
        GameObject next;

        // Get all neighbours of current checkpoint
        ADTLinkedList.LinkedList<GraphNode> neighbours = graph.FindAllNeighbours(current.GetComponent<AICheckpoint>().value);

        int rnd = Random.Range(0, neighbours.Size);

        int nextIndex = neighbours.SearchForIndex(rnd);

        return null;
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
}
