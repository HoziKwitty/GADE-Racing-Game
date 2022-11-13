using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Racer : MonoBehaviour
{
    public int position;

    protected NavMeshAgent nma;

    public GameObject currentCheckpoint;
    public int currentInt;
    public int currentLap;

    public bool entered = false;

    public virtual void Start()
    {
        nma = GetComponent<NavMeshAgent>();

        currentCheckpoint = GameObject.Find("1");
        currentLap = 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        string currentScene = "" + SceneManager.GetActiveScene().name;

        // ADVANCED RACE EXECUTION
        if (name.Equals("Advanced Race"))
        {
            if (other.gameObject.CompareTag("AICheckpoint") && !entered)
            {
                StartCoroutine(WaitToEnter(0.3f));


            }
        }
        // BEGINNER RACE EXECUTION
        else if (name.Equals("Beginner Race"))
        {
            if (other.gameObject.CompareTag("AICheckpoint") && !entered)
            {
                StartCoroutine(WaitToEnter(0.3f));

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

    private IEnumerator WaitToEnter(float time)
    {
        entered = true;

        yield return new WaitForSeconds(time);

        entered = false;
    }
}
