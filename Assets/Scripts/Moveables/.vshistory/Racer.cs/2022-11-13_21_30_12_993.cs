using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Racer : MonoBehaviour
{
    public int position;

    public NavMeshAgent nma;

    public GameObject currentCheckpoint;
    public int currentInt;
    public int currentLap;

    public virtual void Start()
    {
        //nma = GetComponent<NavMeshAgent>();

        currentCheckpoint = GameObject.Find("1");
        currentLap = 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        string currentScene = "" + SceneManager.GetActiveScene().name;

        // ADVANCED RACE EXECUTION
        if (currentScene.Equals("Advanced Race"))
        {
            if (other.gameObject.CompareTag("AICheckpoint"))
            {
                currentCheckpoint = AIAdvancedManager.instance.NextAICheckpoint(currentCheckpoint);

                // Give the AI the new destination
                if (gameObject.CompareTag("AI"))
                {
                    nma.destination = currentCheckpoint.transform.position;
                }

                currentInt = other.GetComponent<AICheckpoint>().value;

                // Update the racers' positions
                AIAdvancedManager.instance.GetCurrentPositions();
            }
        }
        // BEGINNER RACE EXECUTION
        else if (currentScene.Equals("Beginner Race"))
        {
            if (other.gameObject.CompareTag("AICheckpoint"))
            {
                currentCheckpoint = AICheckpointManager.instance.NextAICheckpoint(currentCheckpoint);

                // Give the AI the new destination
                if (gameObject.CompareTag("AI"))
                {
                    nma.destination = currentCheckpoint.transform.position;
                }

                currentInt = int.Parse(other.gameObject.name) - 1;

                // Update the racers' positions
                AICheckpointManager.instance.GetCurrentPositions();
            }
            else if (other.gameObject.CompareTag("LapIterator"))
            {
                currentLap++;

                if (gameObject.CompareTag("Hero"))
                {
                    AICheckpointManager.instance.UpdateLapCounter(currentLap);
                }
            }
        }
    }
}
