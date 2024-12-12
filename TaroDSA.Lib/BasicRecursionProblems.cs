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

    /// <summary>
    /// Computes the nth Fibonacci number using a recursive approach.
    /// </summary>
    /// <param name="n">The position of the Fibonacci sequence to compute. Must be non-negative.</param>
    /// <returns>The nth Fibonacci number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="n"/> is negative.
    /// </exception>
    /// <remarks>
    /// Time complexity: O(2^n) due to repeated calculations of overlapping subproblems.
    /// Space complexity: O(n) due to the recursion stack.
    /// </remarks>
    public static long FibonacciRecursive(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        return n switch
        {
            0 => 0,
            1 => 1,
            _ => FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2)
        };
    }

    /// <summary>
    /// Computes the nth Fibonacci number using an iterative approach.
    /// </summary>
    /// <param name="n">The position of the Fibonacci sequence to compute. Must be non-negative.</param>
    /// <returns>The nth Fibonacci number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="n"/> is negative.</exception>
    /// <remarks>
    /// Time complexity: O(n) as it iterates through the sequence once.
    /// Space complexity: O(1) as it uses a constant amount of space.
    /// </remarks>
    public static long FibonacciIterative(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        long prev = 0;
        long curr = 1;

        for (var i = 2; i <= n; i++)
        {
            var temp = curr;
            curr = prev + curr;
            prev = temp;
        }

        return curr;
    }

    /// <summary>
    /// Computes the nth Fibonacci number using a recursive approach with caching to optimize performance.
    /// </summary>
    /// <param name="n">The position of the Fibonacci sequence to compute. Must be non-negative.</param>
    /// <param name="cache">
    /// A dictionary used to store previously computed Fibonacci numbers for reuse.
    /// Keys represent the position in the Fibonacci sequence, and values represent the corresponding Fibonacci numbers.
    /// </param>
    /// <returns>The nth Fibonacci number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="n"/> is negative.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="cache"/> is <c>null</c>.</exception>
    /// <remarks>
    /// Time complexity: O(n) due to memoization reducing redundant calculations.
    /// Space complexity: O(n) for the recursion stack and the cache storage.
    /// </remarks>
    public static long FibonacciRecursiveWithCaching(int n, Dictionary<int, long> cache)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);
        ArgumentNullException.ThrowIfNull(cache);

        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        if (cache.TryGetValue(n, out var value))
        {
            return value;
        }

        var result = FibonacciRecursiveWithCaching(n - 1, cache) + FibonacciRecursiveWithCaching(n - 2, cache);

        cache.Add(n, result);

        return result;
    }

    /// <summary>
    /// Computes the nth Fibonacci number using Binet's formula.
    /// </summary>
    /// <param name="n">The position of the Fibonacci sequence to compute. Must be non-negative.</param>
    /// <returns>The nth Fibonacci number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="n"/> is negative.
    /// </exception>
    /// <remarks>
    /// This method uses Binet's formula to calculate the Fibonacci number, which involves
    /// floating-point arithmetic. As a result, the output may lose precision for very large values of <paramref name="n"/>.
    /// Time complexity: O(1) due to the direct computation.
    /// Space complexity: O(1) as no additional memory is used.
    /// </remarks>
    public static long FibonacciUsingBinetFormula(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        var sqrt5 = Math.Sqrt(5);
        var phi = (1 + sqrt5) / 2;
        var phiConj = (1 - sqrt5) / 2;

        var result = (Math.Pow(phi, n) - Math.Pow(phiConj, n)) / sqrt5;

        return (long)result;
    }
}
