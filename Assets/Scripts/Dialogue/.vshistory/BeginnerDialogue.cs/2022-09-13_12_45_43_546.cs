using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BeginnerDialogue : MonoBehaviour
{
    // Dialogue types
    public string raceType = "checkpoint";
    public string checkpoint = "Assets/Text/dialogue.txt";
    public string beginner = "Assets/Text/dialogue.txt";
    public string advanced = "Assets/Text/dialogue.txt";

    // Dialogue storage
    List<string> dialogue = new List<string>();
    public int count = 0;

    private void Start()
    {
        GetDialogue(raceType);

        Debug.Log(dialogue[count]);
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
            Debug.Log(dialogue[count]);
        }
    }
}
