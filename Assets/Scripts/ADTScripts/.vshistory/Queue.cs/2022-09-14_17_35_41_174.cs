using ADTLinkedList;
using Node;

namespace ADTQueue
{
    public class Queue<X>
    {
        private readonly LinkedList<X> _linkedList;
        
        public Queue()
        {
            _linkedList = new LinkedList<X>();
        }

        public void Enqueue(X data)
        {
            _linkedList.AddToTail(data);
        }

        public X Peek()
        {
            return _linkedList.Head.Data;
        }

        public X Dequeue()
        {
            Node<X> node = new Node<X>();
            _linkedList.DeleteAtHead();
            node = _linkedList.Head;

            return node.Data;
        }

    }
}
