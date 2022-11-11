using ADTLinkedList;
using UnityEngine;

public class StandardGraph
{
    [SerializeField]
    private LinkedList<GraphNode> nodes = new LinkedList<GraphNode>();

    public StandardGraph()
    {

    }

    public int GetSize()
    {
        return nodes.Size;
    }

    public bool CreateNode(int value)
    {
        if (FindNode(value) != null)
        {
            return false;
        }
        else
        {
            nodes.AddToTail(new GraphNode(value));
            return true;
        }
    }

    public bool CreateEdge(int v1, int v2)
    {
        GraphNode g1 = FindNode(v1);
        GraphNode g2 = FindNode(v2);

        if (g1 == null && g2 == null)
        {
            return false;
        }
        else if (g1.neighbours.Contains(g2))
        {
            return false;
        }
    }

    public GraphNode FindNode(int value)
    {
        return nodes.SearchForIndex(value);
    }
}
