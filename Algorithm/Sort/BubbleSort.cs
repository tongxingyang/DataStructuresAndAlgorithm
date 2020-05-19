using System;

namespace Algorithm.Sort
{
    public class BubbleSort
    {
        public static void Sort1(int[] elements)
        {
            for (int i = elements.Length - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (elements[j] < elements[j - 1])
                    {
                        int temp = elements[j];
                        elements[j] = elements[j - 1];
                        elements[j - 1] = temp;
                    }
                }
            }
        }
        
        //提前终止冒泡
        public static void Sort2(int[] elements)
        {
            for (int i = elements.Length - 1; i > 0; i--)
            {
                bool isReplace = false;
                for (int j = 1; j <= i; j++)
                {
                    if (elements[j] < elements[j - 1])
                    {
                        isReplace = true;
                        int temp = elements[j];
                        elements[j] = elements[j - 1];
                        elements[j - 1] = temp;
                    }
                }

                if (!isReplace)
                {
                    break;
                }
            }
        }
        
        //减少不必要的交换次数
        public static void Sort3(int[] elements)
        {
            for (int i = elements.Length - 1; i > 0; i--)
            {
                int sortIndex = 1;
                for (int j = 1; j <= i; j++)
                {
                    if (elements[j] < elements[j - 1])
                    {
                        int temp = elements[j];
                        elements[j] = elements[j - 1];
                        elements[j - 1] = temp;
                        sortIndex = j;
                    }
                }

                i = sortIndex;
            }
        }
        
    }
}