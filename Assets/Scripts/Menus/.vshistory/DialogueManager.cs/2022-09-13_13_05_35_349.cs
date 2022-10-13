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
    private List<string> dialogue = new List<string>();
    public int count = 0;

    // Image Storage
    public List<Sprite> portraits = new List<Sprite>();

    // Dialogue display
    public Image portrait;
    public Text speaker;
    public Text dialogueBox;
    public Text nextButton;

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

        dialogueBox.text = "" + dialogue[count];
    }

    public void GetDialogue(string path)
    {
        StreamReader sr = new StreamReader(path);

        while (!sr.EndOfStream)
        {
            dialogue.Add(sr.ReadLine());
        }

        sr.Close();
    }

    public void NextDialogue()
    {
        count++;

        if (count < dialogue.Count - 1)
        {
            dialogueBox.text = "" + dialogue[count];
        }
        else
        {
            dialogueBox.text = "" + dialogue[count];
            nextButton.text = "Proceed to Race!";
        }
    }
}
