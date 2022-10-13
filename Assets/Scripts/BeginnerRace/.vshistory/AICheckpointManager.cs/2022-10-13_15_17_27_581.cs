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

    public Text lapText;

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
        GameObject temp = null;

        // Order array
        for (int i = rcCount; i >= 0; i--)
        {
            for (int j = 0; j < rcCount - 1; j++)
            {
                Racer racer1 = racerPositions[j].GetComponent<Racer>();
                Racer racer2 = racerPositions[j + 1].GetComponent<Racer>();

                // Check current checkpoint values
                if (racer1.currentLap < racer2.currentLap)
                {
                    temp = racerPositions[j];
                    racerPositions[j] = racerPositions[j + 1];
                    racerPositions[j + 1] = temp;
    }
                else if (racer1.currentLap == racer2.currentLap)
                {
                    if (racer1.currentInt < racer2.currentInt)
                    {
                        temp = racerPositions[j];
                        racerPositions[j] = racerPositions[j + 1];
                        racerPositions[j + 1] = temp;
                    }
                    else if (racer1.currentInt == racer2.currentInt)
                    {
                        Vector3 distance1 = Vector3.Distance(racer1.currentCheckpoint.transform, racer1.transform);

                        if (racer1.currentCheckpoint)
                    }
                }
            }
        }

        // Assign positions
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

    public GameObject NextAICheckpoint(GameObject current)
    {
        return AICheckpoints.SearchForNext(current);
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
