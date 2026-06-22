namespace Comments.Test;

using NUnit.Framework;

[TestFixture]
public class X1Test
{
    [Test]
    public void T1()
    {
        int a = 7;
        int b = 12;

        // Expected: sum of squares from 7 to 12
        int expected = 0;
        for (int i = a; i <= b; i++)
        {
            expected += i * i;
        }

        var range = new Range(a, b);
        int actual = X1.SumOfSquares(range);

        Assert.That(actual, Is.EqualTo(expected));
    }
}