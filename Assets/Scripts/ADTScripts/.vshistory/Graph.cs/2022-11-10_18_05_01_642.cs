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
                    var edge = parentNode.SearchForIndex(childNode);

                    if (!edge.Equals(null))
                    {
                        matrix[parentV, childNode] = 1;
                    }
                }
            }
        }

        Display(matrix, graph.vertices);
    }

    public string Display(int?[,] inMatrix, int count)
    {
        string st = "Nodes ";

        for (int i = 0; i < count; i++)
        {
            st += i + ",";
        }

        for (int i = 0; i < count; i++)
        {
            st += "[ " + i;
        }

        return st;
    }
}
