using ADTLinkedList;
using UnityEngine;

public class GraphNode
{
    private int data;
    public int GetData { 
        get { return data; } 
        set { data = value; } 
    }

    [SerializeField]
    LinkedList<GraphNode> neighbours;

    public GraphNode(int inData)
    {
        data = inData;
        neighbours = new LinkedList<GraphNode>();
    }
}
