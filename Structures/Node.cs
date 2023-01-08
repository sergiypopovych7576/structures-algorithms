namespace Structures
{
    internal class Node<T>
    {
        public Node<T>? Next;
        public T Value { get; private set; }

        public Node(T value, Node<T>? next)
        {
            Value = value;
            Next = next;
        }
    }
}
