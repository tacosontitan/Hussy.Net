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

namespace Hussy.Net.Tests.Display;

public class ToStringTests
{
    [Fact]
    public void ToString_NullInput_ReturnsNullLiteral()
    {
        const string expectedResult = "null";
        int? testValue = null;
        var actualResult = testValue.Ts();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void ToString_ValidInput_ReturnsInputAsString()
    {
        const string expectedResult = "32";
        var testValue = 32;
        var actualResult = testValue.Ts();
        Assert.Equal(expectedResult, actualResult);
    }
}