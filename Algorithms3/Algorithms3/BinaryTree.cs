using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms3
{
    public class BinaryTree<T>
    {
        private class Node<T>
        {
            public uint Key;
            public T Value;
            public Node<T>? Right;
            public Node<T>? Left;

            public Node(uint key, T value)
            {
                Key = key;
                Value = value;
                Right = null;
                Left = null;
            }
        }

        private Node<T>? _root;
        private readonly HashSet<uint> _keys = new HashSet<uint>();
        private readonly object _consoleLock = new object();
        public void Add(uint key, T value) 
        {
            if (_keys.Contains(key))
                throw new ArgumentException($"Student with ID {key} already exists!");

            var newNode = new Node<T>(key, value);
            _keys.Add(key);

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    return;
                }
                queue.Enqueue(current.Left);

                if (current.Right == null)
                {
                    current.Right = newNode;
                    return;
                }
                queue.Enqueue(current.Right);
            }
        }
        public void PrintTable()
        {
            lock (_consoleLock)
            {
                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("{0,-15} | {1,-40}", "Student ID", "Student info");
                Console.WriteLine(new string('-', 60));

            }
            ParallelTraverse(_root);
        }

        private void ParallelTraverse(Node<T>? node)
        {
            if (node == null) return;
            lock (_consoleLock) Console.WriteLine("{0,-15} | {1,-40}", node.Key, node.Value?.ToString());
            Parallel.Invoke(
                () => ParallelTraverse(node.Left),
                () => ParallelTraverse(node.Right)
            );
        }
        ///////
        ///LVL2
        // Публічний метод для пошуку за варіантом
        public List<T> FindByVariant(string targetCity = "Kyiv")
        {
            List<T> results = new List<T>();
            SearchRecursive(_root, results, targetCity);
            return results;
        }

        private void SearchRecursive(Node<T>? node, List<T> res, string targetCity)
        {
            if (node == null) return;

            if (node.Value is Student student)
            {
                if (student.Course == 1 && student.City != targetCity)
                {
                    res.Add(node.Value);
                }
            }

            SearchRecursive(node.Left, res, targetCity);
            SearchRecursive(node.Right, res, targetCity);
        }

        ///LVL3
        public void RemoveByVariant(string targetCity = "Kyiv")
        {
            var toRemove = FindByVariant(targetCity);
            foreach (var student in toRemove)
            {
                if (student is Student s)
                {
                    _root = RemoveRecursive(_root, s.StudentId);
                    _keys.Remove(s.StudentId); 
                }
            }
        }

        private Node<T>? RemoveRecursive(Node<T>? node, uint key)
        {
            if (node == null) return null;

            if (key == node.Key)
            {
                // Випадок 1: Вузол без дітей або з однією дитиною
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Випадок 2: Вузол з двома дітьми
                Node<T> successor = GetMin(node.Right);
                node.Key = successor.Key;
                node.Value = successor.Value;

                // Видаляємо дублікат заступника
                node.Right = RemoveRecursive(node.Right, successor.Key);
            }
            else
            {
                node.Left = RemoveRecursive(node.Left, key);
                node.Right = RemoveRecursive(node.Right, key);
            }
            return node;
        }

        private Node<T> GetMin(Node<T> node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }
    }
}