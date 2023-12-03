using Keoghs.Kata.Application.Pricing;

namespace Keoghs.Kata.Application.Tests.Pricing;

public class PricingServiceTests
{
    private IPricingService _pricingService;

    //  Note: for simplicity direct object instantiation is used rather than with Moq framework,
    //  which would be my preferred method in a real world production scenario.
    [SetUp]
    public void Setup()
    {
        _pricingService = new PricingService();
    }

    [Test]
    public void UnknownItemsYieldZero()
    {
        //  Arrange
        var pricingService = _pricingService;

        //  Act
        var actual = _pricingService.GetPrice("Z", 3);

        //  Assert
        Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void OneItemCalculatesCorrectPrice()
    {
        //  Arrange
        var pricingService = _pricingService;

        //  Act
        var actual = _pricingService.GetPrice("A", 1);

        //  Assert
        Assert.That(actual, Is.EqualTo(10));
    }

    [Test]
    public void MultipleItemsCalculatesCorrectPrice()
    {
        //  Arrange
        var pricingService = _pricingService;

        //  Act
        var actual = _pricingService.GetPrice("A", 3);

        //  Assert
        Assert.That(actual, Is.EqualTo(30));
    }
}