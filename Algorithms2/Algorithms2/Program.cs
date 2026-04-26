using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2
{
    public class Program
    {
        static void Main(string[] args) 
        {
            Triangle triangle1 = new Triangle();
            Triangle triangle2 = new Triangle(0, 0, 8, 0, 0, 6);
            Triangle triangle3 = new Triangle(0, 0, 4, 0, 0, 3);
            MyHashTable<Triangle> hashTable = new MyHashTable<Triangle>(10);
            hashTable.Insert(triangle1.GetPerimeter(), triangle1);
            hashTable.Insert(triangle2.GetPerimeter(), triangle2);
            hashTable.Insert(triangle3.GetPerimeter(), triangle3);
            hashTable.PrintTable();
            hashTable.DelUnwanted(25); 
            hashTable.PrintTable();
        }
    }
}
