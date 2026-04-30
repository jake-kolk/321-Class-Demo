using System;

class Program
{
    static void Main()
    {
        int[] scores = { 85, 90, 92 };

        int total = CalculateTotal(scores);
        double average = CalculateAverage(total, scores.Length);
        string result = DisplayAverage(average);

        Console.WriteLine(result);
    }

    static int CalculateTotal(int[] scores)
    {
        int total = 0;

        foreach (int score in scores)
        {
            total += score;
        }

        return total;
    }

    static double CalculateAverage(int total, int count)
    {
        // BUG: integer division happens here
        return total / count;
    }

    static string DisplayAverage(double average)
    {
        return $"Average: {average:F1}";
    }
}