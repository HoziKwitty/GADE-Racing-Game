using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    // Dialogue types
    public string raceType = "checkpoint";
    public string checkpoint = "Assets/Text/dialogue.txt";
    public string beginner = "Assets/Text/dialogue.txt";
    public string advanced = "Assets/Text/dialogue.txt";

    // Dialogue storage
    List<string> dialogue = new List<string>();
    public int count = 0;

    // Dialogue display
    public Image portrait;
    public string speaker;
    public Text dialogueBox;

    private void Start()
    {
        GetDialogue(raceType);

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
