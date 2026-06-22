namespace FeatureEnvy.Test;

using NUnit.Framework;

[TestFixture]
public class PriceCalculatorTests
{

    [Test]
    public void ShouldApplyDiscountWhenProductIsOnSale()
    {
        Product product = new Product(100.0, true);

        double result = product.FinalPrice;

        Assert.That(result, Is.EqualTo(80.0));
    }

    [Test]
    public void ShouldNotApplyDiscountWhenProductIsNotOnSale()
    {
        Product product = new Product(100.0, false);

        double result = product.FinalPrice;

        Assert.That(result, Is.EqualTo(100.0));
    }

    [Test]
    public void ShouldReturnZeroWhenPriceIsZeroEvenIfOnSale()
    {
        Product product = new Product(0.0, true);

        double result = product.FinalPrice;

        Assert.That(result, Is.EqualTo(0.0));
    }
}