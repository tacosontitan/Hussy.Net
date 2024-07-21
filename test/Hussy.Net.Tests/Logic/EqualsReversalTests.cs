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

namespace Hussy.Net.Tests.Logic;

public class EqualsReversalTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(0)]
    [InlineData(121)]
    [InlineData("abba")]
    public void EqualsReversal_InputMatchesReversal_ReturnsTrue(object testValue)
    {
        var reversalEqualsTestValue = testValue.EqRev();
        Assert.True(reversalEqualsTestValue);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData("123")]
    public void EqualsReversal_InputDoesNotMatchReversal_ReturnsFalse(object testValue)
    {
        var reversalEqualsTestValue = testValue.EqRev();
        Assert.False(reversalEqualsTestValue);
    }
}