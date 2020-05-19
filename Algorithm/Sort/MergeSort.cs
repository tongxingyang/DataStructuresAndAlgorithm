using System;

namespace Algorithm.Sort
{
    public class MergeSort
    {
        public static void Sort(int[] elements)
        {
            int[] leftArr = new int[elements.Length >> 1];
            sort(0, elements.Length, leftArr, elements);
        }

        private static void sort(int begin,int end, int[] leftArr,int[] elements)
        {
            int mid = (begin + end) >> 1;
//            Console.WriteLine("begin   "+begin+"     mid  "+ mid+"    end     "+end+"    "+(end - begin < 2));
            if(end - begin < 2) return;

            sort(begin, mid, leftArr, elements);
            sort(mid, end, leftArr, elements);

//            Console.WriteLine("合并元素   "+begin+"   mid   "+mid +"   end   "+end);
            merge(begin, mid, end, leftArr,elements);
            
//            Program.DisplayArr(elements);
        }

        private static void merge(int begin, int mid, int end, int[] leftArr,int[] elements)
        {
            int li = 0, le = mid - begin;
            int ri = mid, re = end;
            int ai = begin;
		
            // 备份左边数组
            for (int i = li; i < le; i++) {
                leftArr[i] = elements[begin + i];
            }
		
            // 如果左边还没有结束
            while (li < le) { 
                if (ri < re && elements[ri]< leftArr[li]) {
                    elements[ai++] = elements[ri++];
                } else {
                    elements[ai++] = leftArr[li++];
                }
            }
        }
        
//        public class Merga
//        {
//            public static void MergaSort(int[] arr, int n)
//            {
//                int[] temp = new int[n];
//                mergeSort(arr,0,n-1,temp);
//            }
//
//            static void mergeSort(int[] arr, int first, int last, int[] temp)
//            {
//                if (first < last)
//                {
//                    int mid = (first + last) / 2;
//                    mergeSort(arr, first, mid, temp);
//                    mergeSort(arr, mid+1, last, temp);
//                    mergeArr(arr, first, mid, last, temp);
//                }
//            }
//
//            static void mergeArr(int[] arr, int first, int mid, int last, int[] temp)
//            {
//                int i = first;
//                int j = mid + 1;
//                int m = mid;
//                int n = last;
//                int k = 0;
//                while (i<=m && j<=n)
//                {
//                    if (arr[i] <= arr[j])
//                    {
//                        temp[k++] = arr[i++];
//                    }
//                    else
//                    {
//                        temp[k++] = arr[j++];
//                    }
//                }
//                while (i <= m)
//                {
//                    temp[k++] = arr[i++];
//                }
//                while (j <= n)
//                {
//                    temp[k++] = arr[j++];
//                }
//                for (int l = 0; l < k; l++)
//                {
//                    arr[first + l] = temp[l];
//                }
//            }
//        }
        
        
//        public static void QuickSort(int[] arr, int left, int right)
//        {
//            if (left < right)
//            {
//                int index = SortOnce(arr, left, right);
//                QuickSort(arr, left, index - 1);
//                QuickSort(arr, index + 1, right);
//            }
//        }
//        static int SortOnce(int[] arr, int left, int right)
//        {
//            int temp = arr[left];
//            while (left < right)
//            {
//                while (left < right&&arr[right] >= temp)
//                {
//                    right--;
//                }
//                arr[left] = arr[right];
//                while (left < right&&arr[left] <= temp)
//                {
//                    left++;
//                }
//                arr[right] = arr[left];
//            }
//            arr[left] = temp;
//            return left;
//        }
//    }
        
    }
}