namespace Algorithm.Sort
{
    public class SelectionSort
    {
        public static void Sort(int[] elements)
        {
            for (int i = elements.Length - 1; i > 0; i--)
            {
                int maxIndex = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (elements[j] > elements[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = elements[maxIndex];
                elements[maxIndex] = elements[i];
                elements[i] = temp;
            }
        }
    }
}