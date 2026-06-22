namespace Comments;

public class X1
{
    public static int SumOfSquares(int lowerBound, int upperBound)
    {
        int accumulatedSum = 0;

        for (int i = lowerBound; i <= upperBound; i++)
        {
            accumulatedSum += i * i;
        }

        return accumulatedSum;
    }
}