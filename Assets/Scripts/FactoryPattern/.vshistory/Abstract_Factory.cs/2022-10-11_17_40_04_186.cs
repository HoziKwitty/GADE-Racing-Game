using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    int num;

    [SerializeField]
    public T[] prefab;

    public T GetNewInstance()
    {
        return Instantiate(prefab[num]);

    }
}