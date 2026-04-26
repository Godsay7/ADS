using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms3
{
    public class Solution
    {
        static void Main(string[] args)
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            Student student1 = new Student("Alice", "Johnson", 1, 1234, "Kyiv");
            tree.Add(student1.StudentId, student1);
            Student student2 = new Student("Bob", "Smith", 2, 5678, "New York");
            tree.Add(student2.StudentId, student2);
            Student student3 = new Student("Charlie", "Brown", 3, 9101, "Kyiv");
            tree.Add(student3.StudentId, student3);
            Student student4 = new Student("Diana", "Smith", 2, 4004, "New York");
            tree.Add(student4.StudentId, student4);
            Student student5 = new Student("Eve", "Johnson", 1, 6429, "Los Angeles");
            tree.Add(student5.StudentId, student5);
            Student student6 = new Student("Steven", "Thompson", 1, 7531, "Texas");
            tree.Add(student6.StudentId, student6);
            Student student7 = new Student("George", "St-Pierre", 3, 3553, "Toronto");
            tree.Add(student7.StudentId, student7);
            tree.PrintTable();
            tree.FindByVariant().ForEach(Console.WriteLine);
            tree.RemoveByVariant();
            tree.PrintTable();
        }
    }
}
