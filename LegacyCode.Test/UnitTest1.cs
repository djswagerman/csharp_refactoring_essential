namespace LegacyCode.Test;

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
}
