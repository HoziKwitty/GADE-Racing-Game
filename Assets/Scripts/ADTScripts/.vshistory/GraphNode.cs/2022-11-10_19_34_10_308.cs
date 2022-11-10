using System.Collections.Generic;
using UnityEngine;

public class GraphNode
{
    private int data;

    public int GetData { 
        get { return data; } 
        set { data = value; } 
    }

    [SerializeField]
    private List<GraphNode> neighbours;

    public GraphNode(int inData)
    {
        data = inData;
        neighbours = new List<GraphNode>();
    }

    public void AddNeighbour(GraphNode nb)
    {
        if (neighbours.)
    }
}
