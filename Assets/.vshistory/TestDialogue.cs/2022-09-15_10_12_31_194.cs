using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TestDialogue : MonoBehaviour
{
    public string raceType;

    [Header("Dialogue Paths")]
    public const string BeginnerPath = "beginner";
    public const string AdvancedPath = "advanced";
    public const string CheckpointPath = "checkpoint";

    [Header("UI Elements")]
    public Text dialogueBox;

    public Queue<string> dialogueQueue;

    private void Start()
    {
        switch (raceType)
        {
            case "checkpoint":
                GetDialogue(checkpoint);
                portrait.sprite = portraits[0];
                speaker.text = "Checkpoint Race Manager";
                break;

            case "beginner":
                GetDialogue(beginner);
                portrait.sprite = portraits[1];
                speaker.text = "Beginner Race Manager";
                break;

            case "advanced":
                GetDialogue(advanced);
                portrait.sprite = portraits[2];
                speaker.text = "Advanced Race Manager";
                break;

            default:
                break;
        }

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
