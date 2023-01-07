using System.Collections;

namespace Structures
{
    public class LinkedList<T> : IEnumerable<T> where T : class
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

        public int Size { get; private set; }
        public bool IsEmpty => Size == 0;

        private Node<T>? _head;
        private Node<T>? _tail;

        public LinkedList()
        {
            Size = 0;
            _head = null;
            _tail = null;
        }

        public void Add(T item)
        {
            var newItem = new Node<T>(item, null);
            if (IsEmpty)
            {
                _head = newItem;
            }
            else if(_tail != null)
            {
                _tail.Next = newItem;
            }
            _tail = newItem;
            Size++;
        }

        public void Insert(int indx, T item)
        {
            if (indx < 0 || indx > Size)
            {
                throw new IndexOutOfRangeException();
            }
            var newItem = new Node<T>(item, null);
            Node<T> currentItem = _head;
            var i = 1;
            while(i < indx - 1)
            {
                currentItem = currentItem.Next;
                i++;
            }
            newItem.Next = currentItem.Next;
            currentItem.Next = newItem;
            Size++;
        }

        public void RemoveAt(int indx)
        {
            if (indx < 0 || indx > Size)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> item = _head;
            var i = 1;
            while (i < indx - 1)
            {
                item = item.Next;
                i++;
            }
            var nextItem = item.Next.Next;
            item.Next = nextItem;
            Size--;
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