using System;
using Node;

namespace ADTLinkedList
{
    public class LinkedList<X>
    {
        private Node<X> _head;
        private Node<X> _tail;
        private int _size = 0;

        public Node<X> Head
        {
            get => _head;
            set => _head = value;
        }

        public Node<X> Tail
        {
            get => _tail;
            set => _tail = value;
        }

        public int Size
        {
            get => _size;
            private set => _size = value;
        }

        public LinkedList()
        {
        }

        public LinkedList(Node<X> head)
        {
            _head = head;
        }
        /// <summary>
        /// O(1) - Stack Push
        /// </summary>
        /// <param name="data"></param>
        public void AddToHead(X data)
        {
            if (_size == 0)
            {
                Node<X> newNode = new Node<X>(data);
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<X> newNode = new Node<X>(data);
                newNode.NextNode = Head;
                Head = newNode;
            }

            Size += 1;
        }

        /// <summary>
        /// O(1) Queue - Enqueue
        /// </summary>
        /// <param name="data"></param>
        public void AddToTail(X data)
        {
            if (_size == 0)
            {
                Node<X> newNode = new Node<X>(data);
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<X> newNode = new Node<X>(data);
                Tail.NextNode = newNode;
                Tail = newNode;
            }
        }

        /// <summary>
        /// O(1) Stack - Pop
        /// O(1) Queue -> Dequeue
        /// </summary>
        public void DeleteAtHead()
        {
        }

        public void DeleteAtTail()
        {
        }

        public void Display()
        {
            if (Size == 0) Print("Empty");
            if (Size == 1) Print(Head.ToString());
            else
            {
                Node<X> currentNode = Head;
                string nodeData = string.Empty;
                while (currentNode != null)
                {
                    nodeData += $"{currentNode} -> ";
                    currentNode = currentNode.NextNode;
                }

                Print(nodeData);
            }
        }


        private static void Print(string data)
        {
            Console.WriteLine(data);
        }
    }

}

