using ADTLinkedList;
using UnityEngine;

public class GraphNode
{
    private int data;

    [SerializeField]
    ADTLinkedList.LinkedList<int> linkedList;

    public GraphNode(int inData)
    {
        data = inData;

    }
}
