using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms5
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public bool IsBudget { get; set; }
        public Student(string firstName, string lastName, string faculty, int course, bool isBudget)
        {
            FirstName = firstName;
            LastName = lastName;
            Faculty = faculty;
            Course = course;
            IsBudget = isBudget;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Faculty: {Faculty}, Course: {Course}, Budget: {IsBudget}";
        }
    }
}