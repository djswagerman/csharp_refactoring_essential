namespace Comments;

public record Range(int LowerBound, int UpperBound);

public class X1
{
    public static int SumOfSquares(Range range)
    {
        int accumulatedSum = 0;

        for (int i = range.LowerBound; i <= range.UpperBound; i++)
        {
            accumulatedSum += i * i;
        }

        return accumulatedSum;
    }
}