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

    public bool AddNeighbour(GraphNode nb)
    {
        if (neighbours.Contains(nb))
        {
            return false;
        }
    }
}
