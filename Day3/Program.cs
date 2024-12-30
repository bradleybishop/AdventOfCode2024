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
    }
}