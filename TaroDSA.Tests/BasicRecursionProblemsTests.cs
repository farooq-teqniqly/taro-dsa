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

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(6, 8)]
    [InlineData(12, 144)]
    [InlineData(25, 75025)]
    public void FibonacciRecursive_Returns_Expected_Result(int n, long expectedResult)
    {
        BasicRecursionProblems.FibonacciRecursive(n).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(6, 8)]
    [InlineData(12, 144)]
    [InlineData(25, 75025)]
    [InlineData(50, 12_586_269_025)]
    public void FibonacciIterative_Returns_Expected_Result(int n, long expectedResult)
    {
        BasicRecursionProblems.FibonacciIterative(n).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(6, 8)]
    [InlineData(12, 144)]
    [InlineData(25, 75025)]
    [InlineData(50, 12_586_269_025)]
    public void FibonacciRecursiveWithCaching_Returns_Expected_Result(int n, long expectedResult)
    {
        var cache = new Dictionary<int, long>();

        BasicRecursionProblems.FibonacciRecursiveWithCaching(n, cache).Should().Be(expectedResult);

        if (n is 0 or 1)
        {
            cache.Count.Should().Be(0);
        }
        else
        {
            cache.Count.Should().Be(n - 1);
        }
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(6, 8)]
    [InlineData(12, 144)]
    [InlineData(25, 75025)]
    [InlineData(50, 12_586_269_025)]
    public void FibonacciUsingFormula_Returns_Expected_Result(int n, long expectedResult)
    {
        BasicRecursionProblems.FibonacciUsingBinetFormula(n).Should().Be(expectedResult);
    }
}
