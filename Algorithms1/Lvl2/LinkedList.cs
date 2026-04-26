using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl2
{
    public class MyLinkedList
    {
        private Node head;
        private bool isEmpty()
        {
            if (head == null)
                return true;
            else return false;
        }
        public void AddFirst(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
        }
        public void AddLast(int value)
        {
            Node newNode = new Node(value);
            if (isEmpty())
            {
                head = newNode;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        public void RemoveElement(int targetValue)
        {
            if (isEmpty())
                throw new InvalidOperationException("LinkedList is empty.");

            if (head.Value == targetValue)
            {
                head = head.Next;
                return;
            }

            Node current = head;
            while (current.Next != null && current.Next.Value != targetValue)
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
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}