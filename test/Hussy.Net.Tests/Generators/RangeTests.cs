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

namespace Hussy.Net.Tests.Generators;

public class RangeTests
{
    [Fact]
    public void GR_SingleParam_Generates_Correct_Range()
    {
        var count = 5;
        var result = Gr(count);
        Assert.Equal(Enumerable.Range(1, count), result);
    }

    [Fact]
    public void GR_TwoParams_Generates_Correct_Range()
    {
        var start = 5;
        var count = 5;

        var result = Gr(start, count);
        Assert.Equal(Enumerable.Range(start, count), result);
    }

    [Fact]
    public void GR_ThreeParams_Generates_Correct_Range()
    {
        var start = 5;
        var count = 5;
        var step = 2;

        var result = Gr(start, count, step);

        Assert.Equal(new int[] { 5, 7, 9, 11, 13 }, result);
    }
}