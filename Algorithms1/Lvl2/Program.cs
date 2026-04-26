using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl2
{
    internal class Program
    {
        static void Main(string[] args) { 
            MyLinkedList list = new MyLinkedList();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddFirst(3);
            list.AddLast(4);
            list.DisplayList();
            list.RemoveElement(2);
            list.DisplayList();
        }
    }
}
