using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests;

public class CoreProblemTests
{
    [Theory]
    [InlineData(new [] {4, 7, 2, 8, 10, 9}, 10)]
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
}