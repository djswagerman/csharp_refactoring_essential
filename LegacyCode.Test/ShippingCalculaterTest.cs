using System.ComponentModel.Design;

namespace LegacyCode.Test;
using System.Text.Json.Serialization;

public class OrderClientTest
{
    [Fact]
    private void CanGetOrder()
    {
        var orderClient = new OrderClient(new HttpClient());
        var order1001 = orderClient.getOrderData(1001);
        Assert.NotNull(order1001);
    }
}

public class CalculatorTests
{
    [Fact]
    public void ShippingCalculator_CanBeInstantiated()
    {
        // Arrange & Act
        var calculator = new ShippingCalculator();

        // Assert
        Assert.NotNull(calculator);
    }

    [Fact]
    public void ShippingCalculator_CreatePricingStrategy()

    {
        var standardPricing = PricingStrategyFactory.Create(Shipping.Standard);
        Assert.NotNull(standardPricing);
        
        var expressPricing = PricingStrategyFactory.Create(Shipping.Express);
        Assert.NotNull(expressPricing);
        
        var overnightPricing = PricingStrategyFactory.Create(Shipping.Overnight);
        Assert.NotNull(overnightPricing);
        
        var internationalPricing = PricingStrategyFactory.Create(Shipping.International);
        Assert.NotNull(internationalPricing);
    }


    [Fact]
    public void ShippingCalculator_StandardPricingStrategy()
    {
        var standardPricing = PricingStrategyFactory.CreateForShippingType("STANDARD");
        
        Assert.NotNull(standardPricing);

        var weight = 5;
        var distance = 120;
        
        var expectedPricing = weight * 0.5;
        var calculatedPricing = standardPricing.CalculatePrice(weight, distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }

    [Fact]
    public void ShippingCalculator_ExpressPricingStrategy()
    {
        var expressPricing = PricingStrategyFactory.CreateForShippingType("EXPRESS");
        Assert.NotNull(expressPricing);
        var weight = 5;
        var distance = 120;

        var expectedPricing = weight * 0.8 + distance * 0.1;
        var calculatedPricing = expressPricing.CalculatePrice(weight, distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }
    
    [Fact]
    public void ShippingCalculator_OvernightPricingStrategy()
    {
        var overnightPricing = PricingStrategyFactory.CreateForShippingType("OVERNIGHT");
        Assert.NotNull(overnightPricing);
        var weight = 5;
        var distance = 120;

        var expectedPricing = weight * 1.2 + 25;
        var calculatedPricing = overnightPricing.CalculatePrice(weight, distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
        
    }
    
    [Fact]
    public void ShippingCalculator_InternationalPricingStrategy()
    {
        var internationalPricing = PricingStrategyFactory.CreateForShippingType("INTERNATIONAL");
        Assert.NotNull(internationalPricing);
        
        var weight = 5;
        var distance = 120;

        var expectedPricing = weight * 1.5;
        var calculatedPricing = internationalPricing.CalculatePrice(weight, distance);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }
}
