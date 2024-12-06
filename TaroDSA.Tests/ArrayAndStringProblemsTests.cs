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

        [Theory]
        [InlineData(new[] {3, 2, 5, 4, 1}, 8, new[] {0, 2})]
        [InlineData(new[] {4, 7, 9, 2, 5, 1}, 5, new[] {0, 5})]
        [InlineData(new[] {4, 7, 9, 2, 5, 1}, 3, new[] {3, 5})]
        [InlineData(new[] {4, 7, 9, 2, 5, 1}, 20, new int[0])]
        [InlineData(new[] {4, -7, 9, -2, 5, 1}, -9, new[] {1, 3})]
        [InlineData(new[] {4, -7, 9, 21, 5, 1}, 14, new[] {1, 3})]
        [InlineData(new int[0], 1, new int[0])]
        public void PairSum_Returns_Expected_Indices(int[] arr, int target, int[] expectedResult)
        {
            ArrayAndStringProblems.PairSum(arr, target).Should().Equal(expectedResult);
        }

        [Fact]
        public void PairSum_When_Input_Null_Throws()
        {
            var act = () => ArrayAndStringProblems.PairSum(null!, 10);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(new[] { 3, 2, 5, 4, 1 }, 8, new[] { 0, 2 })]
        [InlineData(new[] { 4, 7, 9, 2, 5, 1 }, 5, new[] { 0, 5 })]
        [InlineData(new[] { 4, 7, 9, 2, 5, 1 }, 3, new[] { 3, 5 })]
        [InlineData(new[] { 4, 7, 9, 2, 5, 1 }, 20, new int[0])]
        [InlineData(new[] { 4, -7, 9, -2, 5, 1 }, -9, new[] { 1, 3 })]
        [InlineData(new[] { 4, -7, 9, 21, 5, 1 }, 14, new[] { 1, 3 })]
        [InlineData(new int[0], 1, new int[0])]
        public void PairSumBruteForce_Returns_Expected_Indices(int[] arr, int target, int[] expectedResult)
        {
            ArrayAndStringProblems.PairSumBruteForce(arr, target).Should().Equal(expectedResult);
        }

        [Fact]
        public void PairSumBruteForce_When_Input_Null_Throws()
        {
            var act = () => ArrayAndStringProblems.PairSumBruteForce(null!, 10);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
