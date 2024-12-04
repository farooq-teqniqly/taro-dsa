namespace TaroDSA.Lib;

public class CoreProblems
{
    /// <summary>
    /// Finds the maximum value in a collection of integers.
    /// Time complexity: O(n)
    /// Space complexity: O(1) as no new storage is created.
    /// </summary>
    /// <param name="numbers">The collection of integers.</param>
    /// <returns>The maximum value in the collection.</returns>
    public static int FindMax(IEnumerable<int> numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);

        var max = int.MinValue;

        foreach (var number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        return max;
    }
}
