using System.ComponentModel.Design;
using System.Text.Json.Serialization;

namespace LegacyCode.Test;

public class OrderClientTest
{
    [Fact]
    public void CanGetOrder()
    {
        var orderClient = new OrderClient(new HttpClient());
        var order1001 = orderClient.getOrderData(1001);
        Assert.NotNull(order1001);
    }
}

public class CalculatorTests
{
    private readonly ShippingCalculator calculator;

    public CalculatorTests()
    {
        calculator = new ShippingCalculator();
    }

    [Fact]
    public void ShippingCalculator_CanBeInstantiated()
    {
        Assert.NotNull(calculator);
    }

    [Theory]
    [InlineData("STANDARD", 5, 120, 5 * 0.5)]
    [InlineData("EXPRESS", 5, 120, 5 * 0.8 + 120 * 0.1)]
    [InlineData("OVERNIGHT", 5, 120, 5 * 1.2 + 25)]
    [InlineData("INTERNATIONAL", 5, 120, 5 * 1.5)]
    public void ShippingCalculator_CalculatePricing(
        string shippingType, double weightKg, double distanceKm, double expectedPricing)
    {
        var orderData = new OrderData
        {
            ShippingType = shippingType,
            WeightKg = weightKg,
            DistanceKm = distanceKm
        };

        var calculatedPricing = calculator.CalculateShipping(orderData);

        Assert.Equal(expectedPricing, calculatedPricing);
    }
}