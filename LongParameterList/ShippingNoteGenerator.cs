namespace LongParameterList;

public class Address(string addressLine1, string addressLine2, string city, string postcode, string country)
{
    private string AddressLine1 { get; } = addressLine1;
    private string AddressLine2 { get; } = addressLine2;
    private string City { get; } = city;
    private string Postcode { get; } = postcode;
    private string Country { get; } = country;

    private static string FormatAddress(string addressLine1, string addressLine2, string city, string postcode,
        string country)
    {
        string address = addressLine1 + ", "
                                      + (addressLine2 != null ? addressLine2 + ", " : "")
                                      + city + ", "
                                      + postcode + ", "
                                      + country;
        return address;
    }

    public string Addres => FormatAddress (AddressLine1, AddressLine2, City, Postcode, Country);
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

    public string Address
    {
        get { return _address.Addres; }
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
    public string GenerateShippingNote(Customer customer, Order order)
    {
        return "SHIPPING NOTE\n"
               + "Order: " + order.OrderId + "\n"
               + "Customer: " + (customer.CustomerFirstName + " " + customer.CustomerLastName) + "\n"
               + "Ship To: " + customer.Address + "\n"
               + "Item: " + order.ItemDescription + "\n"
               + "Quantity: " + order.Quantity;
    }
}