using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms6
{
    public class MergeSortBottomUp
    {
        public static void Sort(int[] arr) 
        {
            int l = arr.Length;
            int[] temp = new int[l];

            for (int width = 1; width < l; width *= 2)
            {
                for (int i = 0; i < l; i += 2 * width)
                {
                    int left = i;
                    int mid = Math.Min(i + width, l);
                    int right = Math.Min(i + 2 * width, l);
                    Merge(arr, temp, left, mid, right);
                }
            }
        }

        private static void Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i = left; // index for left subarray
            int j = mid; // index for right subarray
            int k = left; // index for merged array
            while (i < mid && j < right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }
            while (i < mid)
            {
                temp[k++] = arr[i++];
            }
            while (j < right)
            {
                temp[k++] = arr[j++];
            }

            for (i = left; i < right; i++)
            {
                arr[i] = temp[i];
            }
        }
    }
}
