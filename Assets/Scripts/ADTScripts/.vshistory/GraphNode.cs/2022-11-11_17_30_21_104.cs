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

    //public bool RemoveNeighbour(GraphNode nb)
    //{
    //    if (neighbours.Contains(nb))
    //    {
    //        neighbours.Remove(nb);
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public void RemoveAllNeighbours()
    //{
    //    foreach (GraphNode item in neighbours)
    //    {
    //        neighbours.Remove(item);
    //    }
    //}

    public override string ToString()
    {
        string st = "[Node Value: " + data;

        for (int i = 0; i < neighbours.Size; i++)
        {
            st += " -> " + neighbours.SearchForNodeIndex(i);
        }
        
        foreach (var item in neighbours)
        {
            st += " -> " + item.data;
        }
        st += "]";

        return st;
    }
}