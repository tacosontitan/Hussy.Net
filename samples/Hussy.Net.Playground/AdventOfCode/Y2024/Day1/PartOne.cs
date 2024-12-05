namespace Hussy.Net.Playground.AdventOfCode.Y2024;

public sealed partial class DayOne
{
    [Fact]
    public void PartOne_Example()
    {
        const int expectedResult = 11;
        RunTest(expectedResult, Datasets.DayOnePartOneExampleLists, PartOneDryRun);
    }

    [Fact]
    public void PartOne_Actual()
    {
        const int expectedResult = 2_164_381;
        RunTest(expectedResult, Datasets.DayOneLists, PartOneDryRun);
    }

    private static int PartOneDryRun(
        IEnumerable<int> leftList,
        IEnumerable<int> rightList)
    {
        var result = 0;
        var orderedLeftList = leftList.OrderBy(left => left);
        var orderedRightList = rightList.OrderBy(right => right);
        for (var i = 0; i < orderedLeftList.Count(); i++)
        {
            var left = orderedLeftList.ElementAt(i);
            var right = orderedRightList.ElementAt(i);
            result += Math.Abs(left - right);
        }

        return result;
    }
}