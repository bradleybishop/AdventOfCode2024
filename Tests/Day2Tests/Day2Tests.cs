using Day2;

namespace Day2Tests;

public class Day2Tests
{
    [Theory]
    [InlineData("7 6 4 2 1", true)]
    [InlineData("1 2 7 8 9", false)]
    [InlineData("9 7 6 2 1", false)]
    [InlineData("1 3 2 4 5", true)]
    [InlineData("8 6 4 4 1", true)]
    [InlineData("1 3 6 7 9", true)]
    [InlineData("10 15 17 19 21", true)]
    public void Test1(string line, bool expected)
    {
        var sut = new Program();
        var result = sut.IsDampenedSafe(line.Split(' ').Select(x => int.Parse(x)).ToList());
        Assert.Equal(expected, result);
    }
}