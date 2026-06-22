namespace LongMethod;

public class OrderItems(List<OrderItem> orderItems)
{
    internal double CalculateSubtotal()
    {
        // Subtotal calculation
        double subtotal = 0.0;
        foreach (var item in orderItems)
        {
            subtotal += item.Price * item.Quantity;
        }

        return subtotal;
    }

    public void Validate()
    {
        // Validation
        if (orderItems == null)
        {
            throw new InvalidOperationException("Items cannot be null");
        }

        if (orderItems.Count == 0)
        {
            throw new InvalidOperationException("Order must contain items");
        }
    }
}