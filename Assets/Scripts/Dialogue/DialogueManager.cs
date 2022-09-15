using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public string inMode;
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
        switch (inMode)
        {
            case "Text/Checkpoint":
                mode = "Checkpoint";
                portrait.sprite = portraits[0];
                speaker.text = "Checkpoint Race Manager";
                break;

            case "Text/Beginner":
                mode = "Beginner";
                portrait.sprite = portraits[1];
                speaker.text = "Beginner Race Manager";
                break;

            case "Text/Advanced":
                mode = "Advanced";
                portrait.sprite = portraits[2];
                speaker.text = "Advanced Race Manager";
                break;

            default:
                break;
        }

        GetDialogue(inMode);
    }

    public void GetDialogue(string path)
    {
        var file = Resources.Load<TextAsset>(path);
        string[] dialogueLines = file.text.Split("\n");

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

        if (dialogueQueue.Peek() != "End.")
        {
            dialogueBox.text = dialogueQueue.Peek();
        }
        else
        {
            nextButton.text = "Proceed to race!";

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene(mode + " Race");
        }
    }
}
