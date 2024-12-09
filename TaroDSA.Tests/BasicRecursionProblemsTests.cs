using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests;
public class BasicRecursionProblemsTests
{
    [Theory]
    [InlineData(5, 1, 1)]
    [InlineData(5, 0, 1)]
    [InlineData(5, 0, 2)]
    [InlineData(6, 0, 2)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 0, 2)]
    [InlineData(1, 1, 1)]
    [InlineData(1, 1, 2)]
    public void Countdown_Calls_The_Callback(int startFrom, int endInclusive, int step)
    {
        var beforeCallbackCallCount = 0;
        var afterCallbackCallCount = 0;

        BasicRecursionProblems.Countdown(
            startFrom,
            endInclusive,
            BeforeCountdownCallback,
            AfterCountdownCallback, step);

        var expectedCallCount = 1 + ((startFrom - endInclusive) / step);
        beforeCallbackCallCount.Should().Be(expectedCallCount);
        afterCallbackCallCount.Should().Be(expectedCallCount);
        return;

        void AfterCountdownCallback(int n) => afterCallbackCallCount++;
        void BeforeCountdownCallback(int n) => beforeCallbackCallCount++;
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Countdown_When_Step_Is_Zero_Or_Negative_Throws(int step)
    {
        var act = () => BasicRecursionProblems.Countdown(1, 0, step: step);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(new[] { 5, 2, 9, 10 }, 26)]
    [InlineData(new[] { 1, -1, 1, -1, 1, -1, 1 }, 1)]
    [InlineData(new[] { 1000, 0, 0, 0, 0, 0, 1 }, 1001)]
    [InlineData(new int[0], 0)]
    public void RecursiveSum_Returns_Expected_Result(int[] arr, int expectedResult)
    {
        BasicRecursionProblems.RecursiveSum(arr).Should().Be(expectedResult);
    }

    [Fact]
    public void RecursiveSum_When_Array_Is_Null_Throws()
    {
        var act = () => BasicRecursionProblems.RecursiveSum(null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
