namespace LegacyCode.Test;

public class PricingStrategyTest
{
    private readonly double _weight;
    private readonly double _distance;
    private readonly IPricingStrategy standardPricing;
    private readonly IPricingStrategy expressPricing;
    private readonly IPricingStrategy overnightPricing;
    private readonly IPricingStrategy internationalPricing;

    public PricingStrategyTest()
    {
        standardPricing = PricingStrategyFactory.CreateForShippingType("STANDARD");
        expressPricing = PricingStrategyFactory.CreateForShippingType("EXPRESS");
        overnightPricing = PricingStrategyFactory.CreateForShippingType("OVERNIGHT");
        internationalPricing = PricingStrategyFactory.CreateForShippingType("INTERNATIONAL");

        _weight = 5;
        _distance = 120;
    }
    
    [Fact]
    public void ShippingCalculator_StandardPricingStrategy()
    {
        var expectedPricing = _weight * 0.5;
        var calculatedPricing = standardPricing.CalculatePrice(_weight, _distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }

    [Fact]
    public void ShippingCalculator_ExpressPricingStrategy()
    {
        var expectedPricing = _weight * 0.8 + _distance * 0.1;
        var calculatedPricing = expressPricing.CalculatePrice(_weight, _distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }

    [Fact]
    public void ShippingCalculator_OvernightPricingStrategy()
    {
        var expectedPricing = _weight * 1.2 + 25;
        var calculatedPricing = overnightPricing.CalculatePrice(_weight, _distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
        
    }

    [Fact]
    public void ShippingCalculator_InternationalPricingStrategy()
    {
        var expectedPricing = _weight * 1.5;
        var calculatedPricing = internationalPricing.CalculatePrice(_weight, _distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }
}