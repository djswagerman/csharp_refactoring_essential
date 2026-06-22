namespace LegacyCode;

using System;
using System.Net.Http;
using System.Text.Json.Serialization;
public class ShippingCalculator
{
    public double CalculateShipping(OrderData orderData)
    {
        try
        {
            switch (orderData.ShippingType)
            {
                case "STANDARD":
                    return orderData.WeightKg * 0.5;

                case "EXPRESS":
                    return orderData.WeightKg * 0.8
                           + orderData.DistanceKm * 0.1;

                case "OVERNIGHT":
                    return orderData.WeightKg * 1.2 + 25;

                default:
                    throw new Exception($"Unknown shipping type: {orderData.ShippingType}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }
}

