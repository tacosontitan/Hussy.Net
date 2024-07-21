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

public class MultiplicationTests
{
    private const double TestValue = 2;
    
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void Multiplication_ProducesCorrectResult(double target)
    {
        var expectedResult = TestValue * target;
        var testFunction = GetFunction(target);
        var actualResult = testFunction(TestValue);
        
        Assert.Equal(expectedResult, actualResult);

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        
        static Func<double, double> GetFunction(double target) => target switch
        {
            2 => Mult2,
            3 => Mult3,
            4 => Mult4,
            5 => Mult5,
            6 => Mult6,
            7 => Mult7,
            8 => Mult8,
            9 => Mult9,
            10 => Mult10
        };
        
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
    }
}