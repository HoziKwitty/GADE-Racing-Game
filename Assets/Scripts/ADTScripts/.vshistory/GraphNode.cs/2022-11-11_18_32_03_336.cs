using ADTLinkedList;
using UnityEngine;

public class GraphNode
{
    private int data;

    public int Data { 
        get { return data; } 
        set { data = value; } 
    }

    public LinkedList<GraphNode> neighbours;

    public GraphNode(int inData)
    {
        data = inData;
        neighbours = new LinkedList<GraphNode>();
    }

    public bool AddNeighbour(GraphNode nb)
    {
        if (neighbours.SearchForNode(nb) != null)
        {
            return false;
        }
        else
        {
            neighbours.AddToTail(nb);
            return true;
        }
    }

    public override string ToString()
    {
        string st = "[Node Value: " + data + " with Neighbours ";

        for (int i = 0; i < neighbours.Size; i++)
        {
            st += " -> " + neighbours.SearchForNodeIndex(i).Data.Data;
        }
        st += "]";

        return st;
    }
}
