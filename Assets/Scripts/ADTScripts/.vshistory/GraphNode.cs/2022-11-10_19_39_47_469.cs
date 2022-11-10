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
        else
        {
            neighbours.Add(nb);
            return true;
        }
    }

    public bool RemoveNeighbour(GraphNode nb)
    {
        if (neighbours.Contains(nb))
        {
            neighbours.Remove(nb);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveAllNeighbours()
    {
        foreach (GraphNode item in neighbours)
        {
            neighbours.Remove(item);
        }
    }

    public override string ToString()
    {
        string st = "[Node Value: " + data;
        foreach (var item in neighbours)
        {
            st += " -> " + item.data;
        }
        st += "]";
    }
}
