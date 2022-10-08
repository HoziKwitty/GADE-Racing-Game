using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public float startTime = 60f;

    public GameObject player;

    private float currentTime;
    public float GetCurrentTime
    {
        get { return currentTime; }
        set { currentTime = value; }
    }

    public Text timerText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = startTime;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        timerText.text = "Time Remaining: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            player.SetActive(false);
            enabled = false;
        }
    }
}
