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

using System.Security.Cryptography;

namespace Hussy.Net.Tests.Display;

public class ReverseTests
{
    [Theory]
    [InlineData("abc", "cba")]
    [InlineData("ABC", "CBA")]
    [InlineData(123, "321")]
    public void Reverse_ValidInput_ReversesInput(object testValue, string expectation)
    {
        var reversal = Rev(testValue);
        Assert.Equal(expectation, reversal);
    }

    [Fact]
    public void Reverse_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(TestInvocation);

        static void TestInvocation()
        {
            const string? testValue = null;
            _ = Rev(testValue!);
        }
    }
}
