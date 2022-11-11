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
        if (FindNodeIndex(value) != null)
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
        GraphNode g1 = new GraphNode(v1);
        GraphNode g2 = new GraphNode(v2);

        GraphNode gn1 = null;
        GraphNode gn2 = null;

        if (g1.GetData.Equals(nodes.Search(g1).GetData))
        {
            gn1 = g1;
        }
        if (g2.GetData.Equals(nodes.Search(g2).GetData))
        {
            gn2 = g2;
        }

        if (gn1 == null && g2 == null)
        {
            return false;
        }
        else if (gn1.neighbours.Contains(g2))
        {
            return false;
        }
        else
        {
            gn1.AddNeighbour(g2);
            return true;
        }
    }

    public GraphNode FindNodeIndex(int value)
    {
        return nodes.SearchForIndex(value);
    }

    public override string ToString()
    {
        string st = "HEADER\n";

        for (int i = 0; i < nodes.Size - 1; i++)
        {
            //Debug.Log(nodes.SearchForNodeIndex(i).ToString());

            st += nodes.SearchForNodeIndex(i).ToString() + "\n";
        }

        return st;
    }
}
