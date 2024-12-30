using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Day3;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        p.Run();
    }

    private void Run()
    {
        Console.WriteLine("Day 3 of Advent of Code!");

        var inputFile = "day3.txt";

        var input = File.ReadAllText(inputFile);

        Regex regex = new Regex(@"mul\(\d*,\d*\)",RegexOptions.IgnoreCase);

        var matches = regex.Matches(input);

        int total = 0;

        foreach(var match in matches)
        {
            List<int> numbers = match.ToString().Replace("mul(","").Replace(")", "").Split(',').Select(x => int.Parse(x)).ToList();

            total += numbers[0] * numbers[1];
        }

        Console.WriteLine($"Total: {total}");

        // Part 2
        bool mulEnabled = true;
        int total2 = 0;
        regex = new Regex(@"mul\(\d*,\d*\)|do\(\)|don\'t\(\)", RegexOptions.IgnoreCase);
        var matches2 = regex.Matches(input);

        foreach(var match in matches2)
        {
            if (match.ToString().StartsWith("don\'t"))
            {
                mulEnabled = false;
            }
            else if (match.ToString().StartsWith("do"))
            {
                mulEnabled = true;
            }
            else if (mulEnabled)
            {
                List<int> numbers = match.ToString().Replace("mul(", "").Replace(")", "").Split(',').Select(x => int.Parse(x)).ToList();

                total2 += numbers[0] * numbers[1];
            }
        }

        Console.WriteLine($"Total 2: {total2}");


    }
}