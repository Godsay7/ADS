using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lvl2
{
    public class Solution2
    {
        public static bool Analyze(string input)
        {
            int state = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                switch (state)
                {
                    case 0:
                        if (c == '+') state = 1; else state = -1;
                        break;
                    case 1:
                        if (char.IsDigit(c)) state = 2; else state = -1;
                        break;
                    case 2:
                        if (char.IsDigit(c)) state = 2;
                        else if (c == '+') state = 3;
                        else state = -1;
                        break;
                    case 3:
                        if (c == '%') state = 4; else state = -1;
                        break;
                    case 4:
                        if (c == '+') state = 5; else state = -1;
                        break;
                    case 5:
                        if (char.IsDigit(c)) state = 6; else state = -1;
                        break;
                    case 6:
                        if (char.IsDigit(c)) state = 6; else state = -1;
                        break;
                    default:
                        return false; 
                }
            }
            return state == 6;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Type your string for verification (pattern \\+[0-9]+\\+%\\+[0-9]+):");
            string input = Console.ReadLine();
            if (Analyze(input))
            {
                Console.WriteLine("Result: This string does match the regular expression.");
            }
            else
            {
                Console.WriteLine("Result: This string does not match the regular expression.");
            }
        }
    }
}
