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

    public static string formatAddress(string addressLine1, string addressLine2, string city, string postcode,
        string country)
    {
        string address = addressLine1 + ", "
                                      + (addressLine2 != null ? addressLine2 + ", " : "")
                                      + city + ", "
                                      + postcode + ", "
                                      + country;
        return address;
    }
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
        var address = Address.formatAddress(customer.Address.AddressLine1, customer.Address.AddressLine2, customer.Address.City, customer.Address.Postcode, customer.Address.Country);

        return "SHIPPING NOTE\n"
               + "Order: " + order.OrderId + "\n"
               + "Customer: " + (customer.CustomerFirstName + " " + customer.CustomerLastName) + "\n"
               + "Ship To: " + address + "\n"
               + "Item: " + order.ItemDescription + "\n"
               + "Quantity: " + order.Quantity;
    }
}