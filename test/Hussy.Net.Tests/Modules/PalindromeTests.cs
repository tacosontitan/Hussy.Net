/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

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