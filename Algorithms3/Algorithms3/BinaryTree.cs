using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms3
{
    public class BinarySearchTree<T> where T : Student
    {
        private class Node<T> where T : Student
        {
            public uint Key;
            public T Value;
            public Node<T>? Right;
            public Node<T>? Left;

            public Node(uint key, T value)
            {
                Key = key;
                Value = value;
            }
        }

        private Node<T>? _root;
        private readonly object _consoleLock = new object();

        public void Add(uint key, T value)
        {
            _root = InsertRecursive(_root, key, value);
        }

        private Node<T> InsertRecursive(Node<T>? node, uint key, T value)
        {
            if (node == null) return new Node<T>(key, value);

            if (key < node.Key)
            {
                node.Left = InsertRecursive(node.Left, key, value);
            }
            else if (key > node.Key)
            {
                node.Right = InsertRecursive(node.Right, key, value);
            }
            else
            {
                throw new ArgumentException($"Key: {key} already exist!");
            }

            return node;
        }

        //O(log n))
        public List<T> FindByVariant(string targetCity)
        {
            List<T> results = new List<T>();
            FindRecursive(_root, results, targetCity);
            return results;
        }

        private void FindRecursive(Node<T>? node, List<T> res, string targetCity)
        {
            if (node == null) return;

            if (node.Value.Course == 1 && node.Value.City != targetCity)
            {
                res.Add(node.Value);
            }

            FindRecursive(node.Left, res, targetCity);
            FindRecursive(node.Right, res, targetCity);
        }

        public void RemoveByVariant(string targetCity)
        {
            var toRemove = FindByVariant(targetCity);

            foreach (var item in toRemove)
            {
                if (item is Student s)
                {
                    _root = RemoveRecursive(_root, s.StudentId);
                }
            }
        }

        private Node<T>? RemoveRecursive(Node<T>? node, uint key)
        {
            if (node == null) return null;

            if (key < node.Key)
            {
                node.Left = RemoveRecursive(node.Left, key);
            }
            else if (key > node.Key)
            {
                node.Right = RemoveRecursive(node.Right, key);
            }
            else 
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node<T> successor = GetMin(node.Right);
                node.Key = successor.Key;
                node.Value = successor.Value;
                node.Right = RemoveRecursive(node.Right, successor.Key);
            }
            return node;
        }

        private Node<T> GetMin(Node<T> node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        public void PrintTable()
        {
            lock (_consoleLock)
            {
                Console.WriteLine("\nBST Structure:");
                Console.WriteLine("{0,-15} | {1,-40}", "ID", "Info");
            }
            ParallelTraverse(_root);
        }

        private void ParallelTraverse(Node<T>? node)
        {
            if (node == null) return;
            lock (_consoleLock) Console.WriteLine("{0,-15} | {1,-40}", node.Key, node.Value);
            Parallel.Invoke(
                () => ParallelTraverse(node.Left),
                () => ParallelTraverse(node.Right)
            );
        }
    }
}