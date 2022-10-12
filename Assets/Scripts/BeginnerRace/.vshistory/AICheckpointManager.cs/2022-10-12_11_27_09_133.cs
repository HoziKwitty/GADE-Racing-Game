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

    public Image positionImage;
    public Text position;
    public List<Sprite> positionSprites;

    public int lapCount = 1;

    // Object references
    public GameObject player;

    // Fields for holding checkpoints
    [SerializeField]
    ADTLinkedList.LinkedList<GameObject> AICheckpoints;

    public GameObject checkpointHolder;
    public int ckpCount = 22;

    // Fields for holding racers
    ADTLinkedList.LinkedList<GameObject> racers;
    public GameObject racerHolder;
    public int rcCount = 3;

    // Position tracker
    [SerializeField]
    private GameObject[] racerPositions;

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

        position = positionImage.transform.GetChild(0).gameObject.GetComponent<Text>();
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

    public GameObject NextAICheckpoint(GameObject current, string name)
    {
        GameObject returnCheckpoint = AICheckpoints.SearchForNext(current);

        if (name.Equals("Player") && returnCheckpoint.name.Equals("1"))
        {
            if (lapCount == 3)
            {
                Time.timeScale = 0;
            }
            lapCount++;
        }

        return returnCheckpoint;
    }
}
