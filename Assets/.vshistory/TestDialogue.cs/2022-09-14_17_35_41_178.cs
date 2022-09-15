using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TestDialogue : MonoBehaviour
{
    [Header("Dialogue Paths")]
    public const string BeginnerPath = "beginner";
    public const string AdvancedPath = "advanced";
    public const string CheckpointPath = "checkpoint";

    [Header("UI Elements")]
    public Text dialogueText;

    private Queue<string> dialogueQueue;
    
    private void Awake()
    {

    }

    private void Start()
    {
        ReadDialogue(BeginnerPath);
    }

    public void ReadDialogue(string path)
    {
        var dialogueLines = Resources.Load<TextAsset>(path).text
            .Split("\n")
            .ToArray();

        dialogueQueue = new Queue<string>();

        foreach (var line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialogueText.text = dialogueQueue.Peek();
    }

    // runs on the event that next button is clicked(Unity Event)
    public void DisplayNextDialogue()
    {
        dialogueQueue.Dequeue();
        
        if( dialogueQueue.Peek() == "End.")
        {
            print("dialogue end");
        }
        else
        {
            dialogueText.text = dialogueQueue.Peek();
        }
    }
}
