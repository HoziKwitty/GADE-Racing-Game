using ADTLinkedList;
using UnityEngine;

public class GraphNode
{
    private int data;

    [SerializeField]
    LinkedList<GraphNode> neighbours;

    public GraphNode(int inData)
    {
        data = inData;
        neighbours = new LinkedList<GraphNode>();
    }
}
