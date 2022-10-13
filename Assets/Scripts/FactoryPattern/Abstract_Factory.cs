using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    int num;

    [SerializeField]
    public T[] prefab;

    public T GetNewInstance()
    {
        num++;

        return Instantiate(prefab[num - 1]);
    }
}