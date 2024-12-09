namespace TaroDSA.Lib;

public class CoreProblems
{
    /// <summary>
    /// Finds the maximum value in a collection of integers.
    /// Time complexity: O(n)
    /// Space complexity: O(1)
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

    /// <summary>
    /// Determines whether a given number is prime.
    /// Time complexity: O(sqrt(n))
    /// Space complexity: O(1)
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if the number is prime; otherwise, false.</returns>
    public static bool IsPrime(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        switch (number)
        {
            case 1:
                return false;
            case 2:
                return true;
        }

        for (var i = 2; i < Math.Ceiling(Math.Sqrt(number)); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
