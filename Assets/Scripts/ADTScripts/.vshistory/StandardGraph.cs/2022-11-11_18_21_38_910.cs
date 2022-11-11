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

    public void CreateEdge(int v1, int v2)
    {
        GraphNode g1 = FindNodeIndex(v1);
        GraphNode g2 = FindNodeIndex(v2);

        Debug.Log(g1 + "\n" + g2);

        g1.AddNeighbour(g2);
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
