namespace Iterator.PreOrder
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;
        public readonly Node<T> Root;
        public Node<T> Current;

        public Node(T value)
        {
            Value = value;
        }

        public Node(Node<T> root)
        {
            this.Root = root;
            Left = root.Left;
            Right = root.Right;
            Current = root;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            left.Parent = right.Parent = Current = Root = this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in PreOrder)
                yield return value;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in PreOrderTraverse(Current))
                    yield return node.Value;
            }
        }

        private IEnumerable<Node<T>> PreOrderTraverse(Node<T> current)
        {
            yield return current;
            if (current.Left != null)
            {
                foreach (var left in PreOrderTraverse(current.Left))
                    yield return left;
            }
            if (current.Right != null)
            {
                foreach (var right in PreOrderTraverse(current.Right))
                    yield return right;
            }
        }
    }
}
