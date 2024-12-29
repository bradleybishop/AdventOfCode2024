using System.Linq;
using Microsoft.VisualBasic;

namespace Day1;

public class Program
{

    public static void Main(string[] args)
    {
        var p = new Program();
        p.Run();
    }

    private void Run()
    {
        Console.WriteLine("Advent Of Code Day 1");

        // Input file, split the numbers into two lists.
        //3    4
        //4    3
        //2    5

        var list1 = new List<int>();
        var list2 = new List<int>();

        var inputFile = "../inputs/day1.txt";

        var lines = File.ReadAllLines(inputFile);

        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            list1.Add(int.Parse(numbers[0]));
            list2.Add(int.Parse(numbers[1]));
        }

        list1.Sort();
        list2.Sort();

        int diff = 0;

        for (int i = 0; i < list1.Count; i++)
        {
            diff += Math.Abs(list1[i] - list2[i]);
        }

        Console.WriteLine($"The sum of the differences is {diff}");


        // Caluclate the simulatiry score
        var score = 0;

        foreach(var i in list1)
        {
            score += i * list2.Count(x => x == i);
        }

        Console.WriteLine($"The similarity score is {score}");

    }

}

