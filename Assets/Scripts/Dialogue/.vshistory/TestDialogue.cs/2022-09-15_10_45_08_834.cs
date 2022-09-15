using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TestDialogue : MonoBehaviour
{
    [Header("Dialogue Paths")]
    public const string CheckpointPath = "Text/checkpoint.txt";
    public const string BeginnerPath = "Text/beginner.txt";
    public const string AdvancedPath = "Text/advanced,txt";

    public string mode;

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
            case "Text/checkpoint.txt":
                portrait.sprite = portraits[0];
                speaker.text = "Checkpoint Race Manager";
                break;

            case "Text/beginner.txt":
                portrait.sprite = portraits[1];
                speaker.text = "Beginner Race Manager";
                break;

            case "Text/advanced.txt":
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
        Debug.Log(path);

        var file = Resources.Load<TextAsset>(path);
        string[] dialogueLines = Resources.Load<TextAsset>(path).text.Split("\n"); ;

        dialogueQueue = new Queue<string>();

        foreach (string line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialogueBox.text = dialogueQueue.Peek();
    }

    public void NextDialogue()
    {
        dialogueQueue.Dequeue();
        
        if(dialogueQueue.Peek() != "End.")
        {
            dialogueBox.text = dialogueQueue.Peek();
        }
        else
        {
            dialogueBox.text = "Proceed to race!";
        }
    }
}
