using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl3
{
    public class Solution3
    {
        public static void Main(string[] args)
        {
            string filePath = "D:\\Temp\\lab9.txt";

            List<string> demoStudents = new List<string> { "Student_А", "Student_B", "Student_C" };
            List<string> currentPermutation = new List<string>();
            bool[] used = new bool[demoStudents.Count];

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("FULL LIST OF PERMUTATIONS (MODEL: 1 Commander + 3 Students)");
                writer.WriteLine($"Total combinations (3!): {CalculateFactorial(demoStudents.Count)}\n");

                GenerateAndWritePermutations("Commander", demoStudents, currentPermutation, used, writer);
            }

            Console.WriteLine($"\nCheck the file: {Path.GetFullPath(filePath)}");
        }
        private static long CalculateFactorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private static void GenerateAndWritePermutations(
            string commander,
            List<string> students,
            List<string> current,
            bool[] used,
            StreamWriter writer)
        {
            if (current.Count == students.Count)
            {
                string row = $"{commander} | " + string.Join(" | ", current);
                writer.WriteLine(row);
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    current.Add(students[i]);

                    GenerateAndWritePermutations(commander, students, current, used, writer);

                    current.RemoveAt(current.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}
