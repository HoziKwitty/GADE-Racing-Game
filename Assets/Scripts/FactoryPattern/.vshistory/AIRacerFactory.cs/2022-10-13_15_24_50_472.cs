using UnityEngine;

public class AIRacerFactory : GenericFactory<AIRacer>
{
    public GameObject racerHolder;

    public float baseSpeed = 70f;
    public float iterator = 5f;

    private void Awake()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            var inst = base.GetNewInstance();
            inst.transform.position = new Vector3(73, 55, 100);
            inst.transform.Rotate(0, 180, 0, Space.Self);

            inst.transform.parent = racerHolder.transform;

            inst.GetComponent<AIRacer>().
        }
    }
}
