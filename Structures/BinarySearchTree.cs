using System.Collections;

namespace Structures
{
    /// <summary>
    /// Delete, Height
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node<T> : IEnumerable<Node<T>> where T : IComparable<T>
        {
            public Node<T>? Left;
            public Node<T>? Right;
            public T Value { get; private set; }

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

        public T? Search(Predicate<T> predicate)
        {
            if(_root == null)
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

        public void Remove(Predicate<T> predicate)
        {
            throw new NotImplementedException();
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
