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
}
