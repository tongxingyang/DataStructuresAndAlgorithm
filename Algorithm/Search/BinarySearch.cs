using System;

namespace Algorithm.Search
{
    public class BinarySearch
    {
        public static int Search(int[] elements, int v)
        {
            if (elements == null || elements.Length == 0)
            {
                return -1;
            }

            int begin = 0;
            int end = elements.Length;
            while (begin < end)
            {
                int mid = (begin + end) >> 1;
                if (v < elements[mid])
                {
                    end = mid;
                }else if (v > elements[mid])
                {
                    begin = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}