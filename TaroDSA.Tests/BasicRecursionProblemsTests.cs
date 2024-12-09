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
}
