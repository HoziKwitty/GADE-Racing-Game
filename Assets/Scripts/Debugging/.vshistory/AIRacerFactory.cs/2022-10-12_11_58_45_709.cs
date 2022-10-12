using UnityEngine;

public class AIRacerFactory : GenericFactory<AIRacer>
{
    public AIRacer[] racers;

    private void Awake()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            var inst = base.GetNewInstance();
            inst.transform.position = new Vector3(73, 55, 100);
            inst.transform.Rotate(0, 180, 0, Space.Self);
        }
    }
}
