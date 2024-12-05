using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests;

public class CoreProblemsTests
{
    [Theory]
    [InlineData(new[] { 4, 7, 2, 8, 10, 9 }, 10)]
    [InlineData(new[] { -4, -7, -2, -8, -10, -9 }, -2)]
    [InlineData(new int[0], int.MinValue)]
    public void Can_Find_Max(int[] numbers, int expectedResult)
    {
        CoreProblems.FindMax(numbers).Should().Be(expectedResult);
    }

    [Fact]
    public void Max_When_Input_Null_Throws()
    {
        var act = () => CoreProblems.FindMax(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(8, false)]
    [InlineData(11, true)]
    [InlineData(100, false)]
    [InlineData(101, true)]
    [InlineData(1, false)]
    public void Can_Get_Primes(int number, bool expectedResult)
    {
        CoreProblems.IsPrime(number).Should().Be(expectedResult);
    }
}