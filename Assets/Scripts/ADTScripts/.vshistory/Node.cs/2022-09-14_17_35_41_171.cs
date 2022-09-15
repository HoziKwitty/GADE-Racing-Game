namespace Node
{
    public class Node<T>
    {

        private T _data;
        private Node<T> _nextNode;
        private Node<T> _previousNode;

        public T Data
        {
            get => _data;
            set => _data = value;
        }

        public Node<T> NextNode
        {
            get => _nextNode;
            set => _nextNode = value;
        }

        public Node<T> PreviousNode
        {
            get => _previousNode;
            set => _previousNode = value;
        }

        public Node()
        {
        }

        public Node(T data)
        {
            _data = data;
        }

        public Node(T data, Node<T> nextNode)
        {
            _data = data;
            _nextNode = nextNode;
        }

        public Node(T data, Node<T> nextNode, Node<T> previousNode)
        {
            _data = data;
            _nextNode = nextNode;
            _previousNode = previousNode;
        }
        public override string ToString()
        {
            return $"{_data.ToString()}";
        }

        
    }
}
