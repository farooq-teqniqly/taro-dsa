namespace TaroDSA.Lib;
public class BasicRecursionProblems
{
    /// <summary>
    /// Performs a countdown from the specified start value to the specified end value (inclusive).
    /// Time complexity: O(n) where n is the number of function calls.
    /// Space complexity: O(n) where n is the number of function calls.
    /// </summary>
    /// <param name="startFrom">The start value of the countdown.</param>
    /// <param name="endInclusive">The end value of the countdown.</param>
    /// <param name="beforeCountdownCallback">An optional callback to be invoked before each countdown step.</param>
    /// <param name="afterCountdownCallback">An optional callback to be invoked after each countdown step.</param>
    /// <param name="step">The step value for each countdown iteration.</param>
    public static void Countdown(
        int startFrom,
        int endInclusive,
        Action<int>? beforeCountdownCallback = null,
        Action<int>? afterCountdownCallback = null,
        int step = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(step);

        if (startFrom <= endInclusive - 1)
        {
            return;
        }

        beforeCountdownCallback?.Invoke(startFrom);
        Countdown(startFrom - step, endInclusive, beforeCountdownCallback, afterCountdownCallback, step);
        afterCountdownCallback?.Invoke(startFrom);
    }

    /// <summary>
    /// Calculates the sum of all elements in the given array recursively.
    /// Time complexity: O(n) where n is the number of function calls.
    /// Space complexity: O(n) where n is the number of function calls.
    /// </summary>
    /// <param name="arr">The array of integers.</param>
    /// <returns>The sum of all elements in the array.</returns>
    public static int RecursiveSum(int[] arr)
    {
        ArgumentNullException.ThrowIfNull(arr);

        return arr.Length == 0 ? 0 : RecursiveSum(arr, 0);
    }

    private static int RecursiveSum(int[] arr, int firstIndex)
    {
        if (firstIndex == arr.Length)
        {
            return 0;
        }

        return arr[firstIndex] + RecursiveSum(arr, firstIndex + 1);
    }
}
