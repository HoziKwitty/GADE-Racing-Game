using ADTLinkedList;
using UnityEngine;

public class StandardGraph
{
    [SerializeField]
    private LinkedList<GraphNode> nodes = new LinkedList<GraphNode>();

    public StandardGraph()
    {

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
        else
        {
            g1.AddNeighbour(g2);
            return true;
        }
    }

    public GraphNode FindNode(int value)
    {
        return nodes.SearchForIndex(value);
    }

    public override string ToString()
    {
        string st = "HEADER\n";

        for (int i = 1; i < nodes.Size - 1; i++)
        {
            Debug.Log(nodes.Size + "\n" + nodes.SearchForNodeIndex(i).ToString());

            st += nodes.SearchForNodeIndex(i).ToString() + "\n";
        }

        return st;
    }
}
