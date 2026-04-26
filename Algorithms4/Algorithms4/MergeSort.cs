using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms4
{
    public class MyMergeSort
    {
        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1) return;
            int mid = array.Length / 2;
            int[] leftArray = new int[mid];
            int[] rightArray = new int[array.Length - mid];

            int i = 0;
            int j = 0;

            for (; i < array.Length; i++)
            {
                if (i < mid)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }
            MergeSort(leftArray);
            MergeSort(rightArray);
            Merge(leftArray, rightArray, array);
        }

        private static void Merge(int[] leftArray, int[] rightArray, int[] arr)
        {
            int leftSize = arr.Length / 2;
            int rightSize = arr.Length - leftSize;
            int i = 0, l = 0, r = 0;

            while (l < leftSize && r < rightSize) 
            {
                if (leftArray[l] < rightArray[r])
                {
                    arr[i] = leftArray[l];
                    i++;
                    l++;
                }
                else {
                    arr[i] = rightArray[r];
                    i++;
                    r++;
                }
            }
            while (l < leftSize)
            {
                arr[i] = leftArray[l];
                i++;
                l++;
            }
            while (r < rightSize)
                {
                    arr[i] = rightArray[r];
                    i++;
                    r++;
            }
        }
    }
}
