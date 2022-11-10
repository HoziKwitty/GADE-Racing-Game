using ADTLinkedList;

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
}
