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
        
    }

    private void Update()
    {
        
    }

    public void GetDialogue()
    {
        StreamReader sr = new StreamReader(TextPath);


    }
}
