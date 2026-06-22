namespace LongParameterList;

public class Customer(string customerFirstName, string customerLastName, string addressLine1, string addressLine2, string city, string postcode, string country)
{
    public string CustomerFirstName { get; } = customerFirstName;
    public string CustomerLastName { get; } = customerLastName;
    public string AddressLine1 { get; } = addressLine1;
    public string AddressLine2 { get; } = addressLine2;
    public string City { get; } = city;
    public string Postcode { get; } = postcode;
    public string Country { get; } = country;
}

public class Order(string orderId, string itemDescription, int quantity)
{
    public string OrderId { get; } = orderId;
    public string ItemDescription { get; } = itemDescription;
    public int Quantity { get; } = quantity;
}

public class ShippingNoteGenerator
{
    public string GenerateShippingNote(Customer customer, Order order
    )
    {
        var orderId = order.OrderId;
        var itemDescription = order.ItemDescription;
        var quantity = order.Quantity;
        var customerFirstName = customer.CustomerFirstName;
        var customerLastName = customer.CustomerLastName;
        var addressLine1 = customer.AddressLine1;
        var addressLine2 = customer.AddressLine2;
        var city = customer.City;
        var postcode = customer.Postcode;
        var country = customer.Country;
        string fullName = customerFirstName + " " + customerLastName;

        string address = addressLine1 + ", "
                                      + (addressLine2 != null ? addressLine2 + ", " : "")
                                      + city + ", "
                                      + postcode + ", "
                                      + country;

        return "SHIPPING NOTE\n"
               + "Order: " + orderId + "\n"
               + "Customer: " + fullName + "\n"
               + "Ship To: " + address + "\n"
               + "Item: " + itemDescription + "\n"
               + "Quantity: " + quantity;
    }
}