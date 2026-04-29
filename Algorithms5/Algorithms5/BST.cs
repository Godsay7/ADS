using System.Xml.Linq;

namespace Algorithms5
{
    public class RandomizedBST<T> where T : Student
    {
        private class Node
        {
            public T Data;
            public Node? Left;
            public Node? Right;
            public int Size;

            public Node(T data)
            {
                Data = data;
                Size = 1;
            }
        }

        private Node? _root;
        private readonly Random _rng = new Random();

        private int GetSize(Node? node) => node?.Size ?? 0;

        private void UpdateSize(Node? node)
        {
            if (node != null)
                node.Size = 1 + GetSize(node.Left) + GetSize(node.Right);
        }

        //LVL2

        private Node RotateRight(Node p)
        {
            Node q = p.Left ?? throw new InvalidOperationException();
            p.Left = q.Right;
            q.Right = p;
            UpdateSize(p);
            UpdateSize(q);
            return q;
        }

        private Node RotateLeft(Node q)
        {
            Node p = q.Right ?? throw new InvalidOperationException();
            q.Right = p.Left;
            p.Left = q;
            UpdateSize(q);
            UpdateSize(p);
            return p;
        }

        //LVL3

        public void Add(T item)
        {
            _root = AddRecursive(_root, item);
        }

        private Node AddRecursive(Node? node, T item)
        {
            if (node == null) return new Node(item);

            //(Size+1)
            if (_rng.Next(0, node.Size + 1) == 0)
            {
                return InsertAtRoot(node, item);
            }

            int compare = string.Compare(item.LastName, node.Data.LastName, StringComparison.OrdinalIgnoreCase);
            if (compare < 0)
                node.Left = AddRecursive(node.Left, item);
            else
                node.Right = AddRecursive(node.Right, item);

            UpdateSize(node);
            return node;
        }

        private Node InsertAtRoot(Node? node, T item)
        {
            if (node == null) return new Node(item);

            int compare = string.Compare(item.LastName, node.Data.LastName, StringComparison.OrdinalIgnoreCase);
            if (compare < 0)
            {
                node.Left = InsertAtRoot(node.Left, item);
                node = RotateRight(node);
            }
            else
            {
                node.Right = InsertAtRoot(node.Right, item);
                node = RotateLeft(node);
            }
            return node;
        }

        public T? Find(string lastName)
        {
            Node? current = _root;
            while (current != null)
            {
                int compare = string.Compare(lastName, current.Data.LastName, StringComparison.OrdinalIgnoreCase);
                if (compare == 0) return current.Data;
                current = compare < 0 ? current.Left : current.Right;
            }
            return null;
        }

        public void PrintTree()
        {
            Console.WriteLine("\n--- Візуалізація BST (повернута на 90°) ---");
            PrintRecursive(_root, 0);
        }

        private void PrintRecursive(Node? node, int indent)
        {
            if (node == null) return;
            PrintRecursive(node.Right, indent + 8);
            Console.WriteLine(new string(' ', indent) + "--> " + node.Data.LastName);
            PrintRecursive(node.Left, indent + 8);
        }
    }
}