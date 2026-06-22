namespace LongMethod;

public class OrderItems
{
    private Order _order;

    public OrderItems(Order order)
    {
        _order = order;
    }

    internal double CalculateSubtotal()
    {
        // Subtotal calculation
        double subtotal = 0.0;
        foreach (var item in _order._items)
        {
            subtotal += item.Price * item.Quantity;
        }

        return subtotal;
    }

    public void ValidateOrder(Order order)
    {
        // Validation
        if (order.Items == null)
        {
            throw new InvalidOperationException("Items cannot be null");
        }

        if (order.Items.Count == 0)
        {
            throw new InvalidOperationException("Order must contain items");
        }
    }
}