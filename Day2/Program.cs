namespace Day2;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        p.Run();
    }

    private void Run()
    {
        Console.WriteLine("Day 2 of Advent of Code!");

        var inputFile = "day2.txt";

        var lines = File.ReadAllLines(inputFile);

        int safeReports = 0;

        foreach (var line in lines)
        {
            if (IsSafe(line))
            {
                safeReports++;
                Console.WriteLine("Safe");
            }
            else
            {
                Console.WriteLine("Unsafe");
            }
        }

        Console.WriteLine($"Safe reports: {safeReports}");
    }

    private bool IsSafe(string line)
    {
        var parts = line.Split(' ');

        bool increasing = int.Parse(parts[0]) < int.Parse(parts[1]);

        int minDiff = 1;
        int maxDiff = 3;

        int n = parts.Length;

        for (int i = 1; i < n; i++)
        {
            int diff = int.Parse(parts[i - 1]) - int.Parse(parts[i]);

            if ((increasing && diff > 0) || (!increasing && diff < 0))
            {
                return false;
            }

            diff = Math.Abs(diff);
            if (diff < minDiff || diff > maxDiff)
            {
                return false;
            }
        }

        return true;

    }
}