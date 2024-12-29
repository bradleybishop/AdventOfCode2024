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
            List<int> parts = line.Split(' ').Select(x => int.Parse(x)).ToList();
            if (IsSafe(parts))
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

        int dampenedSafeReports = 0;

        foreach (var line in lines)
        {
            List<int> parts = line.Split(' ').Select(x => int.Parse(x)).ToList();
            if (IsDampenedSafe(parts))
            {
                dampenedSafeReports++;
                Console.WriteLine("Dampened Safe");
            }
            else
            {
                Console.WriteLine("Dampened Unsafe");
            }
        }

        Console.WriteLine($"Dampened Safe reports: {dampenedSafeReports}");
    }

    public bool IsSafe(List<int> parts)
    {

        bool increasing = parts[0] < parts[1];

        int minDiff = 1;
        int maxDiff = 3;

        int n = parts.Count;

        for (int i = 1; i < n; i++)
        {
            int diff = parts[i - 1] - parts[i];

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

    public bool IsDampenedSafe(List<int> parts)
    {
        //If is safe by original rules, then it is safe by dampened rules
        if (IsSafe(parts))
        {
            return true;
        }

        // Remove each of the elements one by one and check if it is safe
        for (int i = 0; i < parts.Count; i++)
        {
            List<int> newParts = new List<int>(parts);
            newParts.RemoveAt(i);
            if (IsSafe(newParts))
            {
                return true;
            }
        }

        return false;
    }
}