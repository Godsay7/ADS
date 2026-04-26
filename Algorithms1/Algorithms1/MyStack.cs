using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lvl1
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;
        private const int DefaultSize = 4;
        public int Count => _count;
        public MyStack()
        {
            _items = new T[DefaultSize];
            _count = 0;
        }
        private bool isFull()
        {
            if (_count == _items.Length)
                return true;
            else return false;
        }
        private bool isEmpty()
        {
            if (_count == 0)
                return true;
            else return false;
        }
        public bool Push(T item)
        {
            if (isFull())
                Resize();

            _items[_count++] = item;
            return true;
        }
        public T Pop()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty.");
            
            return _items[--_count];
        }
        public T Peek()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _items[_count - 1];
        }
        private void Resize()
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        public void DisplayStack()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            Console.WriteLine("-------------------");

            for (int i = _count - 1; i >= 0; i--)
            {
                if (i == _count - 1)
                {
                    Console.WriteLine($"{_items[i]}  <-- Top");
                }
                else
                {
                    Console.WriteLine(_items[i]);
                }
            }
            Console.WriteLine("-------------------");
        }
    }
}