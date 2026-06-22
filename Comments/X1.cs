namespace Comments;

public class X1
{
    public static int SumOfSquares(int lowerBound, int upperBound)
    {
        int accumulatedSum = 0;

        for (int i = lowerBound; i <= upperBound; i++)
        {
            accumulatedSum += Square(i);
        }

        // Return accumulated sum
        return accumulatedSum;
    }

    static int Square(int k)
    {
        // Return square of input
        return k * k;
    }
}