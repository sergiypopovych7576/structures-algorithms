using System.Collections;

namespace Structures
{
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node<T> : IEnumerable<Node<T>> where T : IComparable<T>
        {
            public Node<T>? Left;
            public Node<T>? Right;
            public T Value { get; set; }

            public Node(T value, Node<T>? left, Node<T>? right)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            public IEnumerator<Node<T>> GetEnumerator()
            {
                if (Left != null)
                {
                    foreach (var v in Left)
                    {
                        yield return v;
                    }
                }

                yield return this;

                if (Right != null)
                {
                    foreach (var v in Right)
                    {
                        yield return v;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private Node<T>? _root = null;

        public void Insert(T item)
        {
            if (_root == null)
            {
                _root = new Node<T>(item, null, null);
                return;
            }

            InternalInsert(_root, item);
        }
        private void InternalInsert(Node<T> node, T item)
        {
            if (item.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(item, null, null);
                    return;
                }

                InternalInsert(node.Left, item);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(item, null, null);
                    return;
                }

                InternalInsert(node.Right, item);
            }
        }


        public T? Search(Predicate<T> predicate)
        {
            if (_root == null)
            {
                return default;
            }
            foreach (var item in _root)
            {
                if (predicate(item.Value))
                {
                    return item.Value;
                }
            }

            return default;
        }

        public void Remove(T element)
        {
            Node<T> current = _root;
            Node<T> previous = null;
            while (current != null && current.Value.CompareTo(element) != 0)
            {
                previous = current;
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (previous == null)
            {
                return;
            }
            if (current.Left != null && current.Right != null)
            {
                Node<T> s = current.Left;
                Node<T> ps = current;
                while (s.Right != null)
                {
                    ps = s;
                    s = s.Right;
                }
                current.Value = s.Value;
                current = s;
                previous = ps;
            }
            Node<T> c = null;
            if (current.Left != null)
            {
                c = current.Left;
            }
            else
            {
                c = current.Right;
            }
            if (current == _root)
            {
                _root = null;
            }
            else
            {
                if (current == previous.Left)
                {
                    previous.Left = c;
                }
                else
                {
                    previous.Right = c;
                }
            }
        }

        public int GetCount()
        {
            return InternalGetCount(_root);
        }

        private int InternalGetCount(Node<T> node)
        {
            if (node != null)
            {
                var x = InternalGetCount(node.Left);
                var y = InternalGetCount(node.Right);
                return x + y + 1;
            }
            return 0;
        }

        public int GetHeight() {
            return InternalGetHeight(_root);
        }

        private int InternalGetHeight(Node<T> node)
        {
            if(node != null)
            {
                var x = InternalGetHeight(node.Left);
                var y = InternalGetHeight(node.Right);
                if(x > y)
                {
                    return x + 1;
                }
                return y + 1;
            }
            return 0;
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _root)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
