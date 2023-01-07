using System;

namespace Algorithms
{
    public static class Search
    {
        public static T LinearSearch<T>(this T[] array, Predicate<T> predicate)
        {
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static int BinarySearch(this int[] array, int value)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                decimal midDecimal = (left + right) / 2;
                int middle = (int)Math.Floor(midDecimal);
                var item = array[middle];
                if (item == value)
                {
                    return item;
                }
                else if (value < item)
                {
                    right--;
                }
                else if (value > item)
                {
                    left++;
                }
            }

            return default(int);
        }

        public static int BinarySearchRecursive(this int[] array, int value)
        {
            return InnerBinarySearchRecursive(array, value, 0, array.Length - 1);
        }

        private static int InnerBinarySearchRecursive(int[] array, int value, int left, int right)
        {
            if (left > right)
            {
                return default(int);
            }

            decimal midDecimal = (left + right) / 2;
            int middle = (int)Math.Floor(midDecimal);
            var item = array[middle];

            if (item == value)
            {
                return item;
            }
            else if (value < item)
            {
                return InnerBinarySearchRecursive(array, value, left, right - 1);
            }
            else
            {
                return InnerBinarySearchRecursive(array, value, left + 1, right);
            }
        }
    }
}
