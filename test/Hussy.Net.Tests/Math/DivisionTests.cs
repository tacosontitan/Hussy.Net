namespace Hussy.Net.Tests.Math;

public class DivisionTests
{
    private const double TestInput = 100;
    
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
    public void Division_ProducesCorrectResult(double target)
    {
        var expectedResult = TestInput / target;
        var testFunction = GetFunction(target);
        var actualResult = testFunction(TestInput);
        
        Assert.Equal(expectedResult, actualResult);

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        
        static Func<double, double> GetFunction(double target) => target switch
        {
            2 => Dv2,
            3 => Dv3,
            4 => Dv4,
            5 => Dv5,
            6 => Dv6,
            7 => Dv7,
            8 => Dv8,
            9 => Dv9,
            10 => Dv10
        };
        
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
    }
}