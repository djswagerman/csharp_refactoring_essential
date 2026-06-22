namespace LegacyCode;

using System;
using System.Net.Http;
using System.Text.Json.Serialization;

public class ShippingCalculator
{
    public double CalculateShipping(OrderData orderData)
    {
        var pricingStrategy = PricingStrategyFactory.CreateForShippingType(orderData.ShippingType);
        return  pricingStrategy.CalculatePrice(orderData.WeightKg, orderData.DistanceKm);
    }
}

