namespace Algorithm.Sort
{
    public class InsertionSort
    {
        public static void Sort(int[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                int j;
                int value = elements[i];
                for (j = i ; j > 0; j--)
                {
                    if (value < elements[j - 1])
                    {
                        elements[j] = elements[j - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                elements[j] = value;
                Program.DisplayArr(elements);
            }
        }
    }
}