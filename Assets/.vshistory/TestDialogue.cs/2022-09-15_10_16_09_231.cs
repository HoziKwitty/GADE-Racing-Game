using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TestDialogue : MonoBehaviour
{
    public string mode;

    [Header("Dialogue Paths")]
    public const string BeginnerPath = "beginner";
    public const string AdvancedPath = "advanced";
    public const string CheckpointPath = "checkpoint";

    [Header("UI Elements")]
    public Image portrait;
    public Text speaker;
    public Text dialogueBox;
    public Text nextButton;

    public List<Sprite> portraits = new List<Sprite>();

    public Queue<string> dialogueQueue;

    private void Start()
    {
        switch (mode)
        {
            case "checkpoint":
                portrait.sprite = portraits[0];
                speaker.text = "Checkpoint Race Manager";
                break;

            case "beginner":
                portrait.sprite = portraits[1];
                speaker.text = "Beginner Race Manager";
                break;

            case "advanced":
                portrait.sprite = portraits[2];
                speaker.text = "Advanced Race Manager";
                break;

            default:
                break;
        }

        GetDialogue(mode);
    }

    public void GetDialogue(string path)
    {
        var dialogueLines = Resources.Load<TextAsset>(path).text
            .Split("\n")
            .ToArray();

        dialogueQueue = new Queue<string>();

        foreach (var line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialogueBox.text = dialogueQueue.Peek();
    }

    public void NextDialogue()
    {
        dialogueQueue.Dequeue();
        
        if( dialogueQueue.Peek() == "End.")
        {
            print("dialogue end");
        }
        else
        {
            dialogueBox.text = dialogueQueue.Peek();
        }
    }
}
