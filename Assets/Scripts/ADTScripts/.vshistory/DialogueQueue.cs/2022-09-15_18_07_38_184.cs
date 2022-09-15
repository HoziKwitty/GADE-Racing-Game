using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQueue<X>
{
    private LinkedList<X> linkedList;

    public DialogueQueue()
    {
        linkedList = new LinkedList<X>();
    }

    public void Enqueue(X data)
    {
        linkedList.AddToTail(data);
    }

    public void Dequeue()
    {
        linkedList.DeleteHead();
    }

    public X Peek()
    {
        return linkedList.Head.Data;
    }

}
}
