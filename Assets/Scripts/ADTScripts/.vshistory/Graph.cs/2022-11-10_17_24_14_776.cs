using ADTLinkedList;

public class Graph
{
    private int vertices;
    private ADTLinkedList.LinkedList<int>[] linkedList;

    public Graph(int vCount)
    {
        vertices = vCount;
        linkedList = new LinkedList<int>[vCount];
    }
}