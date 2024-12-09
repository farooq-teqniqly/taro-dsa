using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests;
public class BasicRecursionProblemsTests
{
    [Fact]
    public void Countdown_Calls_The_Callback()
    {
        var startFrom = 5;
        var beforeCallbackCallCount = 0;
        var afterCallbackCallCount = 0;

        void BeforeCountdownCallback(int n) => beforeCallbackCallCount++;
        void AfterCountdownCallback(int n) => afterCallbackCallCount++;

        BasicRecursionProblems.Countdown(startFrom, BeforeCountdownCallback, AfterCountdownCallback);

        beforeCallbackCallCount.Should().Be(startFrom);
        afterCallbackCallCount.Should().Be(startFrom);

    }
}
