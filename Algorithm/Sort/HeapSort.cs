using System;

namespace Algorithm.Sort
{
    public class HeapSort
    {
        public static void Sort(int[] elements)
        {
            int heapSize = elements.Length;
            for (int i = (heapSize >> 1) - 1; i >= 0; i--) {
                siftDown(elements,i,heapSize);
            }

            while (heapSize > 1)
            {
                heapSize--;
                int temp = elements[0];
                elements[0] = elements[heapSize];
                elements[heapSize] = temp;
                siftDown(elements,0,heapSize);
            }
            
        }

        private static void siftDown(int[] elememts,int index,int heapSize)
        {
            int element = elememts[index];
            int half = heapSize >> 1;
            while (index < half)
            {
                int childIndex = (index << 1) + 1;
                int child = elememts[childIndex];
                int rightIndex = childIndex + 1;

                if (rightIndex < heapSize && elememts[rightIndex] > child)
                {
                    child = elememts[rightIndex];
                    childIndex = rightIndex;
                }

                if (element >= child)
                {
                    break;
                }

                elememts[index] = child;
                index = childIndex;
            }

            elememts[index] = element;
        }
    }
}