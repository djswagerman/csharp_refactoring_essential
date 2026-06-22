namespace Comments.Test;

using NUnit.Framework;

[TestFixture]
public class X1Test
{
    [Test]
    public void T1()
    {
        int lowerBound = 7;
        int upperBound = 12;

        // Expected: sum of squares from 7 to 12
        int expectedSumOfSquares = 0;
        for (int i = lowerBound; i <= upperBound; i++)
        {
            expectedSumOfSquares += i * i;
        }

        var range = new Range(lowerBound, upperBound);
        int actualSumOfSquares = X1.SumOfSquares(range);

        Assert.That(actualSumOfSquares, Is.EqualTo(expectedSumOfSquares));
    }
}