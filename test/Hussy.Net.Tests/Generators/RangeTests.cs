﻿/*
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

namespace Hussy.Net.Tests.Generators;

public class RangeTests
{
    [Fact]
    public void GenerateRange_WithValidCount_ReturnsCorrectRange()
    {
        var count = 5;
        var actualResult = Gr(count);
        var expectedResult = Enumerable.Range(1, count);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void GenerateRange_WithSpecifiedStartAndValidCount_ReturnsCorrectRange()
    {
        var start = 5;
        var count = 5;
        var actualResult = Gr(start, count);
        var expectedResult = Enumerable.Range(start, count);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void GenerateRange_WithSpecifiedStartStepAndValidCount_ReturnsCorrectRange()
    {
        var start = 5;
        var count = 5;
        var step = 2;
        var actualResult = Gr(start, count, step);
        var expectedResult = new int[] { 5, 7, 9, 11, 13 };
        Assert.Equal(expectedResult, actualResult);
    }
}