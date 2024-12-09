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
        if (startFrom <= endInclusive - 1)
        {
            return;
        }

        beforeCountdownCallback?.Invoke(startFrom);
        Countdown(startFrom - step, endInclusive, beforeCountdownCallback, afterCountdownCallback, step);
        afterCountdownCallback?.Invoke(startFrom);
    }
}
