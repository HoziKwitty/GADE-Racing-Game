using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public float startTime = 60f;

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
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        timerText.text = "" + currentTime;

        if (currentTime <= 0)
        {
            enabled = false;
        }
    }
}
