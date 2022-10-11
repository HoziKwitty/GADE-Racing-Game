using Node;
using UnityEngine;

namespace ADTLinkedList
{
    public class LinkedList<X>
    {
        private Node<X> head;
        private Node<X> tail;
        private int size = 0;

        public Node<X> Head
        {
            get => head;
            set => head = value;
        }

        public Node<X> Tail
        {
            get => tail;
            set => tail = value;
        }

        public int Size
        {
            get => size;
            private set => size = value;
        }

        public LinkedList() { }

        public LinkedList(Node<X> head)
        {
            this.head = head;
        }

        public void AddToHead(X data)
        {
            if (size == 0)
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

        public void DeleteHead()
        {
            head.NextNode = head;
        }

        public void AddToTail(X data)
        {
            if (size == 0)
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

            Size += 1;
        }

        public X Search(X search)
        {
            X returnNode = default(X);

            Node<X> currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(search))
                {
                    returnNode = currentNode.Data;
                    break;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }

            return returnNode;
        }

        public X SearchForIndex(int index)
        {
            X returnNode = default(X);

            Node<X> currentNode = Head;

            int inIndex = 0;

            while (currentNode != null)
            {
                if (index == inIndex)
                {
                    returnNode = currentNode.Data;
                    break;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }

                inIndex++;
            }

            return returnNode;
        }

        public X SearchForNext(X search)
        {
            X returnNode = default(X);

            Node<X> currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(search))
                {
                    if (currentNode.NextNode == null)
                    {
                        returnNode = Head.Data;
                        break;
                    }
                    else
                    {
                        returnNode = currentNode.NextNode.Data;
                        break;
                    }
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }

            return returnNode;
        }

        // DEBUGGING
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
            Debug.Log(data);
        }
    }
}