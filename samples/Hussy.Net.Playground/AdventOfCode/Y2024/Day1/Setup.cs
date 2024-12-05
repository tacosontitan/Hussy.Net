namespace Hussy.Net.Playground.AdventOfCode.Y2024;

public sealed partial class DayOne
{
    private static void RunTest(
        int expectedResult,
        string? source,
        Solution solution)
    {
        var (leftList, rightList) = GetDataForTest(source);
        var actualResult = solution(leftList, rightList);
        Assert.Equal(expectedResult, actualResult);
    }
    
    private static (IEnumerable<int>, IEnumerable<int>) GetDataForTest(string? source)
    {
        ArgumentNullException.ThrowIfNull(source);
        var lines = source.Split('\n');
        var leftList = new List<int>();
        var rightList = new List<int>();
        foreach (var line in lines)
        {
            var values = line.Split("   ");
            var left = int.Parse(values[0]);
            leftList.Add(left);
            
            var right = int.Parse(values[1]);
            rightList.Add(right);
        }
        
        return (leftList, rightList);
    }
}