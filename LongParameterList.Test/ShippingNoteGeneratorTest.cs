namespace LongParameterList.Test;

using NUnit.Framework;

[TestFixture]
public class ShippingNoteGeneratorTest
{
    private readonly ShippingNoteGenerator shippingNoteGenerator = new ShippingNoteGenerator();

    [Test]
    public void ShouldGenerateShippingNoteWithAllInputFields()
    {
        string result = shippingNoteGenerator.GenerateShippingNote(new Customer("Jane", "Doe", "12 Baker Street", "Flat 4B", "London", "NW1 6XE", "UK"), new Order("ORD-123", "Wireless Headphones", 2)
        );

        Assert.That(result, Does.Contain("Order: ORD-123"));
        Assert.That(result, Does.Contain("Customer: Jane Doe"));
        Assert.That(result, Does.Contain("Item: Wireless Headphones"));
        Assert.That(result, Does.Contain("Quantity: 2"));

        Assert.That(result, Does.Contain("12 Baker Street"));
        Assert.That(result, Does.Contain("Flat 4B"));
        Assert.That(result, Does.Contain("London"));
        Assert.That(result, Does.Contain("NW1 6XE"));
        Assert.That(result, Does.Contain("UK"));
    }

    [Test]
    public void ShouldIncludeCustomerFullName()
    {
        string result = shippingNoteGenerator.GenerateShippingNote(new Customer("John", "Smith", "1 High Street", "Apt 2", "Manchester", "M1 2AB", "UK"), new Order("ORD-999", "Laptop", 1)
        );

        Assert.That(result, Does.Contain("Customer: John Smith"));
    }

    [Test]
    public void ShouldIncludeOrderIdAndItemDetails()
    {
        string result = shippingNoteGenerator.GenerateShippingNote(new Customer("Alice", "Brown", "50 King Street", "Unit 3", "Birmingham", "B1 1AA", "UK"), new Order("ORD-555", "Tablet", 5)
        );

        Assert.That(result, Does.Contain("Order: ORD-555"));
        Assert.That(result, Does.Contain("Item: Tablet"));
        Assert.That(result, Does.Contain("Quantity: 5"));
    }

    [Test]
    public void ShouldIncludeFullAddressAcrossAllFields()
    {
        string result = shippingNoteGenerator.GenerateShippingNote(new Customer("Emma", "Jones", "99 High Road", "Floor 2", "Leeds", "LS1 4AB", "UK"), new Order("ORD-777", "Monitor", 3)
        );

        Assert.That(result, Does.Contain("99 High Road"));
        Assert.That(result, Does.Contain("Floor 2"));
        Assert.That(result, Does.Contain("Leeds"));
        Assert.That(result, Does.Contain("LS1 4AB"));
        Assert.That(result, Does.Contain("UK"));
    }

    [Test]
    public void ShouldIncludeQuantityCorrectly()
    {
        string result = shippingNoteGenerator.GenerateShippingNote(new Customer("Tom", "White", "10 Market Street", "", "Liverpool", "L1 8JQ", "UK"), new Order("ORD-321", "Keyboard", 10)
        );

        Assert.That(result, Does.Contain("Quantity: 10"));
    }
}