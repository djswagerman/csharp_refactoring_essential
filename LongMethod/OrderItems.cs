namespace LongMethod;

public class OrderItems
{
    private List<OrderItem> _items;

    public OrderItems(List<OrderItem> orderItems)
    {
        _items = orderItems;
    }

    internal double CalculateSubtotal()
    {
        // Subtotal calculation
        double subtotal = 0.0;
        foreach (var item in _items)
        {
            subtotal += item.Price * item.Quantity;
        }

        return subtotal;
    }

    public void ValidateOrder(Order order)
    {
        // Validation
        if (_items == null)
        {
            throw new InvalidOperationException("Items cannot be null");
        }

        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Order must contain items");
        }
    }
}