namespace LegacyCode.Test;
using System.Text.Json.Serialization;

public class LegacyCalculatorTests
{
    [Fact]
    public void ShippingCalculator_CanBeInstantiated()
    {
        // Arrange & Act
        var calculator = new ShippingCalculator();

        // Assert
        Assert.NotNull(calculator);
    }
    
    [Fact] void CanGetOrder()
    {
        var orderClient = new OrderClient(new HttpClient());
        var order1001 = orderClient.getOrderData(1001);
        
        var calculator = new ShippingCalculator();
    }
}
