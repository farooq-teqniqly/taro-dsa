namespace TaroDSA.Lib;
public class BasicRecursionProblems
{
    public static void Countdown(int n, Action<int>? beforeCountdownCallback, Action<int>? afterCountdownCallback)
    {
        if (n == 0)
        {
            return;
        }

        beforeCountdownCallback?.Invoke(n);
        Countdown(n - 1, beforeCountdownCallback, afterCountdownCallback);
        afterCountdownCallback?.Invoke(n);
    }
}
