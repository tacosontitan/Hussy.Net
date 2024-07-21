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

namespace Hussy.Net.Tests.Math;

public class AdditionTests
{
    private const double TestValue = 0;
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void Addition_ProducesCorrectResult(double target)
    {
        var expectedResult = TestValue + target;
        var testFunction = GetFunction(target);
        var actualResult = testFunction(TestValue);
        
        Assert.Equal(expectedResult, actualResult);

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        
        static Func<double, double> GetFunction(double target) => target switch
        {
            1 => Ad1,
            2 => Ad2,
            3 => Ad3,
            4 => Ad4,
            5 => Ad5,
            6 => Ad6,
            7 => Ad7,
            8 => Ad8,
            9 => Ad9,
            10 => Ad10
        };
        
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
    }
}