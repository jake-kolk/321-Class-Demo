using System;

namespace _321_class_demo
{
    class Program
    {
        static int SumPositive(int[] arr)
        {
            int total = 0;
            int i = 0;

            foreach (var x in arr)
            {
                if (i % 2 == 1) 
                {
                    arr[i - 1] += 1; // +1 on odd index, before adding it to total
                }

                // adds x to total
                if (x > 0)
                {
                    total += x;
                }

                i++;
            }

            return total;
        }

        static void Main()
        {
            // Example.
            int[] data = { 2, 3, 4, 5, -1 };

            int total = SumPositive(data);

            Console.WriteLine("Total positive: " + total); 
            Console.WriteLine("Final array: " + string.Join(", ", data));

            // Problem.
            int[] scores = { 80, 95, 72, 95, 88, 72, 95 };
            int target = 95;
            // Expected: 3, Actual: 2
            Console.WriteLine("Count: " + CountOccurrences(scores, target));
        }

        static int CountOccurrences(int[] arr, int target) {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++) {
                if (arr[i] == target) count++;
            }
            return count;
        }
    }
}