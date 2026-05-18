using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl2
{
    public class Solution2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a length of password:");
            int passNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Which letter we can use(select interval range a-g):");
            string range = Console.ReadLine();
            int lettersNum = CountLetters(range);
            Console.WriteLine($"There are {CountPassword(passNum, lettersNum)} variations of passwords of this length");
        }

        public static int CountPassword(int length, int numOfLetters)
        {
            int all = (int)Math.Pow(16, length-1);
            return all*numOfLetters;
        }

        public static int CountLetters(string interval)
        {
            string[] parts = interval.Split('-');

            if (parts.Length != 2 || parts[0].Length == 0 || parts[1].Length == 0)
            {
                throw new ArgumentException("Wrong format. Expected 'a-h'.");
            }

            char startChar = char.ToLower(parts[0][0]);
            char endChar = char.ToLower(parts[1][0]);

            int count = Math.Abs(endChar - startChar) + 1;

            return count;
        }
    }
}
