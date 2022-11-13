using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
