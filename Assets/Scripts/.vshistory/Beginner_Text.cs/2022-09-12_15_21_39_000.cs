using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Beginner_Text : MonoBehaviour
{
    int num = 0;
    List<string> dialogue = new List<string>();
    string TextPath = "Assets/text_files/beginer.txt"; 
    // Start is called before the first frame update

    private void getDialogue()
    {
        StreamReader sr = new StreamReader(TextPath);
        while (!sr.EndOfStream)
        {
            dialogue.Add(sr.ReadLine());
        }
    }
    void Start()
    {
        getDialogue();
        print(dialogue[num]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
        if(num == 3)
        {
                //num++;
                //print(dialogue[num]);
                print("convo over");
        }
            else
            {
                num++;
                print(dialogue[num]);
                //print("convo over");
            }
        }
    }
}
