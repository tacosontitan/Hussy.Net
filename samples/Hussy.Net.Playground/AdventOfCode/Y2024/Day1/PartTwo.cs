namespace Hussy.Net.Playground.AdventOfCode.Y2024;

public sealed partial class DayOne
{
    [Fact]
    public void PartTwo_Example()
    {
        const int expectedResult = 31;
        RunTest(expectedResult, Datasets.DayOnePartTwoExampleLists, PartTwoDryRun);
        RunTest(expectedResult, Datasets.DayOnePartTwoExampleLists, PartTwoLinqRun);
    }

    [Fact]
    public void PartTwo_Actual()
    {
        const int expectedResult = 20_719_933;
        RunTest(expectedResult, Datasets.DayOneLists, PartTwoDryRun);
        RunTest(expectedResult, Datasets.DayOneLists, PartTwoLinqRun);
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

    private static int PartTwoLinqRun(
        IEnumerable<int> leftList,
        IEnumerable<int> rightList) =>
        leftList.Select(left => rightList.Count(left.Equals) * left).Sum();
}