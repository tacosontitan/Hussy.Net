namespace Hussy.Net.Playground.AdventOfCode.Y2024;

public sealed partial class DayTwo
{
    [Fact]
    public void PartOne_Example()
    {
        const int expectedResult = 2;
        RunTest(expectedResult, Datasets.DayTwoPartOneExampleReports, PartOneDryRun);
    }

    [Fact]
    public void PartOne_Actual()
    {
        const int expectedResult = 402;
        RunTest(expectedResult, Datasets.DayTwoReports, PartOneDryRun);
    }

    private static int PartOneDryRun(IEnumerable<int[]> reports)
    {
        var safeReports = 0;
        foreach (var report in reports)
        {
            var nMinusOne = -1;
            var nMinusTwo = -1;
            var isReportSafe = true;
            foreach (var level in report)
            {
                if (nMinusOne == -1)
                {
                    nMinusOne = level;
                    continue;
                }
                
                var distanceFromPreviousLevel = Math.Abs(level - nMinusOne);
                if (distanceFromPreviousLevel < 1
                    || distanceFromPreviousLevel > 3)
                {
                    isReportSafe = false;
                    break;
                }
                
                if (nMinusTwo == -1)
                {
                    nMinusTwo = nMinusOne;
                    nMinusOne = level;
                    continue;
                }

                var isSequential = (level > nMinusOne && nMinusOne > nMinusTwo)
                    || (level < nMinusOne && nMinusOne < nMinusTwo);

                nMinusTwo = nMinusOne;
                nMinusOne = level;
                if (!isSequential)
                {
                    isReportSafe = false;
                    break;
                }
            }
            
            if (isReportSafe)
                safeReports++;
        }
        
        return safeReports;
    }
}