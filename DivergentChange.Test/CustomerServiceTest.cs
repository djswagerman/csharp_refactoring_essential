namespace DivergentChange.Test;

using NUnit.Framework;

[TestFixture]
public class CustomerServiceTest
{
    private readonly CustomerService service = new CustomerService();

    // -------------------------
    // isValidEmail tests
    // -------------------------

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsNull()
    {
        Assert.IsFalse(service.IsValidEmail((string?)null));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsEmpty()
    {
        Assert.IsFalse(service.IsValidEmail(""));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingAtSymbol()
    {
        Assert.IsFalse(service.IsValidEmail("invalid.email.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingLocalPart()
    {
        Assert.IsFalse(service.IsValidEmail("@domain.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingDomain()
    {
        Assert.IsFalse(service.IsValidEmail("user@"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenEmailIsValid()
    {
        Assert.IsTrue(service.IsValidEmail("user.name+tag@example.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenSimpleValidEmail()
    {
        Assert.IsTrue(service.IsValidEmail("user@example.com"));
    }

    // -------------------------
    // formatDisplayName tests
    // -------------------------

    [Test]
    public void FormatDisplayName_shouldTrimAndUppercaseLastName()
    {
        string result = service.FormatDisplayName(" John ", " smith ");
        Assert.That(result, Is.EqualTo("John SMITH"));
    }

    [Test]
    public void FormatDisplayName_shouldHandleEmptyStrings()
    {
        string result = service.FormatDisplayName("", "");
        Assert.That(result, Is.EqualTo(" "));
    }

    [Test]
    public void FormatDisplayName_shouldHandleSingleCharacterNames()
    {
        string result = service.FormatDisplayName("A", "b");
        Assert.That(result, Is.EqualTo("A B"));
    }

    // -------------------------
    // calculateLoyaltyPoints tests
    // -------------------------

    [Test]
    public void CalculateLoyaltyPoints_shouldReturnZero_whenNoPurchases()
    {
        Assert.That(service.CalculateLoyaltyPoints(0), Is.EqualTo(0));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldCalculateCorrectly_forPositiveValues()
    {
        Assert.That(service.CalculateLoyaltyPoints(5), Is.EqualTo(50));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldHandleLargeNumbers()
    {
        Assert.That(service.CalculateLoyaltyPoints(10_000), Is.EqualTo(100_000));
    }

    [Test]
    public void CalculateLoyaltyPoints_shouldAllowNegativeValues_butStillMultiply()
    {
        Assert.That(service.CalculateLoyaltyPoints(-5), Is.EqualTo(-50));
    }

    // -------------------------
    // determineAccountStatus tests
    // -------------------------

    [Test]
    public void DetermineAccountStatus_shouldReturnInactive_whenDaysOver365()
    {
        Assert.That(service.DetermineAccountStatus(366), Is.EqualTo("INACTIVE"));
    }

    [Test]
    public void DetermineAccountStatus_shouldReturnDormant_whenBetween31And365()
    {
        Assert.That(service.DetermineAccountStatus(100), Is.EqualTo("DORMANT"));
    }

    [Test]
    public void DetermineAccountStatus_shouldReturnActive_when30DaysOrLess()
    {
        Assert.That(service.DetermineAccountStatus(30), Is.EqualTo("ACTIVE"));
        Assert.That(service.DetermineAccountStatus(0), Is.EqualTo("ACTIVE"));
    }

    [Test]
    public void DetermineAccountStatus_shouldTreatNegativeDaysAsActive()
    {
        Assert.That(service.DetermineAccountStatus(-10), Is.EqualTo("ACTIVE"));
    }
}