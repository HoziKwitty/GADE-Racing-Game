namespace Node
{
    public class Node<T>
    {

        private T data;
        private Node<T> nextNode;
        private Node<T> previousNode;

        public T Data
        {
            get => data;
            set => data = value;
        }

        public Node<T> NextNode
        {
            get => nextNode;
            set => nextNode = value;
        }

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> nextNode, Node<T> previousNode)
        {
            this.data = data;
            this.nextNode = nextNode;
            this.previousNode = previousNode;
        }
        public override string ToString()
        {
            return $"{data.ToString()}";
        }
    }
}
