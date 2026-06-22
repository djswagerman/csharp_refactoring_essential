
namespace LegacyCode;

public enum Shipping
{
    Standard,
    International,
    Express,
    Overnight
}

public interface IShippingRate
{
    double Calculate(double weight, double distance);
}

public class StandardRate : IShippingRate
{
    public double Calculate(double weight, double distance)
        => weight * 0.5;
}

public class ExpressRate : IShippingRate
{
    public double Calculate(double weight, double distance)
       => weight * 0.8 + distance * 0.1;
}

public class OvernightRate : IShippingRate
{
    public double Calculate(double weight, double distance)
        => weight * 1.2 + 25;
}
public class InternationalRate : IShippingRate
{
    public double Calculate(double weight, double distance)
        => weight * 1.5;
}


public static class ShippingRateFactory
{
    public static IShippingRate Create(Shipping strategy) => strategy switch
    {
        Shipping.Standard => new StandardRate(),
        Shipping.International => new InternationalRate(),
        Shipping.Express => new ExpressRate(),
        Shipping.Overnight => new OvernightRate(),
        _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null)
    };
    
    public static IShippingRate CreateForType(string shippingType) => shippingType switch
    {
        "STANDARD" => new StandardRate(),
        "EXPRESS" => new ExpressRate(),
        "OVERNIGHT" => new OvernightRate(),
        "INTERNATIONAL" => new InternationalRate(),
        _ => throw new Exception($"Unknown shipping type: {shippingType}")
    };
}