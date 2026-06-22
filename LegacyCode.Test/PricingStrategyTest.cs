namespace LegacyCode.Test;

public class PricingStrategyTest
{
    [Theory]
    [InlineData("STANDARD", 5, 120, 5 * 0.5)]
    [InlineData("EXPRESS", 5, 120, 5 * 0.8 + 120 * 0.1)]
    [InlineData("OVERNIGHT", 5, 120, 5 * 1.2 + 25)]
    [InlineData("INTERNATIONAL", 5, 120, 5 * 1.5)]
    public void ShippingCalculator_PricingStrategy(
        string shippingType, double weight, double distance, double expectedPricing)
    {
        var pricing = ShippingRateFactory.CreateForType(shippingType);
        var calculatedPricing = pricing.Calculate(weight, distance);

        Assert.Equal(expectedPricing, calculatedPricing);
    }
}