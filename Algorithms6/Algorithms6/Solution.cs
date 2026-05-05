using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms6
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            CheckOut();

            int[] arrS1 = RandArrN(1000);
            int[] arrM1 = RandArrN(10000);
            int[] arrL1 = RandArrN(1000000);
            Stopwatch watcher = Stopwatch.StartNew();
            QuickSort.Sort(arrS1);
            watcher.Stop();
            Console.WriteLine($"Quicksort went through {arrS1.Length} elements in {watcher.ElapsedMilliseconds} ms");

            watcher.Reset();
            watcher.Start();
            QuickSort.Sort(arrM1);
            watcher.Stop();
            Console.WriteLine($"Quicksort went through {arrM1.Length} elements in {watcher.ElapsedMilliseconds} ms");
           
            watcher.Reset();
            watcher.Start();
            QuickSort.Sort(arrL1);
            watcher.Stop();
            Console.WriteLine($"Quicksort went through {arrL1.Length} RANDOM elements in {watcher.ElapsedMilliseconds} ms");

            watcher.Reset();
            watcher.Start();
            QuickSort.Sort(arrL1);
            watcher.Stop();
            Console.WriteLine($"Quicksort went through {arrL1.Length} SORTED elements in {watcher.ElapsedMilliseconds} ms");

            Array.Reverse(arrL1);
            watcher.Reset();
            watcher.Start();
            QuickSort.Sort(arrL1);
            watcher.Stop();
            Console.WriteLine($"Quicksort went through {arrL1.Length} REVERSE elements in {watcher.ElapsedMilliseconds} ms");

            int[] arrS2 = RandArrN(1000);
            int[] arrM2 = RandArrN(10000);
            int[] arrL2 = RandArrN(1000000);

            watcher.Reset();
            watcher.Start();
            MergeSortBottomUp.Sort(arrS2);
            watcher.Stop();
            Console.WriteLine($"Bottom-Up merge sort went through {arrS2.Length} elements in {watcher.ElapsedMilliseconds} ms");

            watcher.Reset();
            watcher.Start();
            MergeSortBottomUp.Sort(arrM2);
            watcher.Stop();
            Console.WriteLine($"Bottom-Up merge sort went through {arrM2.Length} elements in {watcher.ElapsedMilliseconds} ms");

            watcher.Reset();
            watcher.Start();
            MergeSortBottomUp.Sort(arrL2);
            watcher.Stop();
            Console.WriteLine($"Bottom-Up merge sort went through {arrL2.Length} RANDOM elements in {watcher.ElapsedMilliseconds} ms");

            watcher.Reset();
            watcher.Start();
            MergeSortBottomUp.Sort(arrL2);
            watcher.Stop();
            Console.WriteLine($"Bottom-Up merge sort went through {arrL2.Length} SORTED elements in {watcher.ElapsedMilliseconds} ms");

            Array.Reverse(arrL2);
            watcher.Reset();
            watcher.Start();
            MergeSortBottomUp.Sort(arrL2);
            watcher.Stop();
            Console.WriteLine($"Bottom-Up merge sort went through {arrL2.Length} REVERSE elements in {watcher.ElapsedMilliseconds} ms");

        }

        public static int[] RandArrN(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Random.Shared.Next(1, 101);
            }
            return arr;
        }

        public static void CheckOut() 
        {
            int[] arr1 = RandArrN(100);
            int[] arr2 = RandArrN(100);

            foreach (var item in arr1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            QuickSort.Sort(arr1);
            foreach (var item in arr1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            ////////
            foreach (var item in arr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));
            MergeSortBottomUp.Sort(arr2);
            foreach (var item in arr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 30));

        }
    }   
}
