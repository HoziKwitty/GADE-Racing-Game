using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    // Dialogue types
    public string raceType = "checkpoint";
    public string checkpoint = "Assets/Text/checkpoint.txt";
    public string beginner = "Assets/Text/checkpoint.txt";
    public string advanced = "Assets/Text/checkpoint.txt";

    // Dialogue storage
    List<string> dialogue = new List<string>();
    public int count = 0;

    // Image Storage
    List<Image> portraits = new List<Image>();

    // Dialogue display
    public Image portrait;
    public Text speaker;
    public Text dialogueBox;

    private void Start()
    {
        GetDialogue(raceType);

        switch (raceType)
        {
            case "checkpoint":
                portrait = portraits[0];
                speaker.text = "Checkpoint Race Manager";
                break;

            case "beginner":
                portrait = portraits[1];
                speaker.text = "Beginner Race Manager";
                break;

            case "advanced":
                portrait = portraits[2];
                speaker.text = "Advanced Race Manager";
                break;

            default:
                break;
        }

        dialogueBox.text = "" + dialogue[count];
    }

    public void GetDialogue(string type)
    {
        StreamReader sr = new StreamReader(type);

        while (!sr.EndOfStream)
        {
            dialogue.Add(sr.ReadLine());
        }

        sr.Close();
    }

    public void NextDialogue()
    {
        count++;

        if (count < dialogue.Count)
        {
            dialogueBox.text = "" + dialogue[count];
        }
    }
}
