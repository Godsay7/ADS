using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Algorithms9
{
    public class Solution1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of students:");
            int n = int.Parse(Console.ReadLine());
            BigInteger comb = Factorial(n-1);
            Console.WriteLine($"There is {comb} combination of {n} students placement");
        }

        public static BigInteger Factorial(int n) 
        {
            if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }
    }
}
