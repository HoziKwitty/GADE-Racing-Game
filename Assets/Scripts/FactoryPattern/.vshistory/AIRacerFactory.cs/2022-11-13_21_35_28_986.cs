using UnityEngine;
using UnityEngine.SceneManagement;

public class AIRacerFactory : GenericFactory<AIRacer>
{
    public Vector3 spawnBeginner = new Vector3(73, 55, 100);
    public Vector3 spawnAdvanced = new Vector3(73, 55, 100);

    public GameObject racerHolder;

    public int baseSpeed = 55;
    public int iterator = 5;

    private void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene.Equals("Advanced Race"))
        {
            for (int i = 0; i < prefab.Length; i++)
            {
                var inst = base.GetNewInstance();
                inst.transform.position = new Vector3(0, 1.3f, 5.3f);
                inst.transform.Rotate(0, 180, 0, Space.Self);

                inst.transform.parent = racerHolder.transform;

                inst.GetComponent<AIRacer>().speed = baseSpeed;
                baseSpeed += iterator;
            }
        }
        else if (currentScene.Equals("Beginner Race"))
        {
            for (int i = 0; i < prefab.Length; i++)
            {
                var inst = base.GetNewInstance();
                inst.transform.position = new Vector3(73, 55, 100);
                inst.transform.Rotate(0, 180, 0, Space.Self);

                inst.transform.parent = racerHolder.transform;

                inst.GetComponent<AIRacer>().speed = baseSpeed;
                baseSpeed += iterator;
            }
        }
    }
}
