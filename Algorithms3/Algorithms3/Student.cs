using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms3
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Course { get; set; }
        public uint StudentId { get; set; }
        public string City { get; set; }
        public Student(string name, string surname, int course, uint studentId, string city)
        {
            Name = name;
            Surname = surname;
            Course = course;
            StudentId = studentId;
            City = city;
        }
        public override string ToString()
        {
            return $"{Name} | {Surname} | {Course} | {City}";
        }
    }
}
