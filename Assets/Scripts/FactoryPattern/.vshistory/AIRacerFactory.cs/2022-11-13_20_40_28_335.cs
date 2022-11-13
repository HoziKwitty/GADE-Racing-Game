using UnityEngine;
using UnityEngine.SceneManagement;

public class AIRacerFactory : GenericFactory<AIRacer>
{
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
                inst.transform.position = new Vector3(0, 2.05f, 5);
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
