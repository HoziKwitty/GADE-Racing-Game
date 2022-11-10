using ADTLinkedList;
using UnityEngine;

public class Graph
{
    private int vertices;

    [SerializeField]
    LinkedList<int>[] linkedList;

    public Graph(int vCount)
    {
        vertices = vCount;
        linkedList = new LinkedList<int>[vCount];

        // Create array of LinkedLists
        for (int i = 0; i < vCount; i++)
        {
            linkedList[i] = new LinkedList<int>();
        }
    }

    public void CreateEdge(int v1, int v2)
    {
        linkedList[v1].AddToTail(v2);
    }

    public void CreateMatrix(Graph graph)
    {
        int?[,] matrix = new int?[graph.vertices, graph.vertices];

        for (int parentV = 0; parentV < graph.vertices; parentV++)
        {
            var parentNode = linkedList[parentV];

            for (int childNode = 0; childNode < graph.vertices; childNode++)
            {
                if (parentV != childNode)
                {
                    var edge = parentV.
                }
            }
        }
    }
}
