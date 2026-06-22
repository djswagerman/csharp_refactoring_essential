namespace Comments;

public record Range(int LowerBound, int UpperBound);

public static class RangeOfInteger
{
    public static int SumSquares(Range range)
    {
        int accumulatedSum = 0;

        for (int i = range.LowerBound; i <= range.UpperBound; i++)
        {
            accumulatedSum += i * i;
        }

        return accumulatedSum;
    }
}