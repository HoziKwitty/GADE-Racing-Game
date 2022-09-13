using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BeginnerDialogue : MonoBehaviour
{
    public string path = "Assets/Text/dialogue.txt";

    List<string> dialogue = new List<string>();
    public int count = 0;

    private void Start()
    {
        GetDialogue();

        Debug.Log(dialogue[count]);
    }

    public void GetDialogue()
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

        if (count < dialogue.Count)
        {
            Debug.Log(dialogue[count]);
        }
    }
}
