using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lvl2;

namespace Algorithms2
{
    public class MyHashTable<T> where T : IHasArea
    {
        private class HashEntry
        {
            public double Key { get; set; } 
            public T Value { get; set; }
            public override string ToString()
            {
                return $"Key: {Key}, Value: {Value}";
            }
        }

        private MyLinkedList<HashEntry>[] _table;
        private int _size;

        public MyHashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size can't be less than 0.");

            _size = size;
            _table = new MyLinkedList<HashEntry>[size];

            for (int i = 0; i < size; i++)
            {
                _table[i] = new MyLinkedList<HashEntry>();
            }
        }

        private int HashFunction(double key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % _size;
        }
        
        public void Insert(double key, T value)
        {
            int index = HashFunction(key);

            HashEntry newEntry = new HashEntry { Key = key, Value = value };
            _table[index].AddLast(newEntry);

        }

        public void PrintTable()
        {
            Console.WriteLine("Position   Elements (Key: Value)");

            for (int i = 0; i < _size; i++)
            {
                Console.Write($"[{i,-6}] | ");
                _table[i].DisplayList();
            }
        }

        public void DelUnwanted(int targetValue)
        {
            
            for (int i = 0; i < _size; i++)
            {
                _table[i].RemoveMatch(x => x.Value.GetArea() < targetValue);
            }
        }
    }
}