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

    public GraphNode FindNodeIndex(int value)
    {
        return nodes.SearchForIndex(value);
    }

    public GraphNode FindNode(int value)
    {
        GraphNode temp = null;

        for (int i = 0; i < nodes.Size; i++)
        {
            temp = nodes.SearchForIndex(i);

            if (temp.Data == value)
            {
                return temp;
            }
        }

        return null;
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
