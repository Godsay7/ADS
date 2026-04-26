using Lvl1;
using Lvl2;

namespace Lvl3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack1 = new MyStack<int>();
            MyLinkedList list1 = new MyLinkedList();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            stack1.Push(6);
            stack1.DisplayStack();
            while (stack1.Count != 0)
            {
                if (stack1.Peek() % 2 == 0)
                {
                    list1.AddFirst(stack1.Pop());
                }
                else if (stack1.Peek() % 2 == 1)
                {
                    list1.AddLast(stack1.Pop());
                }
            }
            list1.DisplayList();
        }
    }
}