using System;

namespace Algorithms
{
    public static class Sorting
    {
        /// <summary>
        /// Selection sort (O = n^2)
        /// Selects the min el from unsorted part.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void SelectionSort<T>(this T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var pos = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[pos]) < 0)
                    {
                        pos = j;
                    }
                }
                var temp = array[i];
                array[i] = array[pos];
                array[pos] = temp;
            }
        }

        /// <summary>
        /// Insert sort (O = n^2)
        /// From left to right check if sorted, if not move unsorted 
        /// element to the propper position by swapping with left elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void InsertSort<T>(this T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length; i++)
            {
                var val = array[i];
                var pos = i;
                while (pos > 0 && array[pos - 1].CompareTo(val) > 0)
                {
                    array[pos] = array[pos - 1];
                    pos--;
                }
                array[pos] = val;
            }
        }

        /// <summary>
        /// Bubble sort (O = n^2) 
        /// Bubbles up biggest element to right.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void BubbleSort<T>(this T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Shell sort (O = nlog(n)^2)
        /// Has gap n/2, and checks element from left to right with left/right element +- gap.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void ShellSort<T>(this T[] array) where T : IComparable
        {
            var gap = array.Length / 2;
            while (gap > 0)
            {
                var i = gap;
                while (i < array.Length)
                {
                    var temp = array[i];
                    var j = i - gap;
                    while (j >= 0 && array[j].CompareTo(temp) > 0) {
                        array[j + gap] = array[j];
                        j = j - gap;
                    }
                    array[j + gap] = temp;
                    i++;
                }
                gap = gap / 2;
            }
        }

        /// <summary>
        /// Merge sort (O = nlog(n))
        /// Divides into small subsets and merges them after.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void MergeSort<T>(this T[] array) where T : IComparable
        {
            _internalMergeSort(array, 0, array.Length - 1);
        }

        private static void _internalMergeSort<T>(T[] array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                _internalMergeSort(array, left, mid);
                _internalMergeSort(array, mid + 1, right);
                _internalMerge(array, left, mid, right);
            }
        }

        private static void _internalMerge<T>(T[] array, int left, int mid, int right) where T : IComparable
        {
            int i = left;
            int j = mid + 1;
            int k = left;
            T[] B = new T[right + 1];
            while(i <= mid && j <= right) { 
                if(array[i].CompareTo(array[j]) < 0)
                {
                    B[k] = array[i];
                    i++;
                }else
                {
                    B[k] = array[j];
                    j++;
                }
                k++;
            }
            while(i <= mid)
            {
                B[k] = array[i];
                i++;
                k++;
            }
            while(j <= right)
            {
                B[k] = array[j];
                j++;
                k++;
            }
            for(var x = left; x < right + 1; x++)
            {
                array[x] = B[x];
            }
        }

        /// <summary>
        /// Quick Sort (O = n^2)
        /// Finds a pivot element, where all left are lower, all right are bigger.
        /// Simultanously i j from both sides and swaps.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void QuickSort<T>(this T[] array) where T : IComparable
        {
            _internalQuickSort(array, 0, array.Length - 1);
        }

        private static void _internalQuickSort<T>(T[] array, int low, int high) where T : IComparable
        {
            if (low < high)
            {
                var pi = _quickSortPartition(array, low, high);
                _internalQuickSort(array, low, pi - 1);
                _internalQuickSort(array, pi + 1, high);
            }
        }

        private static int _quickSortPartition<T>(T[] array, int low, int high) where T : IComparable
        {
            var pivot = array[low];
            var i = low + 1;
            var j = high;
            do
            {
                while (i <= j && array[i].CompareTo(pivot) <= 0)
                {
                    i++;
                }
                while (i <= j && array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
                if(i <= j)
                {
                    _swap(array, i, j);
                }
            } while (i < j);
            _swap(array, low, j);
            return j;
        }

        private static void _swap<T>(T[] array, int leftInd, int rightInd) where T : IComparable
        {
            var tmp = array[leftInd];
            array[leftInd] = array[rightInd];
            array[rightInd] = tmp;
        }
    }
}