using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms4;

namespace Lvl2
{
    public class MyLinkedList<T> where T : Student
    {
        private Node<T> head;
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

            Node<T> current = head;
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

            if (head.Value.Equals(targetValue))
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !current.Next.Value.Equals(targetValue))
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
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public void BubbleSort()
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Node<T> current = head;

                while (current.Next != null)
                {
                    Node<T> nextNode = current.Next;
                    bool needSwap = false;

                    if (current.Value.AvgRate < nextNode.Value.AvgRate)
                    {
                        needSwap = true;
                    }
                    else if (current.Value.AvgRate == nextNode.Value.AvgRate)
                    {
                        if (current.Value.MissedLessons > nextNode.Value.MissedLessons)
                        {
                            needSwap = true;
                        }
                    }

                    if (needSwap)
                    {
                        var temp = current.Value;
                        current.Value = nextNode.Value;
                        nextNode.Value = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}