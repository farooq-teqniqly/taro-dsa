using FluentAssertions;
using TaroDSA.Lib;

namespace TaroDSA.Tests
{
    public class ArrayAndStringProblemsTests
    {
        [Theory]
        [InlineData("restful", "fluster", true)]
        [InlineData("restfu l", "fluster", true)]
        [InlineData("mon keys   write", "ne wyor kti  mes", true)]
        [InlineData("paper", "reapa", false)]
        [InlineData("cats", "tocs", false)]
        [InlineData("", "   ", true)]
        public void IsAnagram_Returns_Expected_Result(string a, string b, bool expectedResult)
        {
            ArrayAndStringProblems.IsAnagram(a, b).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("a", null)]
        [InlineData(null, "b")]
        public void IsAnagram_Throws_When_Input_Is_Null(string a, string b)
        {
            var act = () => ArrayAndStringProblems.IsAnagram(a, b);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("potato", 'o')]
        [InlineData("bookeeper", 'e')]
        [InlineData("david", 'd')]
        [InlineData("abby", 'b')]
        [InlineData("mississippi", 'i')]
        [InlineData("a", 'a')]
        public void Can_Get_The_Most_Frequent_Character(string s, char expectedResult)
        {
            ArrayAndStringProblems.GetMostFrequentCharacter(s).Should().Be(expectedResult);
        }
    }
}
