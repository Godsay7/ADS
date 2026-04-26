using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms4
{
    public class Print
    {
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(new string('-', 15));
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 15));
        }
    }
}
