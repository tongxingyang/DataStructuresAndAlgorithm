using System;
using System.Collections.Generic;
using System.Text;
using Algorithm.Search;
using Algorithm.Sort;

namespace Algorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int [] arr = new int[20];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100);
            }
            
//            arr = new int[]{80,44,10,79,88,5,69,9,13,96,72,20,7,7,15,2,51,84,36,59};
//            arr = new int[]{1,2,3,4,5,6,7,8,9};
            arr = new int[]{6,5,4,3,2,1};

            sortStep(4);
            
//            List<int> sd = sedgewickStepSequence();
//
//            for (int i = 0; i < sd.Count; i++)
//            {
//                Console.Write(sd[i]+"   ");
//            }
//
//            Console.WriteLine();
            
            DisplayArr(arr);
            
            MergeSort.Sort(arr);
            
            DisplayArr(arr);
            
            Console.ReadKey();
        }

        public static void DisplayArr(int[] arr)
        {
            StringBuilder sb = new StringBuilder("数组元素为 : ");
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i] + "  ");
            }

            Console.WriteLine(sb.ToString());
        }
        
        public static List<int> sedgewickStepSequence() {
            List<int> stepSequence = new List<int>();
            int k = 0, step = 0;
            while (true) {
                if (k % 2 == 0) {
                    int pow = (int) Math.Pow(2, k >> 1);
                    step = 1 + 9 * (pow * pow - pow);
                } else {
                    int pow1 = (int) Math.Pow(2, (k - 1) >> 1);
                    int pow2 = (int) Math.Pow(2, (k + 1) >> 1);
                    step = 1 + 8 * pow1 * pow2 - 6 * pow2;
                }
                if (step >= 50) break;
                stepSequence.Insert(0,step);
                k++;
            }
            return stepSequence;
        }
        
        public static  void sortStep(int step) {
            // col : 第几列，column的简称
            for (int col = 0; col < step; col++) { // 对第col列进行排序
                // col、col+step、col+2*step、col+3*step
                for (int begin = col ; begin < 16; begin += step) {
                    int cur = begin;
                    Console.Write(cur+"  ");
                }
                Console.WriteLine();
            }
        }
    }
    
    
}