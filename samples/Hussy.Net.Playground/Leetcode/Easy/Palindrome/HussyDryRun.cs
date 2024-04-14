namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    private static bool HussyDryRun(int i) =>
        i > 0 && i.EqRev();
}