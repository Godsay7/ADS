using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms4
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Group { get; set; }
        public double AvgRate { get; set; }
        public int MissedLessons { get; set; }
        public Student(string name, string surname, int group, double avgRate, int missedLessons)
        {
            Name = name;
            Surname = surname;      
            Group = group;
            AvgRate = avgRate;
            MissedLessons = missedLessons;
        }
        public override string ToString()
        {
            return $"{Name}, AvgRate: {AvgRate}, MissedLessons: {MissedLessons}";
        }
    }
}
