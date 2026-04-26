using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl2
{
    public class MyLinkedList<T>
    {
        private Node<T>? head;
        private bool isEmpty()
        {
            if (head == null)
                return true;
            else return false;
        }
        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
        }
        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (isEmpty())
            {
                head = newNode;
                return;
            }

            Node<T> current = head!;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        public void RemoveElement(T targetValue)
        {
            if (isEmpty())
                throw new InvalidOperationException("LinkedList is empty.");

            if (EqualityComparer<T>.Default.Equals(head!.Value, targetValue))
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Value, targetValue))
            {
                current = current.Next;
            }
            if (current.Next == null)
            {
                Console.WriteLine($"There is no {targetValue} value in list.");
                return;
            }
            current.Next = current.Next.Next;
        }
        public void DisplayList()
        {
            Node<T> current = head!;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next!;
            }
            Console.WriteLine("null");
        }

        public void RemoveMatch(Predicate<T> match)
        {
            if (head == null) return;
            
            while (head != null && match(head.Value))
            {
                head = head.Next;
            }

            Node<T>? current = head;
            while (current != null && current.Next != null)
            {
                if (match(current.Next.Value))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }
    }
}