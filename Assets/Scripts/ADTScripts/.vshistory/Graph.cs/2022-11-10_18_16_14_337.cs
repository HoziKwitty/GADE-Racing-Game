using ADTLinkedList;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Graph
{
    private int vertices;

    [SerializeField]
    LinkedList<int>[] linkedList;
    List<int> list = new List<int>();

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

    public void CreateMatrix(Graph graph, Text inDisplay)
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

                    if (edge != 0)
                    {
                        matrix[parentV, childNode] = 1;
                    }
                }
            }
        }

        inDisplay.text = Display(matrix, graph.vertices);
    }

    public string Display(int?[,] inMatrix, int count)
    {
        string st = "Nodes ";

        for (int i = 0; i < count; i++)
        {
            st += i + ",";
        }
        st += "\n";

        for (int i = 0; i < count; i++)
        {
            st += "[ " + i + " -> ";

            for (int j = 0; j < count; j++)
            {
                if (i == j)
                {
                    st += " x ";
                }
                else if (inMatrix[i, j] == null)
                {
                    st += " . ";
                }
                else
                {
                    st += inMatrix[i, j];
                }
            }

            st += "]\n";
        }

        return st;
    }
}
