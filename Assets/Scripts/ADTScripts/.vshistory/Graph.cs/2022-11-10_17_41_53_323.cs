using ADTLinkedList;
using UnityEngine;

public class Graph
{
    private int vertices;
    private ADTLinkedList.LinkedList<int>[] linkedList;

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

    public void Display()
    {
        string st = "Adjacency List\n";

        for (int i = 0; i < linkedList.Length; i++)
        {
            st += "[Node Value: " + i + " with Neighbours";
            foreach (var item in linkedList)
            {
                //item.Display();
            }
            st += "]\n";
        }

        return st;
    }
}
