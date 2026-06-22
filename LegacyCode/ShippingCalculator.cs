namespace LegacyCode;

using System;
using System.Net.Http;
using System.Text.Json.Serialization;

public class OrderData
{
    public int OrderId { get; set; }
    public string? ShippingType { get; set; }
    public double WeightKg { get; set; }
    public double DistanceKm { get; set; }
    public bool Fragile { get; set; }
}

public class ShippingCalculator
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly OrderClient _orderClient;

    public ShippingCalculator()
    {
        _orderClient = new OrderClient(_httpClient);
    }

    public double CalculateShipping(int orderId)
    {
        try
        {
            var order = _orderClient.getOrderData(orderId);

            switch (order.ShippingType)
            {
                case "STANDARD":
                    return order.WeightKg * 0.5;

                case "EXPRESS":
                    return order.WeightKg * 0.8
                           + order.DistanceKm * 0.1;

                case "OVERNIGHT":
                    return order.WeightKg * 1.2 + 25;

                default:
                    throw new Exception($"Unknown shipping type: {order.ShippingType}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
    }
}

