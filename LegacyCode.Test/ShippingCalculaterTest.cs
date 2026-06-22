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
    private readonly PricingStrategyTest _pricingStrategyTest = new PricingStrategyTest();

    [Fact]
    public void ShippingCalculator_CanBeInstantiated()
    {
        // Arrange & Act
        var calculator = new ShippingCalculator();

        // Assert
        Assert.NotNull(calculator);
    }

    [Fact]
    public void ShippingCalculator_CalculateStandardPricing()
    {
        var calculator = new ShippingCalculator();
        var orderData = new OrderData();
            
        orderData.ShippingType = "STANDARD";
        orderData.WeightKg = 5;
        orderData.DistanceKm = 120;
        
        var expectedPricing = orderData.WeightKg * 0.5;
        var calculatedPricing = calculator.CalculateShipping(orderData);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }
    
    [Fact]
    public void ShippingCalculator_CalculateExpressPricing()
    {
        var calculator = new ShippingCalculator();
        var orderData = new OrderData();
            
        orderData.ShippingType = "EXPRESS";
        orderData.WeightKg = 5;
        orderData.DistanceKm = 120;
        
        var expectedPricing = orderData.WeightKg * 0.8 + orderData.DistanceKm * 0.1;
        var calculatedPricing = calculator.CalculateShipping(orderData);
        
        Assert.Equal(expectedPricing, calculatedPricing);
    }
}
