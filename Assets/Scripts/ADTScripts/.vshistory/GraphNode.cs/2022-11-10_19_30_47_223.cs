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
    private LinkedList<GraphNode> neighbours;
    public LinkedList<GraphNode> GetNeighbours { 
        get { return neighbours; } 
        set { neighbours = value; } 
    }

    public GraphNode(int inData)
    {
        data = inData;
        neighbours = new LinkedList<GraphNode>();
    }
}
