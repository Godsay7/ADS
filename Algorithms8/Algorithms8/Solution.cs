using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Algorithms8
{
    public class Solution
    {
        static void Main(string[] args)
        {
            string pattern = @"^\+\d+\$%\+\d+$";

            using FileStream fs = new FileStream("D:\\Temp\\regex.txt", FileMode.Open);
            using StreamReader reader = new StreamReader(fs);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    Console.WriteLine($"Found: {match.Value}");
                }
            }
        }
    }
}
