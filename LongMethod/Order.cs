namespace LongMethod;

using System.Collections.Generic;

public class Order
{
    private readonly Customer _customer;
    private readonly OrderItems _orderItems;

    public Order(OrderItems orderItems, Customer customer)
    {
        _customer = customer;
        _orderItems = orderItems;
    }

    public OrderSummary Summarise()
    {
        _orderItems.ValidateOrder(this);

        var subtotal = _orderItems.CalculateSubtotal();

        var discount = calculateDiscount(subtotal);

        var taxableAmount = calculateTax(subtotal, discount, out var tax);

        var total = calculateTotal(taxableAmount, tax);

        return new OrderSummary(subtotal, discount, tax, total);
    }

    private static double calculateTotal(double taxableAmount, double tax)
    {
        // Total calculation
        double total = taxableAmount + tax;
        return total;
    }

    private static double calculateTax(double subtotal, double discount, out double tax)
    {
        // Tax calculation
        double taxableAmount = subtotal - discount;
        tax = taxableAmount * 0.20;
        return taxableAmount;
    }

    private double calculateDiscount(double subtotal)
    {
        // Discount rules
        double discount = 0.0;
        if (_customer.IsLoyal)
        {
            discount = subtotal * 0.10;
        }
        else if (subtotal > 100)
        {
            discount = subtotal * 0.05;
        }

        return discount;
    }
}

public class Customer
{
    public bool IsLoyal { get; }

    public Customer(bool loyal)
    {
        IsLoyal = loyal;
    }
}

public class OrderItem
{
    public double Price { get; }
    public double Quantity { get; }

    public OrderItem(double price, double quantity)
    {
        Price = price;
        Quantity = quantity;
    }
}

public class OrderSummary
{
    public double Subtotal { get; }
    public double Discount { get; }
    public double Tax { get; }
    public double Total { get; }

    public OrderSummary(double subtotal, double discount, double tax, double total)
    {
        Subtotal = subtotal;
        Discount = discount;
        Tax = tax;
        Total = total;
    }
}