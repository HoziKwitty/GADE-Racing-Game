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

    public bool AddNode(int value)
    {
        if (FindNode(value) != null))
        {

        }
    }

    public GraphNode FindNode(int value)
    {

    }
}
