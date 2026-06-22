namespace LongParameterList;

public class Address
{
    public Address(string addressLine1, string addressLine2, string city, string postcode, string country)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Postcode = postcode;
        Country = country;
    }

    public string AddressLine1 { get; }
    public string AddressLine2 { get; }
    public string City { get; }
    public string Postcode { get; }
    public string Country { get; }
}

public class Customer
{
    private readonly Address _address;

    public Customer(string customerFirstName, string customerLastName, string addressLine1, string addressLine2, string city, string postcode, string country)
    {
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        _address = new Address(addressLine1, addressLine2, city, postcode, country);
    }

    public string CustomerFirstName { get; }
    public string CustomerLastName { get; }

    public Address Address
    {
        get { return _address; }
    }
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
        var addressLine1 = customer.Address.AddressLine1;
        var addressLine2 = customer.Address.AddressLine2;
        var city = customer.Address.City;
        var postcode = customer.Address.Postcode;
        var country = customer.Address.Country;
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