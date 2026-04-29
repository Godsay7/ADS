using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Alex", "Smith", "fcst", 1, true),
                new Student("John", "Doe", "faet", 1, false),
                new Student("Emily", "Johnson", "fap", 2, true),
                new Student("Michael", "Brown", "fcst", 2, false),
                new Student("Sarah", "Davis", "fnz", 3, true),
                new Student("David", "Wilson", "fpmv", 3, false),
                new Student("Jessica", "Miller", "fcst", 3, false),
                new Student("Daniel", "Taylor", "akf", 4, true)
            };

            int counter = 0;
            foreach (var student in students)
            {
                if (student.Course == 3 && !student.IsBudget) counter++;
            }
            Console.WriteLine($"There are {counter} students in 3rd course, who aren't on a budget.");


        }
    }
}
