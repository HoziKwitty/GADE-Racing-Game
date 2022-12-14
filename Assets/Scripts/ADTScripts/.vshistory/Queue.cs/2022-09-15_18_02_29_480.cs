using ADTLinkedList;
using Node;

namespace ADTQueue
{
    public class Queue<X>
    {
        private readonly LinkedList<X> linkedList;
        
        public Queue()
        {
            linkedList = new LinkedList<X>();
        }

        public void Enqueue(X data)
        {
            linkedList.AddToTail(data);
        }

        public void Dequeue()
        {

        }

        public X Peek()
        {
            return linkedList.Head.Data;
        }

    }
}
