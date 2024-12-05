namespace Hussy.Net.Playground.AdventOfCode.Y2024;

public sealed partial class DayOne
{
    [Fact]
    public void PartTwo_Example()
    {
        const int expectedResult = 31;
        RunTest(expectedResult, Datasets.DayOnePartTwoExampleLists, PartTwoDryRun);
    }

    [Fact]
    public void PartTwo_Actual()
    {
        const int expectedResult = 20_719_933;
        RunTest(expectedResult, Datasets.DayOneLists, PartTwoDryRun);
    }

    private static int PartTwoDryRun(
        IEnumerable<int> leftList,
        IEnumerable<int> rightList)
    {
        var result = 0;
        foreach (var left in leftList)
        {
            var countInRight = rightList.Count(right => right == left);
            result += left * countInRight;
        }

        return result;
    }
}