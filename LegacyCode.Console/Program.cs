// See https://aka.ms/new-console-template for more information

using System;
using LegacyCode;

public class ShippingApp
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: ShippingApp <orderId>");
            return;
        }

        if (!int.TryParse(args[0], out int orderId))
        {
            Console.WriteLine("Invalid orderId. Must be an integer.");
            return;
        }

        try
        {
            var orderClient = new OrderClient(new HttpClient());
            var orderData = orderClient.getOrderData(orderId);
            if (orderData != null)
            {
                var shippingRate = ShippingRateFactory.CreateForType(orderData.ShippingType);
                double cost = shippingRate.Calculate(orderData.WeightKg, orderData.DistanceKm);

                Console.WriteLine($"OrderData ID: {orderId}");
                Console.WriteLine($"Shipping cost: {cost}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to calculate shipping for order {orderId}");
            Console.WriteLine(e);
        }
    }
}