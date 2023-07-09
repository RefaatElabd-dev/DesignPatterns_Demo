namespace Iterator.PreOrder
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;
        public Node<T> Current;
        private bool yieldedStart;

        public Node(T value) => Value = value;

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            left.Parent = right.Parent = Current = this;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            foreach (var node in PreOrder)
                yield return node;
        }

        public IEnumerable<Node<T>> PreOrder
        {
            get
            {
                IEnumerable<Node<T>> PreOrderTraverse(Node<T> current)
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

                foreach (var node in PreOrderTraverse(this))
                    yield return node;
            }
        }
    }
}
