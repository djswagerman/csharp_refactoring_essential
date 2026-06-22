
namespace LegacyCode;

public enum Shipping
{
    Standard,
    International,
    Express,
    Overnight
}

public interface IPricingStrategy
{
    double Calculate(double weight, double distance);
}

public class StandardPricing : IPricingStrategy
{
    public double Calculate(double weight, double distance)
        => weight * 0.5;
}

public class ExpressPricing : IPricingStrategy
{
    public double Calculate(double weight, double distance)
       => weight * 0.8 + distance * 0.1;
}

public class OvernightPricing : IPricingStrategy
{
    public double Calculate(double weight, double distance)
        => weight * 1.2 + 25;
}
public class InternationalPricing : IPricingStrategy
{
    public double Calculate(double weight, double distance)
        => weight * 1.5;
}


public static class ShippingRateFactory
{
    public static IPricingStrategy Create(Shipping strategy) => strategy switch
    {
        Shipping.Standard => new StandardPricing(),
        Shipping.International => new InternationalPricing(),
        Shipping.Express => new ExpressPricing(),
        Shipping.Overnight => new OvernightPricing(),
        _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null)
    };
    
    public static IPricingStrategy CreateForType(string shippingType) => shippingType switch
    {
        "STANDARD" => new StandardPricing(),
        "EXPRESS" => new ExpressPricing(),
        "OVERNIGHT" => new OvernightPricing(),
        "INTERNATIONAL" => new InternationalPricing(),
        _ => throw new Exception($"Unknown shipping type: {shippingType}")
    };
}