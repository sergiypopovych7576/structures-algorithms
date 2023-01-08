using System.Collections;

namespace Structures
{
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        public bool IsEmpty => Size == 0;
        public int Size { get; private set; }

        public Queue()
        {
            _head = null;
            _tail = null;
            Size = 0;
        }

        public void Enqueue(T item)
        {
            var newItem = new Node<T>(item, null);
            if (IsEmpty)
            {
                _head = newItem;
            }
            else
            {
                _tail.Next = newItem;
            }
            _tail = newItem;
            Size++;
        }

        public T Dequeue()
        {
            var item = _head.Value;
            _head = _head.Next;
            Size--;
            return item;
        }

        public T First()
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
