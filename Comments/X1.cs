namespace Comments;

public class X1
{
    public static int SumOfSquares(int q, int z)
    {
        int p = 0;

        // Iterate from lower bound (q) to upper bound (z)
        for (int i = q; i <= z; i++)
        {
            p += Square(i);
        }

        // Return accumulated sum
        return p;
    }

    static int Square(int k)
    {
        // Return square of input
        return k * k;
    }
}