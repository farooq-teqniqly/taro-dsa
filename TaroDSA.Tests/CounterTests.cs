using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests;

public class CounterTests
{
    [Fact]
    public void Anagrams_Have_Same_Hash_Codes()
    {
        var word1 = "listen";
        var word2 = "silent";

        var counter1 = new ArrayAndStringProblems.Counter(word1);
        var counter2 = new ArrayAndStringProblems.Counter(word2);

        counter1.GetHashCode().Should().Be(counter2.GetHashCode());
    }

    [Fact]
    public void Cant_Create_Counter_With_Null_String()
    {
        var act = () => new ArrayAndStringProblems.Counter(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Equals_Returns_False_When_That_Object_Is_Null()
    {
        new ArrayAndStringProblems.Counter("a").Equals(null).Should().BeFalse();
    }

    [Fact]
    public void Equals_Returns_False_When_That_Object_Is_Different_Type()
    {
        new ArrayAndStringProblems.Counter("a").Equals("a").Should().BeFalse();
    }
}
