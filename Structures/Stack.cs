using System.Collections;

namespace Structures
{
    public class Stack<T> : IEnumerable<T> where T : class
    {
        private class Node<T> where T : class
        {
            public Node<T>? Next;
            public T Value { get; private set; }

            public Node(T value, Node<T>? next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node<T>? _head;

        public bool IsEmpty => Size == 0;
        public int Size { get; private set; }

        public Stack()
        {
            _head = null;
            Size = 0;
        }

        public void Push(T item)
        {
            var newItem = new Node<T>(item, _head);
            _head = newItem;
            Size++;
        }

        public T Pop()
        {
            var item = _head;
            _head = _head.Next;
            Size--;
            return item.Value;
        }

        public T Top()
        {
            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
