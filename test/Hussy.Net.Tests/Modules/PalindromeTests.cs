namespace Hussy.Net.Tests.Modules;

public class PalindromeTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(55)]
    [InlineData(121)]
    [InlineData(1221)]
    public void Palindrome_IsPalindrome_ReturnsTrue(int testValue)
    {
        var isPalindrome = Pal(testValue);
        Assert.True(isPalindrome);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(12)]
    [InlineData(123)]
    [InlineData(1223)]
    public void Palindrome_IsNotPalindrome_ReturnsFalse(int testValue)
    {
        var isPalindrome = Pal(testValue);
        Assert.False(isPalindrome);
    }
}