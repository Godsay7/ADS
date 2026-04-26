using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lvl1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack1 = new MyStack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.DisplayStack();
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Pop());
            stack1.DisplayStack();
            Console.WriteLine(stack1.Peek());
        }
    }
}
