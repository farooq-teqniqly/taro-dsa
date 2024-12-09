namespace TaroDSA.Lib;
public class BasicRecursionProblems
{
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
